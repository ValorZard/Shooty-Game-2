/*
    Programmers: Pedro Longo
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    // Private variables
    // Reference to the Player AI's movement script
    private PlayerAIController m_PlayerAI;
    private GameObject m_Player;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerAI = GetComponentInParent<PlayerAIController>();
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_PlayerAI.target = m_Player.transform;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // While a player stays within enemy sight...
        if (other.CompareTag("Enemy"))
        {
            // ... it will target them
            m_PlayerAI.SetDetection(true);

            // Set new target
            m_PlayerAI.target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If player exits enemy sight...
        if (other.CompareTag("Enemy"))
        {
            // ... it will stop pursuing
            m_PlayerAI.SetDetection(false);

            // Reset target
            m_PlayerAI.target = m_Player.transform;
        }
    }
}
