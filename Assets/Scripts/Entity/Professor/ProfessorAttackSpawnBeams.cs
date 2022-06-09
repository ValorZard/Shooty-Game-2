/*
    Programmer: Manhattan Calabro

    This script contains the professor's attack to spawn beams.
*/

using UnityEngine;

public class ProfessorAttackSpawnBeams : ProfessorAttackBase
{
    // Private variables
        // Refernece to the beam to spawn
        [SerializeField] private GameObject m_BeamPrefab;
        // Reference to the positions to spawn at
        [SerializeField] private Transform[] m_SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        m_TimeLeftActive = 1;
        m_TimeBeforeDestroy = 0.5f;
    }

    // Spawn beams at the given positions
    public void SpawnBeams(GameObject player)
    {
        foreach(Transform trans in m_SpawnPoints)
        {
            GameObject beam = Instantiate(m_BeamPrefab, trans.position, trans.rotation);
            beam.transform.rotation = LocalLookAt2D(player, beam.transform);
            beam.transform.localScale = new Vector3(beam.transform.localScale.x,
                                                    beam.transform.localScale.y * 2,
                                                    beam.transform.localScale.z);
        }
    }
}
