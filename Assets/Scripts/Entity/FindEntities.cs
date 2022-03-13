/*
    Programmers: Manhattan Calabro, Pedro Longo
        Manhattan: Created base class,
            redid AI tracking
        Pedro: Added tracking AI players
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEntities : MonoBehaviour
{
    // Private variables
        // List of players
        private List<GameObject> m_Players;
        // List of enemies
        private List<GameObject> m_Enemies;
        // List of player AIs
        private List<GameObject> m_PlayerAI;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the lists
        m_Players = new List<GameObject>();
        m_Enemies = new List<GameObject>();
        m_PlayerAI = new List<GameObject>();
    }

    public List<GameObject> GetPlayers() { return m_Players; }
    public List<GameObject> GetEnemies() { return m_Enemies; }
    public List<GameObject> GetPlayerAI() { return m_PlayerAI; }

    // Returns all players (both manual and AI)
    public List<GameObject> GetPlayersRefresh()
    {
        m_Players.Clear();
        m_Players = Refresh("Player");
        return m_Players;
    }

    // Returns all enemies
    public List<GameObject> GetEnemiesRefresh()
    {
        m_Enemies.Clear();
        m_Enemies = Refresh("Enemy");
        return m_Enemies;
    }

    // Returns all AI players
    public List<GameObject> GetPlayersAIRefresh()
    {
        m_PlayerAI.Clear();
        m_PlayerAI = GetPlayersRefresh();

        // Go through the list
        for(int i = 0; i < m_PlayerAI.Count; i++)
        {
            // If the player DOES NOT have an AI script...
            if(m_PlayerAI[i].GetComponent<PlayerAIController>() == null)
            {
                // ... remove the element
                m_PlayerAI.RemoveAt(i);

                // Go back an index
                i--;
            }
        }

        return m_PlayerAI;
    }

    // Returns all manual players
    public List<GameObject> GetPlayersManualRefresh()
    {
        m_Players.Clear();
        m_Players = GetPlayersRefresh();
        
        // Go through the list
        for(int i = 0; i < m_Players.Count; i++)
        {
            // If the player DOES have an AI script...
            if(m_Players[i].GetComponent<PlayerAIController>() != null)
            {
                // ... remove the element
                m_Players.RemoveAt(i);

                // Go back an index
                i--;
            }
        }

        return m_Players;
    }

    private List<GameObject> Refresh(string str)
    {
        // Initialize the list
        List<GameObject> objects = new List<GameObject>();

        // Grab the targets
        GameObject[] targets = GameObject.FindGameObjectsWithTag(str);

        // Go through the list
        foreach(GameObject t in targets)
            // If the "object" has a surface-level shield script...
            // ... then it's actually a shield; don't add it
            if(!t.GetComponent<ShieldTag>())
                objects.Add(t);
        
        return objects;
    }

    // Checks if the object is a player or the shield of a player
    public bool PlayerCheck(Collider2D other)
    {
        // The player should have the player tag
        bool first = other.CompareTag("Player");

        // The player should be valid
        bool second = GetPlayersRefresh().Contains(other.gameObject);

        // Return the result
        return first && second;
    }
}
