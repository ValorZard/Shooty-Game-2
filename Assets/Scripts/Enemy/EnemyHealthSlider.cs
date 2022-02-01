/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Wrote the base code
        Manhattan: Reformatted to work when applied directly to the slider
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSlider : MonoBehaviour
{
    // Public variables
        // The color of the health bar when full
        public Color m_FullHealthColor = Color.red;
        // The color of the health bar when empty
        public Color m_ZeroHealthColor;
    
    // Private variables
        // The enemy's health script
        HealthScript m_HealthScript;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the parent enemy's health script
        m_HealthScript = GetComponentInParent<HealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        // Grab the slider
        Slider slider = GetComponent<Slider>();

        // Set the slider's value
        slider.value = m_HealthScript.GetCurrentHealth();

        // Grab the slider's image
        Image image = transform.Find("Fill Area").Find("Fill").GetComponent<Image>();

        // The ratio of the current health and the starting health
        float ratio = m_HealthScript.GetCurrentHealth() / m_HealthScript.m_StartingHealth;
        
        // Fill bar with color and change depending on current health
        image.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, ratio);
    }
}
