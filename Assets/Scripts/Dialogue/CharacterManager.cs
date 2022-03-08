/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    // Private variables
        // The character's name
        [SerializeField] private string m_ID;
        // The sprites associated with the character
        [SerializeField] private List<Sprite> m_Sprites;
        // The image displayer
        private Image m_Image;


    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponentInChildren<Image>();
    }

    // Update the image
    public void UpdateImage(int index)
    {
        // If the index is out of bounds...
        if(index >= m_Sprites.Count)
            // ... change nothing
            return;
        
        m_Image.sprite = m_Sprites[index];
    }

    public void UpdateImage(string str)
    {
        // The target sprite
        Sprite target = m_Image.sprite;

        // Go through the list
        for(int i = 0; i < m_Sprites.Count; i++)
        {
            // If the sprite has been found...
            if(m_Sprites[i].name.Contains(str))
            {
                // ... change the target sprite
                target = m_Sprites[i];

                // Exit out of the loop early
                i = m_Sprites.Count;
            }
        }

        // Set the sprite
        m_Image.sprite = target;
    }

    public void BrightenImage()
    {
        m_Image.color = Color.white;
    }

    public void DarkenImage()
    {
        m_Image.color = Color.grey;
    }

    public string GetName() { return m_ID; }
}
