/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleportFlagUpdateText : TeleportFlagBase
{
    // Private varibles
        // The Text object to change
        [SerializeField] private TextMeshProUGUI m_Text;
        // The replacement text
        [SerializeField] private string m_String;

    // Grab the text
    protected override void FlagStart()
    {
        // Only run if the text hasn't been assigned yet
        if(m_Text == null)
            m_Text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Is the teleporter disabled?
    public override bool FlagCondition()
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
