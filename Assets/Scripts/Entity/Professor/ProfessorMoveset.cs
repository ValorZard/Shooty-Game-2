/*
    Programmer: Manhattan Calabro

    This script contains references to the attacks the professor boss
    can perform.

    List of attacks:
     * Throws a barrel at the nearest player
     * Spawns 2 basic enemies
     * Spawns 2 beams, which despawn automatically after firing
     * Spawns 1 brute enemy
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorMoveset : MonoBehaviour
{
    // Private variables
        // Is the boss attacking?
        private bool m_IsAttacking = false;
        // Reference to the players
        private FindEntities m_Players;
        // Reference to the player closer to the boss
        private GameObject m_Closer;
        // Reference to the player farther from the boss
        private GameObject m_Farther;
        // Time before the attack activates
        private float m_TimeLeftActive;
        // Time before the attack destroys itself
        private float m_TimeBeforeDestroy;
        // Reference to the barrel-throwing script
        private ProfessorAttackThrowBarrel m_ThrowBarrel;
        // Reference to the enemy-spawning script
        private ProfessorAttackSpawnEnemies m_SpawnEnemies;
        // Reference to the beam-spawning script
        private ProfessorAttackSpawnBeams m_SpawnBeams;
        // Reference to the brute-spawning script
        private ProfessorAttackSpawnBrutes m_SpawnBrutes;
        // Reference to the explosive-spawning script
        private ProfessorAttackSpawnExplosives m_SpawnExplosives;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the players
        m_Players = GameObject.FindObjectOfType<FindEntities>();

        // Grab the attack scripts
        m_ThrowBarrel = GetComponent<ProfessorAttackThrowBarrel>();
        m_SpawnEnemies = GetComponent<ProfessorAttackSpawnEnemies>();
        m_SpawnBeams = GetComponent<ProfessorAttackSpawnBeams>();
        m_SpawnBrutes = GetComponent<ProfessorAttackSpawnBrutes>();
        m_SpawnExplosives = GetComponent<ProfessorAttackSpawnExplosives>();
    }

    // Update is called once per frame
    void Update()
    {
        // Refresh the players
        GetPlayers();

        // If the boss isn't attacking yet...
        if(!m_IsAttacking)
        {
            // ... choose a random attack
            int rng = Random.Range(0, 7);
            m_IsAttacking = true;
            if(rng == 0)
            {
                m_SpawnEnemies.Spawn();
                m_TimeLeftActive = m_SpawnEnemies.GetTimeLeftActive();
                m_TimeBeforeDestroy = m_SpawnEnemies.GetTimeBeforeDestroy();
            }
            else if(rng == 1 || rng == 2)
            {
                m_ThrowBarrel.ThrowBarrel(m_Closer);
                m_TimeLeftActive = m_ThrowBarrel.GetTimeLeftActive();
                m_TimeBeforeDestroy = m_ThrowBarrel.GetTimeBeforeDestroy();
            }
            else if(rng == 3 || rng == 4)
            {
                m_SpawnBeams.Spawn(m_Closer);
                m_TimeLeftActive = m_SpawnBeams.GetTimeLeftActive();
                m_TimeBeforeDestroy = m_SpawnBeams.GetTimeBeforeDestroy();
            }
            else if(rng == 5)
            {
                m_SpawnBrutes.Spawn();
                m_TimeLeftActive = m_SpawnBrutes.GetTimeLeftActive();
                m_TimeBeforeDestroy = m_SpawnBrutes.GetTimeBeforeDestroy();
            }
            else if(rng == 6)
            {
                m_SpawnExplosives.Spawn();
                m_TimeLeftActive = m_SpawnExplosives.GetTimeLeftActive();
                m_TimeBeforeDestroy = m_SpawnExplosives.GetTimeBeforeDestroy();
            }
        }

        // Otherwise, if the boss is attacking...
        else
        {
            // Count down while there is time left active
            if(m_TimeLeftActive > 0)
                m_TimeLeftActive -= Time.deltaTime;

            // Count down while there is time before destruction
            else if(m_TimeBeforeDestroy > 0)
                m_TimeBeforeDestroy -= Time.deltaTime;
            
            // Otherwise, the boss can attack again
            else
                m_IsAttacking = false;
        }
    }

    // Finds the closest and farthest players
    private void GetPlayers()
    {
        // Initialize the player list
        List<GameObject> players = m_Players.GetPlayersManualRefresh();

        // If there is only one player, the player is both targets
        if(players.Count == 1)
            m_Closer = m_Farther = players[0];

        // Otherwise, if there's two players...
        else if(players.Count == 2)
        {
            // Run if the first player is closer
            if(Vector3.Distance(transform.position, players[0].transform.position)
                <= Vector3.Distance(transform.position, players[1].transform.position))
            {
                m_Closer = players[0];
                m_Farther = players[1];
            }
            // Otherwise, the second player is closer
            else
            {
                m_Closer = players[1];
                m_Farther = players[0];
            }
        }
    }

    public void SetAttacking(bool b) { m_IsAttacking = b; }
}
