/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFlagUpdateTextbox : TeleportFlagBase
{
    // Private variables
        // Reference to the object to enable
        [SerializeField] private GameObject m_Object;

    // If the object isn't assigned yet, grab the one this script is attached to
    protected override void FlagStart()
    {
        if(m_Object == null)
            m_Object = this.gameObject;
    }

    // Has the teleporter been traveled through?
    public override bool FlagCondition()
    {
        return !GetActive();
    }

    // Enable the object
    protected override void FlagActivation()
    {
        m_Object.SetActive(true);
    }

    // No alternate action
    protected override void FlagAlternate() {}
}
