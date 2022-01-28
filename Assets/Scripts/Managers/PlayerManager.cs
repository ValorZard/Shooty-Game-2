/*
    Programmer: Pedro Longo
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerManager
{
    //local variables
    public Transform spawnPoint;
    public int playerNumber;
    public GameObject instance;

    //private variables
    private PlayerController movement;
    private PlayerShooting shooting;

    // Sets movement and shooting for player
    public void Setup()
    {
        movement = instance.GetComponent<PlayerController>();
        shooting = instance.GetComponent<PlayerShooting>();

        movement.playerNumber = playerNumber;
        shooting.playerNumber = playerNumber;
    }
}
