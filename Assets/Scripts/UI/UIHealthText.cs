/*
    Programmer: Manhattan Calabro
*/

public class UIHealthText : UIBaseText
{
    // Private variables
        // The health script of the player
        private BaseHealthScript m_HealthScript;

    // Update the health text
    protected override void UpdateValues()
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

    public void SetHealthScript(BaseHealthScript script) { m_HealthScript = script; }
}
