using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Public variables
        // List of references to the player
        public GameObject[] m_Players;
    
    // private variables
        // Reference to the UI manager
        private UIManager m_UIManager;
        // Reference to the game over screen
        private UIGameOver m_GameOver; 

    // Start is called before the first frame update
    void Start()
    {
        // Grab the scripts from the children
        m_UIManager = GetComponentInChildren<UIManager>();
        m_GameOver = GetComponentInChildren<UIGameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        // Assign the players to the UI manager
        m_UIManager.m_Players = m_Players;

        // Assign the players to the game over screen
        m_GameOver.m_Players = m_Players;
    }
}
