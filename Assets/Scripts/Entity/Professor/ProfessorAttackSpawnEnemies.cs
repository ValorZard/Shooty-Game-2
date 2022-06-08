/*
    Programmer: Manhattan Calabro

    This script contains the professor's attack to spawn enemies.
*/

using UnityEngine;

public class ProfessorAttackSpawnEnemies : ProfessorAttackBase
{
    // Private variables
        // Reference to the enemy to spawn
        [SerializeField] private GameObject m_EnemyPrefab;
        // Reference to the positions to spawn at
        [SerializeField] private Transform[] m_SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        m_TimeLeftActive = 0;
        m_TimeBeforeDestroy = 5;
    }

    // Spawn enemies at the given positions
    public void SpawnEnemies()
    {
        foreach(Transform trans in m_SpawnPoints)
            Instantiate(m_EnemyPrefab, trans.position, trans.rotation);
    }
}
