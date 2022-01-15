// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupAttack : MonoBehaviour
{
    // Public variables
        // The multiplier of how much the player's attack power will increase
        public float m_AttackMultiplier = 2f;
        // How long the multipler will be active for
        public float m_MaxTime = 10f;

    // Private variables
        // Reference to the powerup's collider
        private PolygonCollider2D m_Collider;
        // Reference to the powerup's sprite renderer
        private SpriteRenderer m_Renderer;
        // Reference to the player's shooting script
        private PlayerShooting playerAttack;
        // How long the multiplier has currently been active for
        [SerializeField] private float m_CurrentTime;
        // Is the multiplier currently active?
        private bool m_Active;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<PolygonCollider2D>();
        m_Renderer = GetComponent<SpriteRenderer>();
        m_CurrentTime = 0f;
        m_Active = false;
    }

    // Increases the player's attack power for a limited time when they touch it
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the collider belongs to a player, increase their attack power
        if(other.CompareTag("Player"))
        {
            // If the multiplier hasn't been activated yet...
            if(!m_Active)
            {
                // ... activate the multiplier
                m_Active = true;

                // Get the player's rigidbody
                Rigidbody2D targetRigidBody = other.GetComponent<Rigidbody2D>();

                // Get the player's shooting script (holding the attack power)
                playerAttack = targetRigidBody.GetComponent<PlayerShooting>();

                // Increase the player's attack power
                playerAttack.m_Damage *= m_AttackMultiplier;

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
                // Revert the player's attack power
                playerAttack.m_Damage /= m_AttackMultiplier;

                // Destroy the object
                Destroy(gameObject);
            }
            // Otherwise, increment the current time
            else
                m_CurrentTime += Time.deltaTime;
        }
    }
}
