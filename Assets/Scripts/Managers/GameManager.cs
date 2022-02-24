/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Spawning players,
               added win condition and scene manager
        Manhattan: Added camera control,
                   added UI control,
                   added XBOX controller compatibility,
                   added win screen,
                   reformatted for readability
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Public variables
        // Reference to the player prefab
        public GameObject m_PlayerPrefab;
        // A collection of player managers
        public PlayerManager[] m_Players;
        //Reference to enemies
        public GameObject[] m_Enemies;
        // Reference to the CameraController script
        public CameraController m_CameraController;
        // Reference to the CanvasManager script
        public CanvasManager m_CanvasManager;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayers();
        m_Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Gives references of the players to the canvas manager
        // (has to be above the camera code for some reason??)
        AssignPlayersToCanvas();
        AssignEnemiesToCanvas();

        // Snap the camera's position and zoom to something appropriate for the preset players
        SetCameraTargets();
        m_CameraController.SetStartPositionAndSize();
    }

    private void SpawnPlayers()
    {
        //loop will instantiate number of players (in this case 2) to spawn locations
        for (int i = 0; i < m_Players.Length; i++)
        {
            m_Players[i].instance =
                Instantiate(m_PlayerPrefab, m_Players[i].spawnPoint.position, m_Players[i].spawnPoint.rotation) as GameObject;

            //Defines player number for input
            m_Players[i].playerNumber = i + 1;
            m_Players[i].Setup();
        }
    }

    private void AssignPlayersToCanvas()
    {
        // Initialize the list of players to give to the canvas manager
        GameObject[] targets = new GameObject[m_Players.Length];

        // Goes through the list of players...
        for(int i = 0; i < targets.Length; i++)
        {
            // ... and adds the player to the canvas manager's list
            targets[i] = m_Players[i].instance;
        }

        m_CanvasManager.m_Players = targets;
    }

    private void AssignEnemiesToCanvas()
    {
        m_CanvasManager.m_Enemies = m_Enemies;
    }

    private void SetCameraTargets()
    {
        // Create a collection of transforms the same size as the number of players
        Transform[] targets = new Transform[m_Players.Length];

        // For each of these transforms...
        for(int i = 0; i < targets.Length; i++)
        {
            // ... set it to the appropriate player transform
            targets[i] = m_Players[i].instance.transform;
        }

        // These are the targets the camera should follow
        m_CameraController.SetTargets(targets);
    }
}
