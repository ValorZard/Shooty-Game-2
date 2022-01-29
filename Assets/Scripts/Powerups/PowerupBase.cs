// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBase : MonoBehaviour
{
    // Private variables
        // Reference to the powerup's collider
        protected Collider2D m_Collider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the collider belongs to the player, perform some effect
        if(other.CompareTag("Player"))
        {
            // Grab the player's rigidbody
            Rigidbody2D targetRigidbody = other.GetComponent<Rigidbody2D>();

            // Perform some effect
            PlayerTrigger(targetRigidbody);

            // Destroy the object; the powerup has been used up
            Destroy(gameObject);
        }
    }

    // Performs some effect
    protected abstract void PlayerTrigger(Rigidbody2D targetRigidbody);
}
