/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerEffectBase : MonoBehaviour
{
    // Protected variables
        // The multiplier of how much a player's stat will change
        protected float m_Multiplier;

    // Private variables
        // Is the powerup currently active?
        private bool m_Active = false;
        // How long the powerup will be active for
        private float m_MaxTime;
        // How long the powerup has currently been active for
        private float m_CurrentTime = 0f;

    // The powerup is activated for the first time
    public void Activate(float multiplier, float maxTime)
    {
        // Set the powerup's value and duration
        m_Multiplier = multiplier;
        m_CurrentTime = 0f;
        m_MaxTime = maxTime;

        // Only change the player if the powerup isn't already active (grabbing a new one just resets duration)
        if(!m_Active)
            ChangePlayer();

        // Start tracking the current duration
        m_Active = true;
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

    // Applies an effect to the player
    protected abstract void ChangePlayer();

    // Removes the effect from the player
    protected abstract void RevertPlayer();

    public bool GetActive() { return m_Active; }
    public float GetMaxTime() { return m_MaxTime; }
    public float GetCurrentTime() { return m_CurrentTime; }
    public float GetMultiplier() { return m_Multiplier; }
}