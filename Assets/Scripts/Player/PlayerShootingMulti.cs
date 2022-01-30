using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingMulti : MonoBehaviour
{
    // Private variables
        // Reference to the player's shooting script
        private PlayerShooting m_PlayerScript;
        // Reference to the player's multishot effect script
        private PlayerEffectMulti m_PlayerEffect;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerScript = gameObject.GetComponent<PlayerShooting>();
        m_PlayerEffect = gameObject.GetComponent<PlayerEffectMulti>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the fire button is pressed, AND the current delay is zero...
        if(Input.GetButton(m_PlayerScript.m_FireButton)
            && m_PlayerScript.m_CurrentDelay == 0)
        {
            // ... shoot the bullet
            Fire();
        }
    }

    // Instantiate the additional bullets
    private void Fire()
    {
        // Calculates the velocity between the cursor and the player
        Vector2 velocity = m_PlayerScript.CalculateVelocity();

        // Find the current angle
        float angle = Mathf.Atan(velocity.y / velocity.x) * Mathf.Rad2Deg;

        // Fire the first bullet
        m_PlayerScript.Fire(angle + m_PlayerEffect.m_Multiplier);

        // Fire the second bullet
        m_PlayerScript.Fire(angle - m_PlayerEffect.m_Multiplier);
    }
}