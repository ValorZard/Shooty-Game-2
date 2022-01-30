/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPowerupBar : MonoBehaviour
{
    // Public variables
        // The player to track
        public GameObject m_Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAttackPowerup();
        UpdateSpeedPowerup();
        UpdateMultiPowerup();
    }

    private void UpdateAttackPowerup()
    {
        // Grab the player's attack multiplier script
        PlayerEffectDamage script = m_Player.GetComponent<PlayerEffectDamage>();
        
        // If the player's script is active, reset the time of the attack multiplier powerup UI
        if(script.m_Active)
        {
            // Grab the attack multiplier powerup UI's script
            UIPowerupIcon icon = transform.Find("PowerupBarDamage").GetComponent<UIPowerupIcon>();

            // Set the icon's max time
            icon.m_MaxTime = script.m_MaxTime;

            // Set the icon's current time
            icon.m_CurrentTime = script.m_CurrentTime;
        }
    }

    private void UpdateSpeedPowerup()
    {
        // Grab the player's speed multiplier script
        PlayerEffectSpeed script = m_Player.GetComponent<PlayerEffectSpeed>();

        // If the player's script is active, reset the time of the speed multiplier powerup UI
        if(script.m_Active)
        {
            // Grab the speed multiplier powerup UI's script
            UIPowerupIcon icon = transform.Find("PowerupBarSpeed").GetComponent<UIPowerupIcon>();

            // Set the icon's max time
            icon.m_MaxTime = script.m_MaxTime;
            
            // Set the icon's current time
            icon.m_CurrentTime = script.m_CurrentTime;
        }
    }

    private void UpdateMultiPowerup()
    {
        // Grab the player's multishooting script
        PlayerEffectMulti script = m_Player.GetComponent<PlayerEffectMulti>();

        // If the player's script is active, reset the time of the multishooting powerup UI
        if(script.m_Active)
        {
            // Grab the multishooting powerup UI's script
            UIPowerupIcon icon = transform.Find("PowerupBarMulti").GetComponent<UIPowerupIcon>();

            // Set the icon's max time
            icon.m_MaxTime = script.m_MaxTime;
            
            // Set the icon's current time
            icon.m_CurrentTime = script.m_CurrentTime;
        }
    }
}