/*
    Programmer: Manhattan Calabro

    This script is the base for the professor's spawning attacks.
*/

using UnityEngine;

public class ProfessorAttackSpawnBase : ProfessorAttackBase
{
    // Protected variables
        // Reference to the object to spawn
        [SerializeField] protected GameObject m_Prefab;
        // Reference to the positions to spawn at
        [SerializeField] protected Transform[] m_SpawnPoints;

    // Spawns the objects at the given positions
    public void Spawn()
    {
        foreach(Transform trans in m_SpawnPoints)
            Instantiate(m_Prefab, trans.position, trans.rotation);
    }
}
