/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public abstract class PowerupBase : MonoBehaviour
{
    // Protected variables
        // Reference to the powerup's collider
        protected Collider2D m_Collider;
        // The "value" of the powerup (how its used is dependent on the powerup)
        [SerializeField] protected float m_Value;
        // How long the powerup will be active for
        [SerializeField] protected float m_MaxTime;

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
