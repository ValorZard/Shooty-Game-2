/*
    Programmer: Manhattan Calabro
*/

public class UIHealthBar : UIBaseBar
{
    // Protected variables
        // The health script of the player
        protected BaseHealthScript m_HealthScript;

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
        }
    }

    public void SetHealthScript(BaseHealthScript script) { m_HealthScript = script; }
}