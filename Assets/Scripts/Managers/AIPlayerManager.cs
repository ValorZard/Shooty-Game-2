/*
    Programmers: Pedro Longo
        Pedro: Built the system, based on PlayerManager
*/

using System;

[Serializable]
public class AIPlayerManager : BasePlayerManager
{
    // Private variables
        // Reference to the movement script
        private PlayerAIController m_Movement;
        // Reference to the shooting script
        private PlayerAIShooting m_Shooting;

    public override void Setup()
    {
        m_Movement = m_Instance.GetComponent<PlayerAIController>();
        m_Shooting = m_Instance.GetComponentInChildren<PlayerAIShooting>();
    }
}

