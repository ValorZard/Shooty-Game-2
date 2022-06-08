/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBehaviour : MonoBehaviour
{
    // Private variables
        // The behaviour to activate
        [SerializeField] private GameObject m_Behaviour;
        // The position to pass
        [SerializeField] private Transform m_Position;
        // The players to track
        private FindEntities m_Players;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the players
        m_Players = GameObject.FindObjectOfType<FindEntities>();
    }

    // Update is called once per frame
    void Update()
    {
        // Go through the player list
        foreach(GameObject player in m_Players.GetPlayersManualRefresh())
            // If one of the players passes the position...
            if(player.transform.position.x > m_Position.position.x)
            {
                // ... activate the behaviour
                m_Behaviour.SetActive(true);

                // Destroy this script; it's no longer required
                Destroy(this);
            }
    }
}
