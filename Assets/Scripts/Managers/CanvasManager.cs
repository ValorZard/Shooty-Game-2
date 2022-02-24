/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Private variables
        // List of references to the players
        private GameObject[] m_Players;
        // List of references to the enemies
        private GameObject[] m_Enemies;
        // Reference to the UI manager
        private UIManager m_UIManager;
        // Reference to the game over screen
        private UIEndScreen m_GameOverScreen;
        // Reference to the win screen
        private UIEndScreen m_WinScreen;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the arrays
        m_Players = new GameObject[0];
        m_Enemies = new GameObject[0];

        // Grab the scripts from the children
        m_UIManager = GetComponentInChildren<UIManager>();
        m_GameOverScreen = transform.Find("GameOverScreen").GetComponent<UIEndScreen>();
        m_WinScreen = transform.Find("WinScreen").GetComponent<UIEndScreen>();

    }

    // Update is called once per frame
    void Update()
    {
        AssignObjectsToUI();

        // If the win screen is active...
        if(m_WinScreen.GetActive())
            // ... disable the players' scripts
            DisablePlayers();
    }

    // Assigns objects to the UI, if they haven't been assigned yet
    private void AssignObjectsToUI()
    {
        // Assign the players to the UI manager
        if(m_UIManager.GetPlayers().Length == 0)
            m_UIManager.SetPlayers(m_Players);

        // Assign the players to the game over screen
        if(m_GameOverScreen.GetObjects().Length == 0)
            m_GameOverScreen.SetObjects(m_Players);

        // Assign the enemies to the game over screen
        if(m_WinScreen.GetObjects().Length == 0)
            m_WinScreen.SetObjects(m_Enemies);
    }

    // Disables the players' scripts
    private void DisablePlayers()
    {
        // Go through the player list
        for(int i = 0; i < m_Players.Length; i++)
        {
            // Disable the player
            m_Players[i].GetComponentInChildren<PlayerDisable>().DisablePlayer();
        }
    }

    public void SetPlayers(GameObject[] obj) { m_Players = obj; }
    public void SetEnemies(GameObject[] obj) { m_Enemies = obj; }
}
