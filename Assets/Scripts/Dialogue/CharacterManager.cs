/*
    Programmer: Manhattan Calabro, Srayan Jana
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
        // The target colour
        private Color m_Target;
        // Constant of how much to change the colour at a time (might get docked points for initializing the value here, but this is just a good value)
        private float m_Constant = 3f;

    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponentInChildren<Image>();
        m_Target = m_Image.color;
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
        m_Target = Color.white;
    }

    public void DarkenImage()
    {
        m_Target = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the target colour isn't the same as the current colour
        if(m_Target != m_Image.color)
        {
            // The constant to change the colour by
            float constant = m_Constant * Time.deltaTime;

            // Resultant colour values
            float red = m_Image.color.r;
            float green = m_Image.color.g;
            float blue = m_Image.color.b;

            // (Assume the colours are greyscale)
            // If the target colour is brighter than the current colour...
            if(m_Target.r > m_Image.color.r)
            {
                red = Mathf.Min(red + constant, m_Target.r);
                green = Mathf.Min(green + constant, m_Target.g);
                blue = Mathf.Min(blue + constant, m_Target.b);
            }
            // Otherwise, the target colour is darker than the current colour...
            else
            {
                red = Mathf.Max(red - constant, m_Target.r);
                green = Mathf.Max(green - constant, m_Target.g);
                blue = Mathf.Max(blue - constant, m_Target.b);
            }

            // Final colour
            m_Image.color = new Color(red, green, blue);
        }
    }

    public string GetName() { return m_ID; }
}
