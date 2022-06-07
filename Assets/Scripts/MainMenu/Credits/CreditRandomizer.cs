/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditRandomizer : MonoBehaviour
{
    // Private variables
        // List of people who worked on the project
        private List<string> m_Credits;
        // Reference to the text
        private TextMeshProUGUI m_TMP;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the credits
        InitializeCredits();

        // Grab the text reference
        m_TMP = GetComponent<TextMeshProUGUI>();

        // Randomize the list order
        RandomizeList();

        // Display the credits
        DisplayCredits();
    }

    // Initializes the credits
    private void InitializeCredits()
    {
        m_Credits = new List<string>();
        m_Credits.Add("Manhattan Calabro");
        m_Credits.Add("Pedro Longo");
        m_Credits.Add("Srayan Jana");
        m_Credits.Add("Derek Chan");
        m_Credits.Add("Sarah Harkins");
        m_Credits.Add("Esmeralda Juarez");
    }

    // Randomizes the list order
    private void RandomizeList()
    {
        // New list
        List<string> list = new List<string>();

        // Continue until the credits list has no more names
        while(m_Credits.Count != 0)
        {
            // Pick a random index
            int index = Random.Range(0, m_Credits.Count - 1);

            // Get the element
            string str = m_Credits[index];

            // Remove that element from the credits
            m_Credits.Remove(str);

            // Add the element to the new list
            list.Add(str);
        }

        // Return the new list
        m_Credits = list;
    }

    // Displays the credits
    private void DisplayCredits()
    {
        // Clears out the last display
        m_TMP.text = "";

        // Updates the displayed text
        for(int i = 0; i < m_Credits.Count; i++)
        {
            m_TMP.text += m_Credits[i] + "\n";
        }
    }
}
