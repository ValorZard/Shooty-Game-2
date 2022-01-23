// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    // Public varirables
        // The health script of the player
        public HealthScript m_HealthScript;
    
    // Private variables
        // Reference to the child health bar meter
        private Transform m_HealthBarMeter;
        // Reference to the child health bar background
        private Transform m_HealthBarBackground;
        // The starting width of the health bar meter
        private float m_StartingWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the health bar meter
        m_HealthBarMeter = gameObject.transform.Find("HealthBarMeter");

        // Fetch the health bar background
        m_HealthBarBackground = gameObject.transform.Find("HealthBarBackground");

        // Fetch the health bar meter's width
        m_StartingWidth = m_HealthBarMeter.gameObject.GetComponent<RectTransform>().rect.width;
    }

    // Update the health bar meter
    void Update()
    {
        // Grab the player's starting health
        float startingHealth = m_HealthScript.m_StartingHealth;

        // Grab the player's current health
        float currentHealth = m_HealthScript.GetCurrentHealth();

        // The percentage of the player's current health
        float percentHealth = currentHealth / startingHealth;

        // Scale the health bar meter according to the percentage
        m_HealthBarMeter.localScale = new Vector3(percentHealth, percentHealth, m_HealthBarMeter.localScale.z);
    }
}
