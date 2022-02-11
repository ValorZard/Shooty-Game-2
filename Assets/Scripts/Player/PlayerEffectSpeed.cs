/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectSpeed : PlayerEffectBase
{
    // Private variables
        // Reference to the player's movement script
        private PlayerController m_PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        m_PlayerScript = gameObject.GetComponentInParent<PlayerController>();
    }

    protected override void ChangePlayer()
    {
        m_PlayerScript.moveSpeed *= m_Multiplier;
    }

    protected override void RevertPlayer()
    {
        m_PlayerScript.moveSpeed /= m_Multiplier;
    }
}