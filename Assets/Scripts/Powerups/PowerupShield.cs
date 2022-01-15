// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShield : MonoBehaviour
{
    // Public variables
        // Prefab of the shield
        public Rigidbody2D m_Shield;
        // The amount of shield the player will gain if touched (acts as extra health or an overheal)
        public float m_ShieldAmount = 25f;
    
    // Private variables
        // Reference to the powerup's collider
        private PolygonCollider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<PolygonCollider2D>();
    }

    // Gives the player a shield when they touch it
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the collider belongs to the player, give them a shield
        if(other.CompareTag("Player"))
        {
            // Grab the player's rigidbody
            Rigidbody2D targetRigidBody = other.GetComponent<Rigidbody2D>();

            // Spawn a shield that follows the player around
            Rigidbody2D shieldInstance = Instantiate(m_Shield, transform.position, transform.rotation) as Rigidbody2D;

            // Grab the shield's health script
            HealthScript health = shieldInstance.GetComponent<HealthScript>();

            // Assign the shield's max health
            health.m_StartingHealth = m_ShieldAmount;

            // Grab the shield's tracking script
            ShieldTrack trackingScript = shieldInstance.GetComponent<ShieldTrack>();

            // Assign the player to track
            trackingScript.m_Player = targetRigidBody;

            // Destroy the object; the powerup has been used up
            Destroy(gameObject);
        }
    }
}
