// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Public variables
        // The amount of health the enemy starts with.
        public float m_StartingHealth = 100f;
    
    // Private variables
        // How much health the enemy currently has.
        private float m_CurrentHealth;
        // Has the enemy been reduced beyond zero health yet?
        private bool m_Dead;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
    }

    // Adjust the enemy's current health
    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;

        // If the current health is at or below zero and it has not yet been registered, call OnDeath
        if(m_CurrentHealth <= 0f && !m_Dead)
        {
            OnDeath();
        }
    }

    // Disable the enemy when it dies
    private void OnDeath()
    {
        // Set the flag so that this function is only called once.
        m_Dead = true;

        // Turn the enemy off.
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
