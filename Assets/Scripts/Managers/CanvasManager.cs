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
        // Have the players been disabled yet? (included so the script to get players doesn't replay repeatedly)
        private bool m_IsDisabled;
        // Reference to the player and enemy lists
        private FindEntities m_Entities;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the end screen script
        m_EndScreen = GetComponentInChildren<UIEndScreen>();

        // The players should not be disabled yet
        m_IsDisabled = false;

        // Grab the lists
        m_Entities = GetComponentInParent<FindEntities>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the win screen is active AND the players haven't been disabled yet...
        if(m_EndScreen != null
            && m_EndScreen.GetActive()
            && !m_IsDisabled)
            // ... disable the players' scripts
            DisablePlayers();
    }

    // Disables the players' scripts
    private void DisablePlayers()
    {
        // Grab the players
        List<GameObject> players = m_Entities.GetPlayersRefresh();

        // Go through the player list
        for(int i = 0; i < players.Count; i++)
        {
            // If the player is active AND can be disabled...
            if(players[i].activeSelf
                && players[i].GetComponentInChildren<PlayerDisable>())
                // ... disable the player
                players[i].GetComponentInChildren<PlayerDisable>().DisablePlayer();
        }

        // The players have been disabled
        m_IsDisabled = true;
    }
}
