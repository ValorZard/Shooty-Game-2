/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Private variables
        // Reference to the end screen
        private UIEndScreen m_EndScreen;
        // Have the entities been disabled yet? (included so the script to get players doesn't replay repeatedly)
        private bool m_IsDisabled;
        // Reference to the player and enemy lists
        private FindEntities m_Entities;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the end screen script
        m_EndScreen = GetComponentInChildren<UIEndScreen>();

        // They should not be disabled yet
        m_IsDisabled = false;

        // Grab the lists
        m_Entities = GetComponentInParent<FindEntities>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the game over screen is active AND the entities haven't been disabled yet...
        if(m_EndScreen != null
            && m_EndScreen.GetActive()
            && !m_IsDisabled)
            // ... disable the scripts
            DisableEntities();
    }

    // Disables the entities' scripts
    private void DisableEntities()
    {
        DisablePlayers();
        DisableEnemies();
        DisableAIs();

        // The entities have been disabled
        m_IsDisabled = true;
    }

    // Disables the players' scripts
    private void DisablePlayers()
    {
        // Grab the players
        List<GameObject> players = m_Entities.GetPlayersManualRefresh();

        // Go through the player list
        foreach(GameObject p in players)
        {
            // If the player is active AND can be disabled...
            if(p.activeSelf
                && p.GetComponentInChildren<PlayerDisable>())
                // ... disable it
                p.GetComponentInChildren<PlayerDisable>().DisableEntity();
        }
    }

    // Disables the enemies' scripts
    private void DisableEnemies()
    {
        // Grab the enemies
        List<GameObject> enemies = m_Entities.GetEnemiesRefresh();

        // Go through the enemy list
        foreach(GameObject e in enemies)
        {
            // If the enemy is active AND can be disabled...
            if(e.activeSelf
                && e.GetComponentInChildren<EnemyDisable>())
                // ... disable it
                e.GetComponentInChildren<EnemyDisable>().DisableEntity();
        }
    }

    // Disables the player AIs' scripts
    private void DisableAIs()
    {
        // Grab the AIs
        List<GameObject> ais = m_Entities.GetPlayersAIRefresh();

        // Go through the AI list
        foreach(GameObject a in ais)
        {
            // If the AI is active AND can be disabled...
            if(a.activeSelf
                && a.GetComponentInChildren<PlayerAIDisable>())
                // ... disable it
                a.GetComponentInChildren<PlayerAIDisable>().DisableEntity();
        }
    }
}
