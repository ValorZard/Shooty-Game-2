/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueReader : MonoBehaviour
{
    // Protected variables
        // The file to read
        [SerializeField] protected TextAsset m_File;
        // The file reader
        protected StreamReader m_Reader;
        // The last read line
        protected string m_LastLine;

    protected void NextLine()
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

    protected DialogueClass GenerateDialogueFromLine()
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
}
