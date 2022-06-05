/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
    Only for use within the health tutorial levels.
    If any players' health goes under a certain amount, the fire is
    destroyed, and the dialogue reflects this change.
*/

public class ExtinguishFire : MonoBehaviour
{
    // Private variables
        // The fire to extinguish
        [SerializeField] private GameObject m_Fire;
        // The players to keep track of
        private List<GameObject> m_Players;
        // The text to change
        private TextMeshProUGUI m_Text;
        // The message to change into
        [SerializeField] private string m_Message;
        // The health percentage limit
        [SerializeField] private float m_PercentageLimit = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the text
        m_Text = GetComponentInChildren<TextMeshProUGUI>();

        // Initialize the list
        m_Players = new List<GameObject>();

        // Make sure the limit is something calculable
        m_PercentageLimit = Mathf.Abs(m_PercentageLimit);
        m_PercentageLimit = Mathf.Min(m_PercentageLimit, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the players exist
        if(m_Players.Count != 0)
        {
            // Only run if the fire exists
            if(m_Fire != null)
            {
                // Go through the players
                foreach(GameObject player in m_Players)
                {
                    // Grab the player's health script
                    BaseHealthScript health = player.GetComponent<BaseHealthScript>();

                    // Find the ratio of the player's current health
                    float ratio = health.GetCurrentHealth() / health.GetStartingHealth();

                    // If the player's health is below the percentage...
                    if(ratio < m_PercentageLimit)
                    {
                        // ... destroy the fire
                        Destroy(m_Fire);

                        // Update the dialogue
                        m_Text.text = m_Message;
                    }
                }
            }
        }

        // Otherwise, grab the players
        else
        {
            List<GameObject> targets = FindObjectOfType<FindEntities>().GetPlayersManualRefresh();
            foreach(GameObject target in targets)
                m_Players.Add(target);
        }
    }
}
