/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectDamage : PlayerEffectBase
{
    // Private variables
        // Reference to the player's shooting script
        private PlayerShooting m_PlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerScript = gameObject.GetComponent<PlayerShooting>();
    }

    protected override void ChangePlayer()
    {
        m_PlayerScript.m_Damage *= m_Multiplier;
    }

    protected override void RevertPlayer()
    {
        m_PlayerScript.m_Damage /= m_Multiplier;
    }
}