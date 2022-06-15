/*
    Programmer: Manhattan Calabro

    This script contains the professor's attack to spawn explosive enemies.
*/

using UnityEngine;

public class ProfessorAttackSpawnExplosives : ProfessorAttackSpawnBase
{
    // Start is called before the first frame update
    void Start()
    {
        m_TimeLeftActive = 0;
        m_TimeBeforeDestroy = 5;
    }
}
