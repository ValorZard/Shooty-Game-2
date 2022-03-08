/*
    Programmers: Srayan Jana, Manhattan Calabro
        Srayan: Base code
        Manhattan: Changed to use TextMeshPro instead of TextMesh,
            added message update
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Private variables
        // The active characters
        private CharacterManager[] m_Characters;
        // Reference to the text
        private TextMeshProUGUI m_Text;
        // Reference to the names
        private List<TextMeshProUGUI> m_Names;
        // The current dialogue playing
        private int index;
        // The dialogue
        [SerializeField] private List<DialogueClass> m_Dialogue;

    // Start is called before the first frame update
    void Start()
    {
        // Grab from the children
        m_Characters = GetComponentsInChildren<CharacterManager>();
        m_Text = GetComponentInChildren<TextMeshProUGUI>();

        // Get the names
        m_Names = new List<TextMeshProUGUI>();
        TextMeshProUGUI[] names = GetComponentsInChildren<TextMeshProUGUI>();
        for(int i = 1; i < names.Length - 1; i++)
        {
            // Skip the first element; that's the text
            // Also skip the last element; that's the button's text
            m_Names.Add(names[i]);

            // Change the name's text to the corresponding character's name
            m_Names[i-1].text = m_Characters[i-1].GetName();
        }

        // Starts at the first message
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayMessage();
    }

    private void DisplayMessage()
    {
        // Only run if the index is within bounds
        try
        {
            // Changes the message
            DialogueClass dialogue = m_Dialogue[index];
            m_Text.text = dialogue.GetMessage();

            // Changes the image
            m_Characters[dialogue.GetCharacterNumber()].UpdateImage(dialogue.GetEmotion());
            m_Characters[dialogue.GetCharacterNumber()].BrightenImage();

            // Darkens the other character; they aren't talking
            m_Characters[(dialogue.GetCharacterNumber()+1)%2].DarkenImage();
        } catch { /* Possibly fade to black or cut to a new scene. */ }
    }

    public void NextMessage()
    {
        // Increment the index
        index++;

        DisplayMessage();
    }
}
