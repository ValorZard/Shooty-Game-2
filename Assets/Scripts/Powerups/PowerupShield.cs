// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShield : PowerupBase
{
    // Public variables
        // The amount of shield the player will gain if touched (acts as extra health or an overheal)
        public float m_ShieldAmount = 50f;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<PolygonCollider2D>();
    }

    // Gives the player a shield when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's shield child
        GameObject shield = targetRigidbody.transform.Find("Shield").gameObject;

        // Activate the shield
        shield.SetActive(true);

        // Get the shield's health script
        HealthScript health = shield.GetComponent<HealthScript>();

        // Heal the shield to max (in case the shield was previously depleted)
        health.Heal(m_ShieldAmount);
    }
}
