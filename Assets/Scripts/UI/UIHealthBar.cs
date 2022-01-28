/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    // Public varirables
        // The health script of the player
        public HealthScript m_HealthScript;
    
    // Protected variables
        // Reference to the child health bar meter
        protected Transform m_HealthBarMeter;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the health bar meter
        m_HealthBarMeter = gameObject.transform.Find("HealthBarMeter");
    }

    // Update is called once per frame
    void Update()
    {
        // Update the health bar meter
        UpdateHealthBarMeter();
    }

    // Update the health bar meter
    protected void UpdateHealthBarMeter()
    {
        // Grab the player's starting health
        float startingHealth = m_HealthScript.m_StartingHealth;

        // Grab the player's current health
        float currentHealth = m_HealthScript.GetCurrentHealth();

        // The percentage of the player's current health
        float percentHealth = currentHealth / startingHealth;

        // Scale the health bar meter according to the percentage
        m_HealthBarMeter.localScale = new Vector3(percentHealth, m_HealthBarMeter.localScale.y, m_HealthBarMeter.localScale.z);
    }
}