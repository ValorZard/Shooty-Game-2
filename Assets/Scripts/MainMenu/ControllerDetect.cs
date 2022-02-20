/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControllerDetect : MonoBehaviour
{
    // Private variables
        // Reference to the text
        private TextMeshProUGUI m_TMP;
        // Reference to the button
        private Button m_Button;
        // List of controllers
        private List<string> m_StringList;

    // Start is called before the first frame update
    void Start()
    {
        m_TMP = GetComponent<TextMeshProUGUI>();
        m_Button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // Refresh the list
        RefreshControllerList();

        // If the text exists...
        if(m_TMP != null)
            // ... check the text
            CheckText();
        
        // If the button exists...
        if(m_Button != null)
            // ... check the button
            CheckButton();
    }

    // Refresh the controller list
    private void RefreshControllerList()
    {
        // Reset the list
        m_StringList = new List<string>();

        // Go through all the controllers
        for(int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            // Grab the string at that index
            string str = Input.GetJoystickNames()[i];

            // Assign the controller name if it's not empty
            if(!str.Equals(""))
                m_StringList.Add(str);
        }

        /*
            Unfortunately, I have to use this roundabout way to track
            controllers, since Input returns empty controllers when
            there used to be a controller plugged in.
        */
    }

    // Enables/disables the warning text
    private void CheckText()
    {
        // If a controller is detected, hide the warning text
        if(m_StringList.Count > 0)
            m_TMP.enabled = false;
        
        // Otherwise, show the warning text
        else
            m_TMP.enabled = true;
    }

    // Enables/disables the button
    private void CheckButton()
    {
        // If a controller is detected, enable the button
        if(m_StringList.Count > 0)
            m_Button.interactable = true;
        
        // Otherwise, disable the button
        else
            m_Button.interactable = false;
    }
}
