/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Built the system
        Manhattan: Refactoured for better encapsulation
*/

using System;
using UnityEngine;

[Serializable]
abstract public class BasePlayerManager
{
    // Protected variables
        [SerializeField] protected Transform m_SpawnPoint;
        [SerializeField] protected GameObject m_Instance;

    // Start is called before the first frame update
    void Start()
    {
        m_Instance = null;
    }

    // Sets movement and shooting
    abstract public void Setup();

    public Transform GetSpawnPoint() { return m_SpawnPoint; }
    public GameObject GetInstance() { return m_Instance; }
    public void SetInstance(GameObject obj) { m_Instance = obj; }
}
