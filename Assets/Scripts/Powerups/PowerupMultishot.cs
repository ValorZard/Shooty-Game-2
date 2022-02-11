/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMultishot : PowerupBase
{
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();

        // The angle the additional bullets will be shot at
        m_Value = 15f;

        // How long the powerup will be active for
        m_MaxTime = 10f;
    }

    // Gives the player a multishot for a limited time when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's multishot script
        PlayerEffectMulti multishot = targetRigidbody.GetComponentInChildren<PlayerEffectMulti>();

        // Enable the player's multishot script...
        // ... and assign the powerup's value and duration
        multishot.Activate(m_Value, m_MaxTime);
    }
}