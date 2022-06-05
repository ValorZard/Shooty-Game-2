/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using System.IO;

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
        CharacterSelect[] list = FindObjectsOfType<CharacterSelect>();

        // Find the first and second players
        CharacterSelect first = null;
        CharacterSelect second = null;
        foreach(CharacterSelect target in list)
        {
            if(target.GetPlayerNumber() == 1)
                first = target;
            else if(target.GetPlayerNumber() == 2)
                second = target;
        }

        // Transcribe the information into text
        if(first.IsFirst())
            text += "1s";
        else
            text += "1m";
        // Only run if there are two players
        if(list.Length > 1)
        {
            text += "\n";
            if(second.IsFirst())
                text += "2s";
            else
                text += "2m";
        }

        File.WriteAllText(m_Path, text);

        // Move to the next scene
        m_Script.SetLevelName(m_Script.GetLevelName() + m_Script.GetText());
        m_Script.StartAndWrite();
    }

    public string GetPath() { return m_Path; }
}
