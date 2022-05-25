/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightClicker : MonoBehaviour
{
    // Private variables
        // Which mouse button to focus on
        [SerializeField] private int m_MouseButton = 0;
        // Reference to the image
        private Image m_Image;
        // Has the button been clicked yet?
        private bool m_HasBeenClicked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Grab the image
        m_Image = GetComponent<Image>();

        // If the mouse button is out-of-bounds, use a default number
        if(!(0 <= m_MouseButton && m_MouseButton <= 2))
            m_MouseButton = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // If the button hasn't been clicked yet, change colours
        if(!m_HasBeenClicked)
            m_Image.color = Color.red;

        // If the left mouse is held down, darken the image
        if(Input.GetMouseButton(m_MouseButton))
        {
            m_Image.color = Color.grey;
            m_HasBeenClicked = true;
        }
        
        // Otherwise, brighten the image
        else if(m_HasBeenClicked)
            m_Image.color = Color.white;
    }
}
