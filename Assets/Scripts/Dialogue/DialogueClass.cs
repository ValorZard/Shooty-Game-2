/*
    Programmer: Manhattan Calabro, Srayan Jana
        Srayan Jana: Refactored certain things
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

    public DialogueClass(int charNum = 0, int emote = 0, string message = "")
    {
        m_CharNum = charNum;
        m_Emote = emote;
        m_Message = message;
    }

    public int GetCharacterNumber() { return m_CharNum; }
    public void SetCharacterNumber(int num) { m_CharNum = num; }
    public int GetEmotion() { return m_Emote; }
    public void SetEmotion(int num) { m_Emote = num; }
    public string GetMessage() { return m_Message; }
    public void SetMessage(string str) { m_Message = str; }
}
