/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Wrote the base code
        Manhattan: Reformatted to work when applied directly to the slider,
            refactoured for better encapsulation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSlider : MonoBehaviour
{
    // Private variables
        // Reference to the enemy's health script
        private BaseHealthScript m_HealthScript;
        // The color of the health bar when full
        [SerializeField] private Color m_FullHealthColor = Color.red;
        // The color of the health bar when empty
        [SerializeField] private Color m_ZeroHealthColor;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the parent enemy's health script
        m_HealthScript = GetComponentInParent<BaseHealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthUI();
    }

    // Updates the enemy's health UI
    private void SetHealthUI()
    {
        // Grab the slider
        Slider slider = GetComponent<Slider>();

        // Set the slider's value
        slider.value = m_HealthScript.GetCurrentHealth();

        // Grab the slider's image
        Image image = transform.Find("Fill Area").Find("Fill").GetComponent<Image>();

        // The ratio of the current health and the starting health
        float ratio = m_HealthScript.GetCurrentHealth() / m_HealthScript.GetCurrentHealth();
        
        // Fill bar with color and change depending on current health
        image.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, ratio);
    }
}
