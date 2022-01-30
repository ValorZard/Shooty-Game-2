/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHeal : PowerupBase
{
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<CircleCollider2D>();

        // The amount of health the player will regain if touched
        m_Value = 50f;
    }

    // Heals the player when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's health script
        HealthScript playerHealth = targetRigidbody.GetComponent<HealthScript>();

        // Heal the player
        playerHealth.Heal(m_Value);
    }
}