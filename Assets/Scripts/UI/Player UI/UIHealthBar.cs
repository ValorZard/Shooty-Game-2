/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : UIBaseBar
{
    // Protected variables
        // The health script of the player
        protected BaseHealthScript m_HealthScript;

    // Private variables
        // At what limit does the bar change colour?
        private float m_Limit = 0.3f;
        // Reference to the image
        private Image m_Image;
        // The original colour of the bar
        private Color m_Colour;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the image
        m_Image = GetComponent<Image>();

        // Grab the colour
        m_Colour = m_Image.color;
    }

    // Update the health bar meter
    protected override void UpdateValues()
    {
        // If the health script exists, run
        if(m_HealthScript != null)
        {
            // Grab the player's starting health
            startingValue = m_HealthScript.GetStartingHealth();

            // Grab the player's current health
            currentValue = m_HealthScript.GetCurrentHealth();

            UpdateDisplay();

            // If the health is under the limit, change the colour to red
            if(currentValue / startingValue < m_Limit)
                m_Image.color = Color.red;
            else
                m_Image.color = m_Colour;
        }
    }


    public BaseHealthScript GetHealthScript() { return m_HealthScript; }
    public void SetHealthScript(BaseHealthScript script) { m_HealthScript = script; }
}