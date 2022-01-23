// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Public variables
        // List of references to the player
        public GameObject[] m_Players;
    
    // Private variables
        // Reference to the child player one UI
        private GameObject m_PlayerOneUI;
        // Reference to the child player two UI
        private GameObject m_PlayerTwoUI;
        // Has the player one UI been connected yet?
        private bool m_PlayerOneUIConnected;
        // Has the player two UI been connected yet?
        private bool m_PlayerTwoUIConnected;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerOneUI = transform.GetChild(0).gameObject;
        m_PlayerTwoUI = transform.GetChild(1).gameObject;
        
        // Make sure that the UIs will be connected later
        m_PlayerOneUIConnected = false;
        m_PlayerTwoUIConnected = false;
    }


    // Connects the player UIs to their respective players
    void Update()
    {
        // If the player one UI hasn't been conected yet, run
        if(!m_PlayerOneUIConnected)
        {
            // Grab the player one UI's health bar script
            UIHealthBar uiHealthScript = m_PlayerOneUI.GetComponentInChildren<UIHealthBar>();

            // Grab the player one's health script
            HealthScript playerHealthScript = m_Players[0].GetComponent<HealthScript>();

            // Assign the script to the player one health script
            uiHealthScript.m_HealthScript = playerHealthScript;

            // Make sure this only runs once
            m_PlayerOneUIConnected = true;
        }

        // If the player two UI hasn't been connected yet, AND if the player two UI is active, run
        if(!m_PlayerTwoUIConnected &&
            m_PlayerTwoUI.activeSelf)
        {
            // Continue if there is a second player in the list
            if(m_Players.Length > 1)
            {
                // Grab the player two UI's health bar script
                UIHealthBar uiHealthScript = m_PlayerTwoUI.GetComponentInChildren<UIHealthBar>();

                // Grab the player two's health script
                HealthScript playerHealthScript = m_Players[1].GetComponent<HealthScript>();

                // Assign the script to the player two health script
                uiHealthScript.m_HealthScript = playerHealthScript;

                // Make sure this only runs once
                m_PlayerTwoUIConnected = true;
            }

            // Otherwise, deactivate the player two UI
            else
            {
                m_PlayerTwoUI.SetActive(false);
            }
        }
    }
}
