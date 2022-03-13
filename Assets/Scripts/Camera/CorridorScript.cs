/*
    Programmers: Derek Chan, Sarah Harkins, Srayan Jana, Manhattan Calabro
        Derek, Sarah: Base code
        Srayan: Added Text management
        Manhattan: Removed door glitch,
            refactoured player-finding
*/

// The primary goal of this script is to detect when all players are in the corridor and move the camera and open the door when they are.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CorridorScript : MonoBehaviour
{
    // Private variables
        // Reference to the players
        private FindEntities m_Players;
    
    // Start is called before the first frame update
    void Start()
    {
        // Grab the players
        m_Players = GameObject.FindObjectOfType<FindEntities>();
    }

    // For singleplayer
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only run if the collider detects a player
        if (m_Players.PlayerCheck(other))
        {
            List<GameObject> players = m_Players.GetPlayersManualRefresh();

            if(players.Count == 1)
            {
                // If the collider DOES NOT belong to an AI...
                if(other.GetComponent<PlayerAIController>() == null)
                    // ... it's a player; have the camera follow the player
                    GetComponentInParent<RoomScript>().moveCamToRoom();

                // Disable the door regardless
                GetComponentInParent<RoomScript>().disableDoor();
            }
        }
    }

    // For multiplayer
    private void OnTriggerStay2D(Collider2D other)
    {
        // Only run if the collider detects a player
        if(m_Players.PlayerCheck(other))
        {
            List<GameObject> players = m_Players.GetPlayersManualRefresh();

            // For singleplayer
            if(players.Count == 1)
            {
                // Disable the door
                GetComponentInParent<RoomScript>().disableDoor();
            }

            // For multiplayer
            else //if(players.Count == 2)
            {
                // Find all colliders in the corridor
                Tilemap tilemap = GetComponent<Tilemap>();
                Collider2D[] colliders = Physics2D.OverlapBoxAll(tilemap.cellBounds.center, new Vector2((float) tilemap.size[0], (float) tilemap.size[1]), 0.0f);
                
                // The number of players currently in the corridor
                int playersInCorridor = 0;

                // Go through the list
                foreach (Collider2D collider in colliders)
                    // If the collider belongs to a player...
                    if (m_Players.PlayerCheck(collider))
                        // ... increment the counter
                        playersInCorridor++;

                // If the number of players in the corridor is the same as the number of active players...
                if (playersInCorridor == players.Count)
                {
                    // ... move into the next room
                    GetComponentInParent<RoomScript>().moveCamToRoom();
                    GetComponentInParent<RoomScript>().disableDoor();
                }
            }
        }
    }

    // Controls the closing of doors
    private void OnTriggerExit2D(Collider2D other)
    {
        // If a player left the collider...
        if(m_Players.PlayerCheck(other))
            // Reenable the door. As long as there is some corridor on both sides of the door, players will always be able to open the door the
            // second player is stuck behind (and also won't be able to progress without the second player)
            transform.parent.gameObject.GetComponent<RoomScript>().enableDoor();
    }
}
