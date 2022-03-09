/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueReader : MonoBehaviour
{
    // Private variables
        // The file to read
        [SerializeField] private TextAsset m_File;
        // The file reader
        private StreamReader m_Reader;
        // The last read line
        private string m_LastLine;

    // Start is called before the first frame update
    void Start()
    {
        // Open the file
        m_Reader = new StreamReader("Assets/Dialogue/" + m_File.name + ".txt");
    }

    // Update is called once per frame
    void Update()
    {
        // If the end of the file has been reached, close the file
        if(m_Reader.EndOfStream)
            Close();
    }

    private void NextLine()
    {
        // Continue until a valid line is found
        m_LastLine = "";
        while(m_LastLine == "")
        {
            // Grab the next line
            m_LastLine = m_Reader.ReadLine();

            // Only run if the last isn't blank
            if(m_LastLine != "")
                // If the line starts with '#', it's a comment (invalid)
                if(m_LastLine[0] == '#')
                    // Ignore the comment
                    m_LastLine = "";
        }
    }

    public DialogueClass GenerateDialogueFromLine()
    {
        // Try to grab a line
        NextLine();

        // If the string is valid...
        if(m_LastLine != null && m_LastLine != "")
        {
            // Grab the character number
            string sub = m_LastLine.Substring(0, m_LastLine.IndexOf(' '));
            m_LastLine = m_LastLine.Substring(m_LastLine.IndexOf(' ')+1);
            //int charNum = int.Parse(sub);
            int charNum = (int)(char.GetNumericValue(sub[0]));

            // Grab the emotion number
            sub = m_LastLine.Substring(0, m_LastLine.IndexOf(' '));
            m_LastLine = m_LastLine.Substring(m_LastLine.IndexOf(' ')+1);
            //int emote = int.Parse(sub);
            int emote = (int)(char.GetNumericValue(sub[0]));

            // Grab the message
            sub = m_LastLine;
            m_LastLine = "";

            // Return the dialogue
            return new DialogueClass(charNum, emote, sub);
        }
        // Otherwise, return null
        else
            return null;
    }

    public bool EndOfStream() { return m_Reader.EndOfStream; }
    public void Close()
    {
        // Close the stream
        m_Reader.Close();

        // Disable the script
        enabled = false;
    }
}
