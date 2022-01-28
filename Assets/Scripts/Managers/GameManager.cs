/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Spawning players
        Manhattan: Added camera control, added UI control, added XBOX controller compatibility
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Public variables
        // Reference to the player prefab
        public GameObject playerPrefab;
        // A collection of player managers
        public PlayerManager[] players;
        // Reference to the CameraController script
        public CameraController m_CameraController;
        // Reference to the CanvasManager script
        public CanvasManager m_CanvasManager;
        // Reference to the JoystickManager script
        public JoystickManager m_JoystickManager;

    private void Start()
    {
        SpawnPlayers();

        // Gives references of the players to the canvas manager
        // (has to be above the camera code for some reason??)
        AssignPlayersToCanvas();

        // Snap the camera's position and zoom to something appropriate for the preset players
        SetCameraTargets();
        m_CameraController.SetStartPositionAndSize();

        // Gives the second player reference to the joystick manager to update the control scheme based on controllers
        AssignPlayerToJoystick();
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

    private void AssignPlayersToCanvas()
    {
        // Initialize the list of players to give to the canvas manager
        GameObject[] targets = new GameObject[players.Length];

        // Goes through the list of players...
        for(int i = 0; i < targets.Length; i++)
        {
            // ... and adds the player to the canvas manager's list
            targets[i] = players[i].instance;
        }

        m_CanvasManager.m_Players = targets;
    }

    private void AssignPlayerToJoystick()
    {
        // If there is a second player...
        if(players.Length > 1)
        {
            // Give the joystick manager the second player
            m_JoystickManager.m_PlayerTwo = players[1].instance;
        }
    }
}
