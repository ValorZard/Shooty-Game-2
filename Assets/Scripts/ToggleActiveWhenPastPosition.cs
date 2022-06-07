/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This program enables/disables objects when the players go past a given position.
    This is used to block players off or advance dialogue.
    Currently, this script is specialized for use in the multiplayer version of level 2,
    where the players have to be split between two different hallways.
*/

public class ToggleActiveWhenPastPosition : MonoBehaviour
{
    // Private variables
        // The first position to track
        [SerializeField] private Transform m_FirstPosition;
        // The second position to track
        [SerializeField] private Transform m_SecondPosition;
        // The first obstruction to enable/disable
        [SerializeField] private GameObject m_FirstObstruction;
        // The second obstruction to enable/disable
        [SerializeField] private GameObject m_SecondObstruction;
        // The text to disable
        [SerializeField] private GameObject m_Textbox;
        // The players to track
        private List<GameObject> m_Players;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the list
        m_Players = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the player list
        m_Players.Clear();
        List<GameObject> targets = FindObjectOfType<FindEntities>().GetPlayersManualRefresh();
        foreach(GameObject target in targets)
            m_Players.Add(target);

        // Only run if there are players to track
        if(m_Players.Count != 0)
        {
            // Only run if there are two players
            if(m_Players.Count == 2)
            {
                // If the first player is past the first position...
                if(m_Players[0].transform.position.x < m_FirstPosition.position.x
                    && m_Players[0].transform.position.y > m_FirstPosition.position.y)
                {
                    // ... enable the first obstruction
                    m_FirstObstruction.SetActive(true);
                    // ... disable the text
                    m_Textbox.SetActive(false);
                }

                // If the second player is past the second position...
                if(m_Players[1].transform.position.x > m_SecondPosition.position.x
                    && m_Players[1].transform.position.y > m_SecondPosition.position.y)
                {
                    // ... enable the second obstruction
                    m_SecondObstruction.SetActive(true);
                    // ... disable the text
                    m_Textbox.SetActive(false);
                }
            }

            // If there is only one player...
            else if(m_Players.Count == 1)
            {
                // ... disable the obstructions
                m_FirstObstruction.SetActive(false);
                m_SecondObstruction.SetActive(false);
                // ... disable the text
                m_Textbox.SetActive(false);
            }
        }
    }
}
