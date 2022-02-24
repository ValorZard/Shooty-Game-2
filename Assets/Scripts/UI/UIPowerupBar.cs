/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPowerupBar : MonoBehaviour
{
    // Private variables
        // The player to track
        private GameObject m_Player;

    // Update is called once per frame
    void Update()
    {
        // If the player exists, run
        if(m_Player != null)
        {
            UpdateAttackPowerup();
            UpdateSpeedPowerup();
            UpdateMultiPowerup();
        }
    }

    private void UpdateAttackPowerup()
    {
        // Grab the player's attack multiplier script
        PlayerEffectDamage script = m_Player.GetComponentInChildren<PlayerEffectDamage>();

        UpdatePowerup(script, "PowerupBarDamage");
    }

    private void UpdateSpeedPowerup()
    {
        // Grab the player's speed multiplier script
        PlayerEffectSpeed script = m_Player.GetComponentInChildren<PlayerEffectSpeed>();

        UpdatePowerup(script, "PowerupBarSpeed");
    }

    private void UpdateMultiPowerup()
    {
        // Grab the player's multishooting script
        PlayerEffectMulti script = m_Player.GetComponentInChildren<PlayerEffectMulti>();

        UpdatePowerup(script, "PowerupBarMulti");
    }

    private void UpdatePowerup(PlayerEffectBase script, string str)
    {
        // If the player's script is active, reset the time of the powerup UI
        if(script.GetActive())
        {
            // Grab the powerup UI's script
            UIPowerupIcon icon = transform.Find(str).GetComponent<UIPowerupIcon>();

            // Set the icon's max time
            icon.SetMaxTime(script.GetMaxTime());

            // Set the icon's current time
            icon.SetCurrentTime(script.GetCurrentTime());
        }
    }

    public void SetPlayer(GameObject obj) { m_Player = obj; }
}