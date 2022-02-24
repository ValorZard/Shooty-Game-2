/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Public variables
        // List of references to the player
        public GameObject[] m_Players;
    
    // Private variables
        // List of references of the child player UIs
        [SerializeField] private GameObject[] m_PlayerUI;
        // Has the player been connected yet?
        [SerializeField] private bool[] m_Connected;

    // Start is called before the first frame update
    void Start()
    {
        // The length of the lists should be equal to the number of players in-game
        int listLength = transform.childCount;

        // Initializes the lists
        m_PlayerUI = new GameObject[listLength];
        m_Connected = new bool[listLength];

        // Goes through the children...
        for(int i = 0; i < listLength; i++)
        {
            m_PlayerUI[i] = transform.GetChild(i).gameObject;
            m_Connected[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the player list has objects
        if(m_Players.Length != 0)
        {
            // Connects the player UIs to their respective players
            ConnectUI();
        }
    }

    // Connects the UI with the player
    private void ConnectUI()
    {
        // Goes through the list of connectedness...
        for(int i = 0; i < m_Connected.Length; i++)
        {
            // If the index exceeds the total number of players...
            if(i >= m_Players.Length)
            {
                // ... deactivate the current UI
                m_PlayerUI[i].SetActive(false);
            }
            
            // Otherwise, if the player UI hasn't been connected yet, connect the UI
            else if(!m_Connected[i])
            {
                // Connects the healths
                ConnectUIHealth(i);

                // Connects the shield
                ConnectUIShield(i);

                // Connects the ammos
                ConnectUIAmmo(i);

                // Connects the powerups
                ConnectUIPowerup(i);

                // Make sure this only runs once
                m_Connected[i] = true;
            }
        }
    }

    // Connects the UI health with the player health
    private void ConnectUIHealth(int index)
    {
        // Grab the player UI's health bar script
        UIHealthBar uiHealthScript = m_PlayerUI[index].GetComponentInChildren<UIHealthBar>();

        // Grab the player's health script
        BaseHealthScript playerHealthScript = m_Players[index].GetComponent<BaseHealthScript>();

        // Assign the script to the player health script
        uiHealthScript.m_HealthScript = playerHealthScript;
    }

    // Connects the UI shield with the player shield
    private void ConnectUIShield(int index)
    {
        // Grab the player's UI's shield bar script
        UIShieldBar uiShieldScript = m_PlayerUI[index].GetComponentInChildren<UIShieldBar>();

        // Grab the player's shield child
        GameObject shield = m_Players[index].transform.Find("Shield").gameObject;

        // Grab the shield's health script
        BaseHealthScript shieldHealthScript = shield.GetComponent<BaseHealthScript>();

        // Assign the script to the shield health script
        uiShieldScript.m_HealthScript = shieldHealthScript;
    }

    // Connects the UI ammo with the player ammo
    private void ConnectUIAmmo(int index)
    {
        // add code here for when the players actually have ammo
    }

    // Connects the UI powerups with the player powerups
    private void ConnectUIPowerup(int index)
    {
        // Grab the player's UI's powerup bar script
        UIPowerupBar uiPowerupScript = m_PlayerUI[index].GetComponentInChildren<UIPowerupBar>();

        // Assign the player to the UI
        uiPowerupScript.m_Player = m_Players[index];
    }
}