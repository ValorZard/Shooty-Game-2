/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ConfirmAndWrite : MonoBehaviour
{
    // Private variables
        // The file path
        private string m_Path = "Assets/Resources/PlayerType.txt";
        // The start script
        private StartAndWriteScript m_Script;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the start script
        m_Script = GetComponent<StartAndWriteScript>();
    }

    public void UpdatePlayerType()
    {
        // The text to write
        string text = "";

        // Find all active confirmation scripts
        CharacterConfirmation[] list = FindObjectsOfType<CharacterConfirmation>();

        // Transcribe the information into text
        if(list[0].IsFirst())
            text += "1s";
        else
            text += "1m";
        // Only run if there are two players
        if(list.Length > 1)
        {
            text += "\n";
            if(list[1].IsFirst())
                text += "2s";
            else
                text += "2m";
        }

        File.WriteAllText(m_Path, text);

        // Move to the next scene
        m_Script.StartAndWrite();
    }

    public string GetPath() { return m_Path; }
}
