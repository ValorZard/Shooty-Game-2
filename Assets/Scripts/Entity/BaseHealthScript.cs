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
        // Reference to the sprite
        private SpriteRenderer m_Renderer;
        // Has the character been damaged?
        private bool m_IsDamaged;
        // The original colour of the character
        private Color m_Color;

    // Start is called before the first frame update
    void Start()
    {
        // The health starts out as full
        m_CurrentHealth = m_StartingHealth;

        // Grab the renderer
        m_Renderer = GetComponentInChildren<SpriteRenderer>();

        // The character doesn't start damaged
        m_IsDamaged = false;

        // Grab the original colour
        m_Color = m_Renderer.color;
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
        // Perform the damaged animation
        m_IsDamaged = true;

        m_CurrentHealth -= amount;

        // If the current health is at or below zero...
        if(m_CurrentHealth <= 0f)
        {
            // ... set the health to exactly 0 (so it doesn't mess with the health UI)
            m_CurrentHealth = 0f;

            // Disable the character
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnDamage();
    }

    // The damaged animation
    private void OnDamage()
    {
        // If the character is damaged, flash red
        if(m_IsDamaged)
        {
            m_Renderer.color = Color.red;
            m_IsDamaged = false;
        }
        // Otherwise, return the colour to normal
        else
            m_Renderer.color = m_Color;
    }

    public float GetStartingHealth() { return m_StartingHealth; }
    public float GetCurrentHealth() { return m_CurrentHealth; }
}
