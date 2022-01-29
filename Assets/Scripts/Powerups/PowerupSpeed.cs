// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : PowerupBase
{
    // Public variables
        // The multiplier of how much the player's speed will increase
        public float m_SpeedMultiplier = 2f;
        // How long the multiplier will be active for
        public float m_MaxTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
    }

    // Increases the player's speed for a limited time when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's speed multiplier script
        PlayerEffectSpeed multiplier = targetRigidbody.GetComponent<PlayerEffectSpeed>();

        // Enable the player's speed multiplier script...
        // ... and assign the powerup's value and duration
        multiplier.Activate(m_SpeedMultiplier, m_MaxTime);
    }
}
