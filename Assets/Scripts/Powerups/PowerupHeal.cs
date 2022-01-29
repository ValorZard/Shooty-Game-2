// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHeal : PowerupBase
{
    // Public variables
        // The amount of health the player will regain if touched
        public float m_Health = 50f;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<CircleCollider2D>();
    }

    // Heals the player when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's health script
        HealthScript playerHealth = targetRigidbody.GetComponent<HealthScript>();

        // Heal the player
        playerHealth.Heal(m_Health);
    }
}
