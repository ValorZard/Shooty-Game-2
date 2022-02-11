// Programmer: Manhattan Calabro

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
        m_PlayerScript = gameObject.GetComponentInParent<PlayerShootingMulti>();
    }

    protected override void ChangePlayer()
    {
        m_PlayerScript.enabled = true;
    }

    protected override void RevertPlayer()
    {
        m_PlayerScript.enabled = false;
    }
}