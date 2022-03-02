/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Private variables
        // Reference to the player and enemy lsits
        private FindEntities m_Entities;
        // List of references of the child player UIs
        [SerializeField] private GameObject[] m_PlayerUI;
        // Has the player been connected yet?
        [SerializeField] private bool m_Connected;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the lists
        m_Entities = GetComponentInParent<FindEntities>();

        // The length of the lists should be equal to the number of players in-game
        int listLength = transform.childCount;

        // Initializes the list
        m_PlayerUI = new GameObject[listLength];
        for(int i = 0; i < listLength; i++)
        {
            m_PlayerUI[i] = transform.GetChild(i).gameObject;
        }

        // The player(s) haven't been connected yet
        m_Connected = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_Entities.GetPlayersRefresh();

        // Only run if the player list has objects AND the players haven't been connected yet
        if(m_Entities.GetPlayers().Count != 0
            && !m_Connected)
        {
            // Connects the player UIs to their respective players
            ConnectUI();
        }
    }

    // Connects the UI with the player
    private void ConnectUI()
    {
        // Connect the first player
        ConnectUIHealth(0);
        ConnectUIShield(0);
        ConnectUIAmmo(0);
        ConnectUIPowerup(0);

        // If the second player exists...
        if(m_Entities.GetPlayers().Count > 1)
        {
            // ... connect the second player
            ConnectUIHealth(1);
            ConnectUIShield(1);
            ConnectUIAmmo(1);
            ConnectUIPowerup(1);
        }
        // Otherwise, disable the second player UI
        else
            m_PlayerUI[1].SetActive(false);
        
        m_Connected = true;
    }

    // Connects the UI health with the player health
    private void ConnectUIHealth(int index)
    {
        // Grab the player UI's health bar script
        UIHealthBar uiHealthScript = m_PlayerUI[index].GetComponentInChildren<UIHealthBar>();

        // Grab the player's health script
        BaseHealthScript playerHealthScript = m_Entities.GetPlayers()[index].GetComponent<BaseHealthScript>();

        // Assign the script to the player health script
        uiHealthScript.SetHealthScript(playerHealthScript);
    }

    // Connects the UI shield with the player shield
    private void ConnectUIShield(int index)
    {
        // Grab the player's UI's shield bar script
        UIShieldBar uiShieldScript = m_PlayerUI[index].GetComponentInChildren<UIShieldBar>();

        // Grab the shield's health script
        BaseHealthScript shieldHealthScript = m_Entities.GetPlayers()[index].transform.Find("Shield").GetComponent<BaseHealthScript>();

        // Assign the script to the shield health script
        uiShieldScript.SetHealthScript(shieldHealthScript);
    }

    // Connects the UI ammo with the player ammo
    private void ConnectUIAmmo(int index)
    {
        // Grab the player's UI's ammo bar script
        UIAmmoBar uiAmmoScript = m_PlayerUI[index].GetComponentInChildren<UIAmmoBar>();

        // Grab the player's ammo script
        AmmoManager playerAmmoScript = m_Entities.GetPlayers()[index].GetComponentInChildren<AmmoManager>();

        // Assign the script to the player ammo script
        uiAmmoScript.SetAmmoScript(playerAmmoScript);
    }

    // Connects the UI powerups with the player powerups
    private void ConnectUIPowerup(int index)
    {
        // Grab the player's UI's powerup bar script
        UIPowerupBar uiPowerupScript = m_PlayerUI[index].GetComponentInChildren<UIPowerupBar>();

        // Assign the player to the UI
        uiPowerupScript.SetPlayer(m_Entities.GetPlayers()[index]);
    }
}