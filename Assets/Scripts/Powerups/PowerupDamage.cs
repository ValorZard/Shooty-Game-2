/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDamage : PowerupBase
{
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<PolygonCollider2D>();

        // The multiplier of how much the player's attack power will increase
        m_Value = 2f;

        // How long the powerup will be active for
        m_MaxTime = 10f;
    }

    // Increases the player's attack power for a limited time when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's attack multiplier script
        PlayerEffectDamage multiplier = targetRigidbody.GetComponent<PlayerEffectDamage>();

        // Enable the player's attack multiplier script...
        // ... and assign the powerup's value and duration
        multiplier.Activate(m_Value, m_MaxTime);
    }
}