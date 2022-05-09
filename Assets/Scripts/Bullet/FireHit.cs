/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHit : MonoBehaviour
{
    // Private variables
        // The amount of damage over time
        [SerializeField] private float m_Damage;

    private void OnTriggerStay2D(Collider2D other)
    {
        // Grab the entity's health script
        BaseHealthScript health = other.GetComponentInChildren<BaseHealthScript>();

        // If the entity has a health script...
        if(health != null)
        {
            // Deal damage to the entity
            health.TakeDamage(m_Damage);
        }
    }
}
