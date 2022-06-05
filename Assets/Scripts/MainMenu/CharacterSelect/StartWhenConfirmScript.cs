/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    As of writing this, this script is no longer used.
*/

public class StartWhenConfirmScript : MonoBehaviour
{
    // Private variables
        // Reference to the start button
        private Button m_Button;
        // Reference to the character selec scripts
        private CharacterSelect[] m_Scripts;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the start button
        m_Button = GetComponent<Button>();

        // Grab the scripts
        m_Scripts = FindObjectsOfType<CharacterSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // If all players have confirmed their choices...
        if(AreAllDisabled())
        {
            // ... enable the start button
            m_Button.interactable = true;
        }
        // Otherwise, disable it
        else
            m_Button.interactable = false;
        */
    }

    // Checks the scripts to see if ALL are disabled
    private bool AreAllDisabled()
    {
        // Refreshes the list (in case a controller is plugged in)
        m_Scripts = FindObjectsOfType<CharacterSelect>();

        // Go through the list
        foreach(CharacterSelect script in m_Scripts)
            // If a script is enabled, return false
            if(script.enabled)
                return false;

        // All scripts are disabled; return true
        return true;
    }
}
