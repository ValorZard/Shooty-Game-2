// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDamage : PowerupBase
{
    // Public variables
        // The multiplier of how much the player's attack power will increase
        public float m_AttackMultiplier = 2f;
        // How long the multipler will be active for
        public float m_MaxTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<PolygonCollider2D>();
    }

    // Increases the player's attack power for a limited time when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's attack multiplier script
        PlayerEffectDamage multiplier = targetRigidbody.GetComponent<PlayerEffectDamage>();

        // Enable the player's attack multiplier script...
        // ... and assign the powerup's value and duration
        multiplier.Activate(m_AttackMultiplier, m_MaxTime);
    }
}
