/*
    Programmers: Cuervo94, Manhattan Calabro
        Cuervo: Spawning players
        Manhattan: Added camera control
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Public variables
        // Reference to the CameraController script
        public CameraController m_CameraController;
        // Reference to the player prefab
        public GameObject playerPrefab;
        // A collection of player managers
        public PlayerManager[] players;

    private void Start()
    {
        SpawnPlayers();

        SetCameraTargets();

        // Snap the camera's position and zoom to something appropriate for the preset players
        m_CameraController.SetStartPositionAndSize();
    }

    private void SpawnPlayers()
    {
        //loop will instantiate number of players (in this case 2) to spawn locations
        for (int i = 0; i < players.Length; i++)
        {
            players[i].instance =
                Instantiate(playerPrefab, players[i].spawnPoint.position, players[i].spawnPoint.rotation) as GameObject;

            //Defines player number for input
            players[i].playerNumber = i + 1;
            players[i].Setup();
        }
    }

    private void SetCameraTargets()
    {
        // Create a collection of transforms the same size as the number of players
        Transform[] targets = new Transform[players.Length];

        // For each of these transforms...
        for(int i = 0; i < targets.Length; i++)
        {
            // ... set it to the appropriate player transform
            targets[i] = players[i].instance.transform;
        }

        // These are the targets the camera should follow
        m_CameraController.m_Targets = targets;
    }
}
