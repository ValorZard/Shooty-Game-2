/*
    Programmer: Manhattan Calabro

    This script contains the professor's attack to spawn beams.
*/

using UnityEngine;

public class ProfessorAttackSpawnBeams : ProfessorAttackSpawnBase
{
    // Private variables
        // The amount of damage done
        [SerializeField] private float m_Damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        m_TimeLeftActive = 1;
        m_TimeBeforeDestroy = 0.5f;
    }

    // Spawn beams at the given positions
    public void Spawn(GameObject player)
    {
        foreach(Transform trans in m_SpawnPoints)
        {
            GameObject beam = Instantiate(m_Prefab, trans.position, trans.rotation);
            beam.transform.rotation = LocalLookAt2D(player, beam.transform);
            beam.transform.localScale = new Vector3(beam.transform.localScale.x / 2,
                                                    beam.transform.localScale.y * 2,
                                                    beam.transform.localScale.z);
            beam.GetComponent<BossStandardAttack>().SetDamage(m_Damage);
        }
    }
}
