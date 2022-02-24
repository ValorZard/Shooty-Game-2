/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    // Private variables
        // The amount of health the character starts with
        [SerializeField] private float m_StartingHealth = 100f;
        // How much health the character currently has
        [SerializeField] private float m_CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_StartingHealth;
    }

    // Increase the character's health
    public void Heal(float amount)
    {
        m_CurrentHealth += amount;

        // If the current health is greater than the starting health...
        if(m_CurrentHealth > m_StartingHealth)
            // ... set the current health to the starting health
            m_CurrentHealth = m_StartingHealth;
    }

    // Decrease the character's health
    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;

        // If the current health is at or below zero...
        if(m_CurrentHealth <= 0f)
        {
            // ... set the health to exactly 0 (so it doesn't mess with the health UI)
            m_CurrentHealth = 0f;

            // Disable the player
            gameObject.SetActive(false);
        }
    }

    public float GetStartingHealth() { return m_StartingHealth; }
    public float GetCurrentHealth() { return m_CurrentHealth; }
}
