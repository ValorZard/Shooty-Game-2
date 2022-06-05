/*
    Programmer: Manhattan Calabro
*/

public class UIAmmoText : UIBaseText
{
    // Private variables
        // The ammo script of the player
        private AmmoManager m_AmmoScript;

    // Update the ammo text
    protected override void UpdateValues()
    {
        // If the ammo script exists, run
        if(m_AmmoScript != null)
        {
            // Grab the player's starting ammo
            m_StartingValue = m_AmmoScript.GetMaxAmmo();

            // Grab the player's current ammo
            m_CurrentValue = m_AmmoScript.GetCurrentAmmo();

            UpdateDisplay();
        }
    }

    public void SetAmmoScript(AmmoManager script) { m_AmmoScript = script; }
}
