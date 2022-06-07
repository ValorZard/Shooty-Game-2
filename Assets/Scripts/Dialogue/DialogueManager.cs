/*
    Programmers: Srayan Jana, Manhattan Calabro
        Srayan: Base code
        Manhattan: Changed to use TextMeshPro instead of TextMesh,
            added message update,
            combined DialogueReader and DialogueManager because there was some weird glitch with trying to grab from the reader when it was separate... I don't know how to explain it
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class DialogueManager : DialogueReader
{
    // Private variables
        // The active characters
        private CharacterManager[] m_Characters;
        // Reference to the text
        private TextMeshProUGUI m_Text;
        // Reference to the names
        private List<TextMeshProUGUI> m_Names;
        // The current dialogue playing
        private int m_DialogueIndex;
        // The current index of the text of the current dialogue
        private int m_TextIndex;
        // The dialogue
        private List<DialogueClass> m_Dialogue;
        // Black screen
        [SerializeField] private GameObject m_Black;

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
        m_DialogueIndex = 0;
        // Starts at the first letter
        m_TextIndex = 0;

        // Open the file
        m_Reader = new StreamReader("Assets/Dialogue/" + m_File.name + ".txt");

        // Gets the dialogue from the reader
        m_Dialogue = new List<DialogueClass>();
        //while(!m_Reader.EndOfStream())
        while(!m_Reader.EndOfStream)
            m_Dialogue.Add(GenerateDialogueFromLine());
    }

    // Update is called once per frame
    void Update()
    {
        // If the end of the file has been reached, close the file
        if(m_Reader != null)
            if(m_Reader.EndOfStream)
            {
                m_Reader.Dispose();
                m_Reader = null;
            }

        DisplayMessage();

        // If the left mouse button was clicked OR the spacebar was pressed, display the next message
        if(Input.GetMouseButtonDown(0)
            || Input.GetKeyDown("space"))
            NextMessage();
    }

    private void DisplayMessage()
    {
        // Only run if the indices are within bounds
        try
        {
            // Changes the message
            UpdateTextbox();

            // Changes the image
            DialogueClass dialogue = m_Dialogue[m_DialogueIndex];
            m_Characters[dialogue.GetCharacterNumber()].UpdateImage(dialogue.GetEmotion());
            m_Characters[dialogue.GetCharacterNumber()].BrightenImage();

            // Darkens the other character; they aren't talking
            m_Characters[(dialogue.GetCharacterNumber()+1)%2].DarkenImage();
        }
        // The end of the dialogue has been reached
        catch
        {
            // Fade to black
            m_Black.SetActive(true);
            enabled = false;
        }
    }

    public void NextMessage()
    {
        // Reset the text index (start at the beginning of the next message)
        m_TextIndex = 0;
        // Move to the next message
        m_DialogueIndex++;
        DisplayMessage();
    }

    private void UpdateTextbox()
    {
        // The message to display
        string str = m_Dialogue[m_DialogueIndex].GetMessage().Substring(0, m_TextIndex + 1);
        
        // Display the message
        m_Text.text = str;

        // Move to the next letter
        m_TextIndex = Mathf.Min(m_TextIndex + 1, m_Dialogue[m_DialogueIndex].GetMessage().Length - 1);
    }
}
