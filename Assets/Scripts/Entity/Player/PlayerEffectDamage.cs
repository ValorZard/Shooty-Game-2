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
        m_PlayerScript = transform.parent.GetComponentInChildren<PlayerShooting>();
    }

    protected override void ChangePlayer()
    {
        m_PlayerScript.SetDamage(m_PlayerScript.GetDamage() * m_Multiplier);
    }

    protected override void RevertPlayer()
    {
        m_PlayerScript.SetDamage(m_PlayerScript.GetDamage() / m_Multiplier);
    }
}