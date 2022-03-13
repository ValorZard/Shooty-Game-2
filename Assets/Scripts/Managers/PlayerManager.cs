/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Built the system
        Manhattan: Refactoured for better encapsulation
*/

using System;
using UnityEngine;

[Serializable]
public class PlayerManager : BasePlayerManager
{
    // Private variables
        // Which player this is (1 or 2)
        private int m_PlayerNumber = 1;
        // Reference to the movement script
        private PlayerController m_Movement;
        // Reference to the shooting script
        private PlayerShooting m_Shooting;

    public override void Setup()
    {
        m_Movement = m_Instance.GetComponent<PlayerController>();
        m_Shooting = m_Instance.GetComponentInChildren<PlayerShooting>();

        m_Movement.SetPlayerNumber(m_PlayerNumber);
        m_Shooting.SetPlayerNumber(m_PlayerNumber);
    }

    public void SetPlayerNumber(int num) { m_PlayerNumber = num; }
}
