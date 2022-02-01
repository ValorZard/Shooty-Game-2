/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    // Public variables
        // List of references to the players
        public GameObject[] m_Players;

    // Update is called once per frame
    void Update()
    {
        // Only run if the player list has objects
        if(m_Players.Length != 0)
        {
            // Go through the list of players
            for(int i = 0; i < m_Players.Length; i++)
            {
                // If a player is active...
                if(m_Players[i].activeSelf)
                {
                    // End the method early
                    return;
                }
            }
            
            // Otherwise, all players are dead, activate the game over screen
            ShowGameOverScreen();
        }
    }

    // Activates the game over screen
    private void ShowGameOverScreen()
    {
        // Go through all the children of this object
        for(int i = 0; i < transform.childCount; i++)
        {
            // Enable the child
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Hides the game over screen
    private void HideGameOverScreen()
    {
        // Go through all the children of this object
        for(int i = 0; i < transform.childCount; i++)
        {
            // Disable the child
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
