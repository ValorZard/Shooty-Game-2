/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHealthText : MonoBehaviour
{
    // Protected variables
        // The starting (max) value
        private float m_StartingValue;
        // The current value
        private float m_CurrentValue;
        // The health script of the player
        private BaseHealthScript m_HealthScript;
        // The text
        private TextMeshProUGUI m_Text;
    
    // Start is called before the first frame update
    void Start()
    {
        // Grab the children text
        m_Text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the values
        UpdateValues();
    }

    private void UpdateValues()
    {
        // If the health script exists, run
        if(m_HealthScript != null)
        {
            // Grab the player's starting health
            m_StartingValue = m_HealthScript.GetStartingHealth();

            // Grab the player's current health
            m_CurrentValue = m_HealthScript.GetCurrentHealth();

            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        m_Text.text = m_CurrentValue.ToString() + "/" + m_StartingValue.ToString();
    }

    public void SetHealthScript(BaseHealthScript script) { m_HealthScript = script; }
}
