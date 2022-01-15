// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHeal : MonoBehaviour
{
    // Public variables
        // The amount of health the player will regain if touched
        public float m_Health = 50f;
    
    // Private variables
        // Reference to the powerup's collider
        private CircleCollider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<CircleCollider2D>();
    }

    // Heals the player when they touch it
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the collider belongs to the player, heal them
        if(other.CompareTag("Player"))
        {
            // Grab the player's rigidbody
            Rigidbody2D targetRigidBody = other.GetComponent<Rigidbody2D>();

            // Grab the player's health script
            HealthScript playerHealth = targetRigidBody.GetComponent<HealthScript>();

            // Heal the player
            playerHealth.Heal(m_Health);

            // Destroy the object; the health pack has been used up
            Destroy(gameObject);
        }
    }
}
