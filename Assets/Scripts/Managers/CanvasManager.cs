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
        // List of references of the child player UIs
        [SerializeField] private GameObject[] m_PlayerUI;
        // Has the player been connected yet?
        [SerializeField] private bool[] m_Connected;

    // Start is called before the first frame update
    void Start()
    {
        // Initializes the lists
        m_PlayerUI = new GameObject[transform.childCount];
        m_Connected = new bool[transform.childCount];

        // Goes through the children...
        for(int i = 0; i < transform.childCount; i++)
        {
            m_PlayerUI[i] = transform.GetChild(i).gameObject;
            m_Connected[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Connects the player UIs to their respective players
        ConnectUI();
    }

    // Connects the UI with the player
    private void ConnectUI()
    {
        // Goes through the list of connectedness...
        for(int i = 0; i < m_Connected.Length; i++)
        {
            // If the player UI hasn't been connected yet, AND the player UI is active...
            if(!m_Connected[i] &&
                m_PlayerUI[i].activeSelf)
            {
                // If the index exceeds the total number of players...
                if(i > m_Players.Length)
                {
                    // ... deactivate the current UI
                    m_PlayerUI[i].SetActive(false);
                }
                // Otherwise, connect the UI
                else
                {
                    // Connects the healths
                    ConnectUIHealth(i);

                    // Connects the shield
                    ConnectUIShield(i);

                    // Connects the ammos
                    ConnectUIAmmo(i);

                    // Make sure this only runs once
                    m_Connected[i] = true;
                }
            }
        }
    }

    // Connects the UI health with the player health
    private void ConnectUIHealth(int index)
    {
        // Grab the player UI's health bar script
        UIHealthBar uiHealthScript = m_PlayerUI[index].GetComponentInChildren<UIHealthBar>();

        // Grab the player's health script
        HealthScript playerHealthScript = m_Players[index].GetComponent<HealthScript>();

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
        HealthScript shieldHealthScript = shield.GetComponent<HealthScript>();

        // Assign the script to the shield health script
        uiShieldScript.m_HealthScript = shieldHealthScript;
    }

    // Connects the UI ammo with the player ammo
    private void ConnectUIAmmo(int index)
    {
        // add code here for when the players actually have ammo
    }
}
