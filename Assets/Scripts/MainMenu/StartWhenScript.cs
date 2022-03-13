/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using System.IO;

public class StartWhenScript : StartScript
{
    // Private variables
        // Reference to the dialogue manager
        private DialogueManager m_Manager;
        // Reference to the fade script
        private ObjectFadeIn m_Fade;

    // Start is called before the first frame update
    void Start()
    {
        m_Manager = GameObject.FindObjectOfType<DialogueManager>();
        m_Fade = GameObject.FindObjectOfType<ObjectFadeIn>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the scripts are complete...
        if(!m_Manager.enabled && !m_Fade.enabled)
        {
            // Set the correct scene
            m_LevelName += File.ReadAllText(m_Path);

            // Move to the next scene
            StartGame();
        }
    }
}
