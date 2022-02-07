/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Public variables
        // List of references to the players
        public GameObject[] m_Players;
        // List of references to the enemies
        public GameObject[] m_Enemies;
    
    // private variables
        // Reference to the UI manager
        private UIManager m_UIManager;
        // Reference to the game over screen
        private UIEndScreen m_GameOverScreen;
        // Reference to the win screen
        private UIEndScreen m_WinScreen;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the scripts from the children
        m_UIManager = GetComponentInChildren<UIManager>();
        m_GameOverScreen = transform.Find("GameOverScreen").GetComponent<UIEndScreen>();
        m_WinScreen = transform.Find("WinScreen").GetComponent<UIEndScreen>();

    }

    // Update is called once per frame
    void Update()
    {
        AssignObjectsToUI();

        // If the game over screen or win screen are active...
        if(m_GameOverScreen.m_Active
            || m_WinScreen.m_Active)
            // ... disable the players' scripts
            DisablePlayers();
    }

    // Assigns objects to the UI, if they haven't been assigned yet
    private void AssignObjectsToUI()
    {
        // Assign the players to the UI manager
        if(m_UIManager.m_Players.Length == 0)
            m_UIManager.m_Players = m_Players;

        // Assign the players to the game over screen
        if(m_GameOverScreen.m_Objects.Length == 0)
            m_GameOverScreen.m_Objects = m_Players;

        // Assign the enemies to the game over screen
        if(m_WinScreen.m_Objects.Length == 0)
            m_WinScreen.m_Objects = m_Enemies;
    }

    // Disables the players' scripts
    private void DisablePlayers()
    {
        // Go through the player list
        for(int i = 0; i < m_Players.Length; i++)
        {
            // Grab the player...
            GameObject player = m_Players[i];

            // ... and disable their movement scripts
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<PlayerShooting>().enabled = false;
            player.GetComponent<PlayerShootingMulti>().enabled = false;
            player.GetComponent<PlayerSpriteController>().enabled = false;
        }
    }
}
