/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Added player following
        Manhattan: Refactoured for better encapsulation
*/

using UnityEngine;

public class EnemyDetector : AIDetector
{
    // Private variables
        // Reference to the player
        private GameObject m_Player;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the scripts
        m_Movement = GetComponentInParent<PlayerAIController>();
        m_Shooting = GetComponentInParent<PlayerAIShooting>();

        // Follow the player around
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_Movement.target = m_Player.transform;
    }

    protected override void ResetTarget()
    {
        // Follow the player around again
        m_Movement.target = m_Player.transform;
    }
}
