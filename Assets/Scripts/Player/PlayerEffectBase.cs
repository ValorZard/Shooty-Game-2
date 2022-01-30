/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerEffectBase : MonoBehaviour
{
    // Public variables
        // Is the powerup currently active?
        public bool m_Active = false;
        // How long the powerup will be active for
        public float m_MaxTime;
        // How long the powerup has currently been active for
        public float m_CurrentTime = 0f;
        // The multiplier of how much a player's stat will increase
        public float m_Multiplier;

    // The powerup is activated for the first time
    public void Activate(float multiplier, float maxTime)
    {
        // Set the powerup's value and duration
        m_Multiplier = multiplier;
        m_CurrentTime = 0f;
        m_MaxTime = maxTime;

        // Start tracking the current duration
        m_Active = true;

        // Change the player
        ChangePlayer();
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
                // ... change the player back to normal
                RevertPlayer();

                // Disable the script
                m_Active = false;
            }

            // Otherwise...
            else
                // ... increment the current time
                m_CurrentTime += Time.deltaTime;
        }
    }

    protected abstract void ChangePlayer();

    protected abstract void RevertPlayer();
}