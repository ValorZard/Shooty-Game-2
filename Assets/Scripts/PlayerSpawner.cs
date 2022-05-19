/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerSpawner : MonoBehaviour
{
    // Private variables
        // The file path
        private string m_Path = "Assets/Resources/PlayerType.txt";
        // Reference to the Sally prefab
        [SerializeField] private GameObject m_SallyPrefab;
        // Reference to the Molly prefab
        [SerializeField] private GameObject m_MollyPrefab;
        // Reference to the default player prefab (backup)
        [SerializeField] private GameObject m_DefaultPrefab;
        // Spawn points
        [SerializeField] private Transform[] m_Spawns;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the players
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        // The text from the file
        string[] text = File.ReadAllLines(m_Path);

        // Go through the spawn point list
        for(int z = 0; z < m_Spawns.Length; z++)
        {
            // The spawned player
            GameObject player;

            // Only run if the text line exists
            if(text.Length > z)
            {
                if(text[z].Contains("s"))
                    player = Instantiate(m_SallyPrefab, m_Spawns[z].position, m_SallyPrefab.transform.rotation);
                else if(text[z].Contains("m"))
                    player = Instantiate(m_MollyPrefab, m_Spawns[z].position, m_MollyPrefab.transform.rotation);
                else
                    player = Instantiate(m_DefaultPrefab, m_Spawns[z].position, m_DefaultPrefab.transform.rotation);
            }
            else
                player = Instantiate(m_DefaultPrefab, m_Spawns[z].position, m_DefaultPrefab.transform.rotation);
            
            // Assign the correct player number
            player.GetComponent<PlayerController>().SetPlayerNumber(z + 1);
            player.GetComponentInChildren<PlayerShooting>().SetPlayerNumber(z + 1);
        }
    }
}
