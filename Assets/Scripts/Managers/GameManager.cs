/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Spawning players,
               added win condition and scene manager
        Manhattan: Added camera control,
                   added UI control,
                   added XBOX controller compatibility,
                   added win screen,
                   reformatted for readability,
                   refactoured for better encapsulation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Private variables
        // Reference to the player prefab
        [SerializeField] private GameObject m_PlayerPrefab;
        // A collection of player managers
        [SerializeField] private PlayerManager[] m_Players;
        // Reference to the player AI prefab
        [SerializeField] private GameObject m_AIPlayerPrefab;
        // Player AI
        [SerializeField] private AIPlayerManager m_PlayerAI;
        // Reference to the CameraController script
        [SerializeField] private CameraController m_CameraController;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayers();

        //If player equals 1, then spawn AI player
        //CODE
        if (m_Players.Length == 1)
        {
            SpawnAIPlayer();
        }

        // Snap the camera's position and zoom to something appropriate for the preset players
        SetCameraTargets();
        m_CameraController.SetStartPositionAndSize();
    }

    private void SpawnPlayers()
    {
        //loop will instantiate number of players (in this case 2) to spawn locations
        for (int i = 0; i < m_Players.Length; i++)
        {
            m_Players[i].SetInstance(Instantiate(m_PlayerPrefab, m_Players[i].GetSpawnPoint().position, m_Players[i].GetSpawnPoint().rotation));

            //Defines player number for input
            m_Players[i].SetPlayerNumber(i + 1);
            m_Players[i].Setup();
            Debug.Log("ASSIGNED INPUT TO PLAYER " + i);
        }
    }

    private void SpawnAIPlayer()
    {
        m_PlayerAI.SetInstance(Instantiate(m_AIPlayerPrefab, m_PlayerAI.GetSpawnPoint().position, m_PlayerAI.GetSpawnPoint().rotation));
    }

    private void SetCameraTargets()
    {
        // Create a collection of transforms the same size as the number of players
        Transform[] targets = new Transform[m_Players.Length];

        // For each of these transforms...
        for(int i = 0; i < targets.Length; i++)
        {
            // ... set it to the appropriate player transform
            targets[i] = m_Players[i].GetInstance().transform;
        }

        // These are the targets the camera should follow
        m_CameraController.SetTargets(targets);
    }
}