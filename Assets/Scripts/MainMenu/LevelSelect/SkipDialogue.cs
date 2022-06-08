/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
    This script is exclusively for the level select screen.
    This script is specifically made with the scenes "LevelOne" and
    "DialogSample" in mind.
    If a level redirects to a dialogue scene, then the
    "skip dialogue" toggle becomes visible.
    Otherwise, the toggle becomes invisible.
    If "skip dialogue" is toggled, then the dialogue scene is
    skipped and starting jumps into the level first.
    Otherwise, the dialogue scene plays, which automatically takes
    the player to the correct scene afterward.
*/

public class SkipDialogue : MonoBehaviour
{
    // Private variables
        // Reference to the start button's start script
        [SerializeField] private StartScript m_StartScript;
        // Reference to the text to update (used for the visual checkbox)
        [SerializeField] private TextMeshProUGUI m_Text;
        // Is skip dialogue toggled?
        private bool m_SkipDialogue = true;

    // Update is called once per frame
    void Update()
    {
        // Go through the children
        for(int z = 0; z < transform.childCount; z++)
            // If the level is level one, make the toggle visible
            // Otherwise, make the toggle invisible
            transform.GetChild(z).gameObject.SetActive(m_StartScript.GetLevelName() == "LevelOne" || m_StartScript.GetLevelName() == "DialogSample");
    }

    public void ToggleSkipDialogue()
    {
        // Update the toggle
        m_SkipDialogue = !m_SkipDialogue;

        // If the option is toggled, the dialogue scene is skipped
        if(m_SkipDialogue)
        {
            m_StartScript.SetLevelName("LevelOne");
            m_Text.text = "X";
        }
        // Otherwise, the dialogue scene plays first
        else
        {
            m_StartScript.SetLevelName("DialogSample");
            m_Text.text = "";
        }
    }
}
