/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportFlagUpdateText : TeleportFlagBase
{
    // Private varibles
        // The Text object to change
        [SerializeField] private Text m_Text;
        // The replacement text
        [SerializeField] private string m_String;

    // No starting actions
    protected override void FlagStart() {}

    // Is the teleporter disabled?
    protected override bool FlagCondition()
    {
        return !GetActive();
    }

    // Replace the text
    protected override void FlagActivation()
    {
        m_Text.text = m_String;
    }

    // No alternate action
    protected override void FlagAlternate() {}
}
