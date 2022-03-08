/*
    Programmer: Manhattan Calabro
*/

using System;
using UnityEngine;

[Serializable]
public class DialogueClass
{
    // Private variables
        // The character the message belongs to
        [SerializeField] private int m_CharNum;
        // The emotion to display
        [SerializeField] private int m_Emote;
        // The message to display
        [SerializeField] private string m_Message;

    public DialogueClass()
    {
        m_CharNum = 0;
        m_Emote = 0;
        m_Message = "";
    }

    public DialogueClass(int x, int y, string str)
    {
        m_CharNum = x;
        m_Emote = y;
        m_Message = str;
    }

    public int GetCharacterNumber() { return m_CharNum; }
    public int GetEmotion() { return m_Emote; }
    public string GetMessage() { return m_Message; }
}
