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

        movement.SetPlayerNumber(playerNumber);
        shooting.SetPlayerNumber(playerNumber);
    }
}
