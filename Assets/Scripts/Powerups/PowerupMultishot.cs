// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMultishot : PowerupBase
{
    // Public variables
        // The angle the additional bullets will be shot at
        public float m_Angle = 15f;
        // How long the powerup will be active for
        public float m_MaxTime = 10f;
    
    // Private variables
        // Reference to the powerup's sprite renderer
        private SpriteRenderer m_Renderer;
        // Reference to the player's multishooting script
        private PlayerShootingMulti playerAttack;
        // How long the powerup has currently been active for
        [SerializeField] private float m_CurrentTime;
        // Is the powerup currently active?
        private bool m_Active;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
        m_Renderer = GetComponent<SpriteRenderer>();
        m_CurrentTime = 0f;
        m_Active = false;
    }

    // Gives the player a multishot for a limited time when they touch it
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the collider belongs to the player, give them a multishot for a limited time
        if(other.CompareTag("Player"))
        {
            // If the powerup hasn't been activated yet...
            if(!m_Active)
            {
                // ... activate the powerup
                m_Active = true;

                // Get the player's rigidbody
                Rigidbody2D targetRigidBody = other.GetComponent<Rigidbody2D>();

                // Get the player's multishooting script
                playerAttack = targetRigidBody.GetComponent<PlayerShootingMulti>();

                // Activate the script
                playerAttack.enabled = true;

                // Assign the angle to shoot at
                playerAttack.m_Angle = m_Angle;

                // Hide the object; the powerup has been used up
                m_Renderer.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only track the time while the powerup is active
        if(m_Active)
        {
            // If the current time is greater than the max time...
            if(m_CurrentTime > m_MaxTime)
            {
                // Disable the multishot script
                playerAttack.enabled = false;

                // Destroy the object
                Destroy(gameObject);
            }
            // Otherwise, increment the current time
            else
                m_CurrentTime += Time.deltaTime;
        }
    }

    // Gives the player a multishot for a limited time when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's multishot script
        PlayerShootingMulti multishot = targetRigidbody.GetComponent<PlayerShootingMulti>();

        // Enable the player's multishot script...
        // ... and assign the powerup's value and duration
        multishot.Activate(m_Angle, m_MaxTime);
    }
}