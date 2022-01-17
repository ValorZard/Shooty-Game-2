// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectSpeed : MonoBehaviour
{
    // Private variables
        // The multiplier of how much the player's speed will increase
        private float m_SpeedMultiplier;
        // How long the powerup will be active for
        private float m_MaxTime;
        // Reference to the player's movement script
        private PlayerController m_PlayerMovement;
        // How long the powerup has currently been active for
        [SerializeField] private float m_CurrentTime;
        // Is the powerup currently active?
        private bool m_Active;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerMovement = gameObject.GetComponent<PlayerController>();
        m_CurrentTime = 0f;
        m_Active = false;
    }

    // The powerup is activated for the first time
    public void Activate(float speedMultiplier, float maxTime)
    {
        // Set the powerup's value and duration
        m_SpeedMultiplier = speedMultiplier;
        m_MaxTime = maxTime;

        // Start tracking the current duration
        m_Active = true;

        // Multiply the player's speed
        m_PlayerMovement.moveSpeed *= m_SpeedMultiplier;
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
                // ... revert the player's speed
                m_PlayerMovement.moveSpeed /= m_SpeedMultiplier;

                // Disable the script
                m_Active = false;
            }

            // Otherwise...
            else
                // ... increment the current time
                m_CurrentTime += Time.deltaTime;
        }
    }
}
