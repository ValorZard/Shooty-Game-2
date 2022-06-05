/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDetectEnableButtons : ControllerDetect
{
    // Private variables
        // Reference to the children buttons
        private Button[] m_Buttons;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the children buttons
        m_Buttons = GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // Refresh the list
        RefreshControllerList();

        // Check the buttons
        CheckButtons();
    }

    // Enable and disable the relevant buttons
    private void CheckButtons()
    {
        // If a controller is detected...
        if(m_StringList.Count > 0)
        {
            // ... enable the second button
            m_Buttons[1].gameObject.SetActive(true);
            m_Buttons[1].interactable = true;
            // Disable the first button
            m_Buttons[0].gameObject.SetActive(false);
            m_Buttons[0].interactable = false;
        }
        // Otherwise, a controller is NOT detected...
        else
        {
            // ... enable the first button
            m_Buttons[0].gameObject.SetActive(true);
            m_Buttons[0].interactable = true;
            // Disable the second button
            m_Buttons[1].gameObject.SetActive(false);
            m_Buttons[1].interactable = false;
        }
    }
}
