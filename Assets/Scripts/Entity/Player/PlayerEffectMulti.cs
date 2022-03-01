/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectMulti : PlayerEffectBase
{
    // Private variables
        // Reference to the player's multishooting script
        private PlayerShootingMulti m_PlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerScript = transform.parent.GetComponentInChildren<PlayerShootingMulti>();
    }

    protected override void ChangePlayer()
    {
        m_PlayerScript.enabled = true;
        m_PlayerScript.SetOffset(m_Multiplier);
    }

    protected override void RevertPlayer()
    {
        m_PlayerScript.enabled = false;
    }
}