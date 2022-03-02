/*
    Programmer: Manhattan Calabro
*/

public class UIAmmoBar : UIBaseBar
{
    // Private variables
        // The ammo script of the player
        private AmmoManager m_AmmoScript;

    // Update the ammo bar meter
    protected override void UpdateValues()
    {
        // If the ammo script exists, run
        if(m_AmmoScript != null)
        {
            // Grab the player's starting ammo
            startingValue = m_AmmoScript.GetMaxAmmo();

            // Grab the player's current ammo
            currentValue = m_AmmoScript.GetCurrentAmmo();

            UpdateDisplay();
        }
    }

    public void SetAmmoScript(AmmoManager script) { m_AmmoScript = script; }
}
