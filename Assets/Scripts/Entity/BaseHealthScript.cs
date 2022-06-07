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
        // How long the character has been damaged for
        private float m_CurrentTime = -1;
        // How long the character should be damaged for
        private float m_MaxTime = 0.25f;

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
        // Heals the character (but not over their max health)
        m_CurrentHealth = Mathf.Min(m_CurrentHealth + amount, m_StartingHealth);
    }

    // Decrease the character's health
    public void TakeDamage(float amount)
    {
        // Perform the damaged animation
        m_IsDamaged = true;

        // Damages the character (but not below 0)
        m_CurrentHealth = Mathf.Max(m_CurrentHealth - amount, 0);

        // If the current health is at zero...
        if(m_CurrentHealth == 0f)
        {
            // If the character has a powerup spawner...
            if(GetComponent<PowerupSpawner>() != null)
                // ... spawn the powerup
                GetComponent<PowerupSpawner>().SpawnPowerup();

            // ... disable the character
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
            m_CurrentTime = 0;
        }
        // Otherwise, if the current time hasn't surpassed the max time, increment the time
        else if(m_CurrentTime != -1 && m_CurrentTime < m_MaxTime)
            m_CurrentTime += Time.deltaTime;
        // Otherwise, return the colour to normal
        else
        {
            m_Renderer.color = m_Color;
            m_CurrentTime = -1;
        }
    }

    public float GetStartingHealth() { return m_StartingHealth; }
    public float GetCurrentHealth() { return m_CurrentHealth; }
}
