// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Public variables
        // The amount of health the character starts with
        public float m_StartingHealth = 100f;
    
    // Private variables
        // How much health the character currently has
        private float m_CurrentHealth;
        // Has the character been reduced beyond zero health yet?
        private bool m_Dead;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
    }

    // Increase the character's health
    public void Heal(float amount)
    {
        m_CurrentHealth += amount;

        // If the current health is greater than the starting health, set the current health to the starting health
        if(m_CurrentHealth > m_StartingHealth)
            m_CurrentHealth = m_StartingHealth;
    }

    // Decrease the character's health
    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;

        // If the current health is at or below zero and it has not yet been registered, call OnDeath
        if(m_CurrentHealth <= 0f && !m_Dead)
            OnDeath();
    }

    // Disable the character when it dies
    private void OnDeath()
    {
        // Set the flag so that this function is only called once
        m_Dead = true;

        // Turn the character off
        gameObject.SetActive(false);

        // note, have the ui say "game over" when the player is deactivated (obviously don't code that in here, since this is a general script for multiple entities)
    }
}
