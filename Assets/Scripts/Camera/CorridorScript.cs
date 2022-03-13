/*
    Programmers: Derek Chan, Sarah Harkins, Srayan Jana, Manhattan Calabro
        Derek, Sarah: Base code
        Srayan: Added Text management
        Manhattan: Removed door glitch,
            refactoured player-finding
*/

// The primary goal of this script is to detect when all players are in the corridor and move the camera and open the door when they are.

using System.Collections;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only run if the collider detects a player
        if (m_Players.PlayerCheck(other))
        {
            Tilemap tilemap = this.GetComponent<Tilemap>();

            List<GameObject> players = m_Players.GetPlayersManualRefresh();

            // If there's only 1 player, the player is in the corridor and is ready to move into the next room
            if(players.Count == 1)
            {
                // If the collider DOES NOT belong to an AI...
                if(other.GetComponent<PlayerAIController>() == null)
                    // ... it's a player; have the camera follow the player
                    this.transform.parent.gameObject.GetComponent<RoomScript>().moveCamToRoom();
            }
            // This part is for 2 player support
            else
            {
                int playersInCorridor = 0;
                // Find all colliders in the corridor
                Collider2D[] colliders = Physics2D.OverlapBoxAll(tilemap.cellBounds.center, new Vector2((float) tilemap.size[0], (float) tilemap.size[1]), 0.0f);
                foreach (Collider2D collider in colliders)
                    if (m_Players.PlayerCheck(collider))
                        // Count players in the corridor
                        playersInCorridor++;
                if (playersInCorridor == players.Count)
                    // If both players are ready to move into the next room
                    this.transform.parent.gameObject.GetComponent<RoomScript>().moveCamToRoom();
            }
        }
    }

    // Controls the opening of doors
    private void OnTriggerStay2D(Collider2D other)
    {
        // If the collider detects a player...
        if(m_Players.PlayerCheck(other))
        {
            // ... disable the door
            transform.parent.gameObject.GetComponent<RoomScript>().disableDoor();
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
