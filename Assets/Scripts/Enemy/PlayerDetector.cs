/*
    Programmers: Srayan Jana, Pedro Longo, Manhattan Calabro
        Srayan: refactored code to its own class
        Manhattan: Reformatted for readability,
                   fixed enemy targeting error
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private EnemyController m_Enemy;

    // Start is called before the first frame update
    void Start()
    {
        m_Enemy = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Whenever a player enters enemy sight...
        if(other.CompareTag("Player"))
        {   
            // ... it will target them
            m_Enemy.playerInSight = true;

            // Set new target
            m_Enemy.target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If player exits enemy sight...
        if(other.CompareTag("Player"))
        {
            // ... it will stop pursuing
            m_Enemy.playerInSight = false;

            // Reset target
            m_Enemy.target = null;
        }
    }
}