using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public variables
    public GameObject playerPrefab;
    public PlayerManager[] players;

    private void Start()
    {
        SpawnPlayers();
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
}
