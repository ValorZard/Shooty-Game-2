// Programmer: Pedro Longo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Public variables
    // The amount of health the character starts with
    public float m_StartingHealth = 100f;
    public Slider m_Slider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.red;
    public Color m_ZeroHealthColor;

    // Private variables
    // How much health the character currently has
    [SerializeField] private float m_CurrentHealth;
    // Has the character been reduced beyond zero health yet?
    private bool m_Dead;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI();
    }

    // Decrease the character's health
    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;

        //Update health bar
        SetHealthUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath
        if (m_CurrentHealth <= 0f && !m_Dead)
            OnDeath();
    }

    private void SetHealthUI()
    {
        //Set the slider's value
        m_Slider.value = m_CurrentHealth;

        //Fill bar with color and change depending on current health
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }

    // Disable the character when it dies
    private void OnDeath()
    {
        // Set the flag so that this function is only called once
        m_Dead = true;

        // Turn the character off
        gameObject.SetActive(false);
    }

    // Returns the player's current health
    public float GetCurrentHealth()
    {
        return m_CurrentHealth;
    }
}
