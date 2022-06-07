/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using UnityEngine.UI;
using System.IO;

/*
    This script is exclusively made for the level select screen.
    If a level hasn't been completed in the main game yet, then it is
    unselectable.
    This excludes the tutorials and the first level.
*/

public class LevelLock : MonoBehaviour
{
    // Private variables
        // Reference to the start script
        private StartScript m_StartScript;
        // Reference to the button
        private Button m_Button;
        // The file path
        private string m_Path = "Assets/Resources/LevelsUnlocked.txt";

    // Start is called before the first frame update
    void Start()
    {
        // Grab the start script
        m_StartScript = GetComponent<StartScript>();

        // Grab the button
        m_Button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the start script's level name isn't in the text file, make the button uninteractable
        m_Button.interactable = File.ReadAllText(m_Path).Contains(m_StartScript.GetLevelName());
    }
}
