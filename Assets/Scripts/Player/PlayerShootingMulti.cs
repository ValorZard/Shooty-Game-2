// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingMulti : MonoBehaviour
{
    // Public variables
        // The angle the additional bullets will be shot at
        public float m_Angle;
        // How long the powerup will be active for
        public float m_MaxTime;
        // Is the powerup currently active?
        public bool m_Active;
        // How long the powerup has currently been active for
        public float m_CurrentTime;
    
    // Private variables
        // Reference to the player's shooting script
        private PlayerShooting m_PlayerAttack;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerAttack = gameObject.GetComponent<PlayerShooting>();
        m_CurrentTime = 0f;
        m_Active = false;
    }

    public void Activate(float angle, float maxtime)
    {
        // Set the powerup's angle and duration
        m_Angle = angle;
        m_MaxTime = maxtime;

        // Start tracking the current duration
        m_Active = true;
    }

    // Update is called once per frame
    void Update()
    {
        // If the fire button is pressed, AND the current delay is zero...
        if(Input.GetButton(m_PlayerAttack.m_FireButton)
            && m_PlayerAttack.m_CurrentDelay == 0)
        {
            // ... shoot the bullet
            Fire();
        }

        // Don't take anything else from the regular player shooting script, since everything else is just delay handling
    }

    // Instantiate the additional bullets
    private void Fire()
    {
        // Calculates the velocity between the cursor and the player
        Vector2 velocity = m_PlayerAttack.CalculateVelocity();

        // Find the current angle
        float angle = Mathf.Atan(velocity.y / velocity.x) * Mathf.Rad2Deg;

        // Fire the first bullet
        m_PlayerAttack.Fire(angle + m_Angle);

        // Fire the second bullet
        m_PlayerAttack.Fire(angle - m_Angle);
    }
}