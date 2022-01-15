// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
{
    // Public variables
        // The multiplier of how much the player's speed will increase
        public float m_SpeedMultiplier = 2f;
        // How long the multiplier will be active for
        public float m_MaxTime = 10f;
    
    // Private variables
        // Reference to the powerup's collider
        private BoxCollider2D m_Collider;
        // Reference to the powerup's sprite renderer
        private SpriteRenderer m_Renderer;
        // Reference to the player's movement script
        private PlayerController playerMovement;
        // How long the multiplier has currently been active for
        [SerializeField] private float m_CurrentTime;
        // Is the multiplier currently active?
        private bool m_Active;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
        m_Renderer = GetComponent<SpriteRenderer>();
        m_CurrentTime = 0f;
        m_Active = false;
    }

    // Increases the player's speed for a limited time when they touch it
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the collider belongs to a player, increase their speed
        if(other.CompareTag("Player"))
        {
            // If the multiplier hasn't been activated yet...
            if(!m_Active)
            {
                // ... activate the multiplier
                m_Active = true;

                // Get the player's rigidbody
                Rigidbody2D targetRigidBody = other.GetComponent<Rigidbody2D>();

                // Get the player's movement script (holding the speed)
                playerMovement = targetRigidBody.GetComponent<PlayerController>();

                // Increases the player's speed
                playerMovement.moveSpeed *= m_SpeedMultiplier;

                // Hide the object; the powerup has been used up
                m_Renderer.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only track the time while the multiplier is active
        if(m_Active)
        {
            // If the current time is greater than the max time...
            if(m_CurrentTime > m_MaxTime)
            {
                // Revert the player's speed
                playerMovement.moveSpeed /= m_SpeedMultiplier;

                // Destroy the object
                Destroy(gameObject);
            }
            // Otherwise, increment the current time
            else
                m_CurrentTime += Time.deltaTime;
        }
    }
}
