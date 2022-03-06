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
        [SerializeField] private List<GameObject> m_Players;
        // List of enemies
        [SerializeField] private List<GameObject> m_Enemies;
    //Player AI
        [SerializeField] private List<GameObject> m_PlayerAI;

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

    public List<GameObject> GetPlayersRefresh()
    {
        m_Players.Clear();
        m_Players = Refresh("Player");
        return m_Players;
    }

    public List<GameObject> GetEnemiesRefresh()
    {
        m_Enemies.Clear();
        m_Enemies = Refresh("Enemy");
        return m_Enemies;
    }

    public List<GameObject> GetPlayerAIRefresh()
    {
        m_PlayerAI.Clear();
        m_PlayerAI = GetPlayersRefresh();

        // Go through the list
        for(int i = 0; i < m_PlayerAI.Count; i++)
        {
            // If the player has an AI script...
            if(m_PlayerAI[i].GetComponent<PlayerAIController>() != null)
            {
                // ... remove the element
                m_PlayerAI.RemoveAt(i);

                // Go back an index
                i--;
            }
        }

        return m_PlayerAI;
    }

    private List<GameObject> Refresh(string str)
    {
        // Initialize the list
        List<GameObject> objects = new List<GameObject>();

        // Grab the targets
        GameObject[] targets = GameObject.FindGameObjectsWithTag(str);

        // Go through the list
        for(int i = 0; i < targets.Length; i++)
            // If the "object" has a surface-level shield script...
            // ... then it's actually a shield; don't add it
            if(!targets[i].GetComponent<ShieldTag>())
                objects.Add(targets[i]);
        
        return objects;
    }
}
