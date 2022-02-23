// Made by Derek Chan and Sarah Harkins

// The primary goal of this script is to detect when all players are in the corridor and move the camera and open the door when they are.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CorridorScript : MonoBehaviour
{

    private GameObject[] players;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Tilemap tilemap = this.GetComponent<Tilemap>();
            players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length > 1) // This part is for 2 player support
            {
                int playersInCorridor = 0;
                // Find all colliders in the corridor
                Collider2D[] colliders = Physics2D.OverlapBoxAll(tilemap.cellBounds.center, new Vector2((float) tilemap.size[0], (float) tilemap.size[1]), 0.0f);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject.tag == "Player")
                    {
                        // Count players in the corridor
                        playersInCorridor++;
                    }
                }
                if (playersInCorridor == players.Length)
                {
                    // If both players are ready to move into the next room
                    this.transform.parent.gameObject.GetComponent<RoomScript>().moveCamToRoom();
                    this.transform.parent.gameObject.GetComponent<RoomScript>().disableDoor();
                }
            }
            else
            {
                // If there's only 1 player, the player is in the corridor and is ready to move into the next room
                this.transform.parent.gameObject.GetComponent<RoomScript>().moveCamToRoom();
                this.transform.parent.gameObject.GetComponent<RoomScript>().disableDoor();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Reenable the door. As long as there is some corridor on both sides of the door, players will always be able to open the door the
        // second player is stuck behind (and also won't be able to progress without the second player)
        this.transform.parent.gameObject.GetComponent<RoomScript>().enableDoor();
    }
}
