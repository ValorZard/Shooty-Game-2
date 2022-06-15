/*
    Programmer: Manhattan Calabro

    This script contains the professor's attack to spawn brutes.
*/

using UnityEngine;

public class ProfessorAttackSpawnBrutes : ProfessorAttackSpawnBase
{
    // Start is called before the first frame update
    void Start()
    {
        m_TimeLeftActive = 0;
        m_TimeBeforeDestroy = 5;
    }
}