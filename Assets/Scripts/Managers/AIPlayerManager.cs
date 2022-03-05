/*
    Programmers: Pedro Longo
        Pedro: Built the system, based on PlayerManager
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AIPlayerManager
{
    // Private variables
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject instance;
    private PlayerAIController movement;
    private PlayerAIShooting shooting;

    // Start is called before the first frame update
    void Start()
    {
        instance = null;
    }

    // Sets movement and shooting for player
    public void Setup()
    {
        movement = instance.GetComponent<PlayerAIController>();
        shooting = instance.GetComponentInChildren<PlayerAIShooting>();
    }

    public Transform GetSpawnPoint() { return spawnPoint; }

    public GameObject GetInstance() { return instance; }
    public void SetInstance(GameObject obj) { instance = obj; }
}

