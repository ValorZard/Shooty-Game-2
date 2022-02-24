/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Built the system
        Manhattan: Refactoured for better encapsulation
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerManager
{
    // Private variables
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private int m_PlayerNumber;
        [SerializeField] private GameObject instance;
        private PlayerController movement;
        private PlayerShooting shooting;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = null;
    }

    // Sets movement and shooting for player
    public void Setup()
    {
        movement = instance.GetComponent<PlayerController>();
        shooting = instance.GetComponent<PlayerShooting>();

        movement.SetPlayerNumber(m_PlayerNumber);
        shooting.SetPlayerNumber(m_PlayerNumber);
    }

    public Transform GetSpawnPoint() { return spawnPoint; }
    public void SetPlayerNumber(int num) { m_PlayerNumber = num; }
    public GameObject GetInstance() { return instance; }
    public void SetInstance(GameObject obj) { instance = obj; }
}
