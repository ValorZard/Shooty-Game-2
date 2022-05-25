/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightTrigger : MonoBehaviour
{
    // Private variables
        // Reference to the image
        private Image m_Image;
        // Has the button been clicked yet?
        private bool m_HasBeenClicked;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the image
        m_Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the button hasn't been clicked yet, change colours
        if(!m_HasBeenClicked)
            m_Image.color = Color.red;

        // If the trigger is held down, darken the image
        if(Input.GetAxisRaw("Fire2") > 0
            || Input.GetAxisRaw("Fire2XBOX") > 0)
        {
            m_Image.color = Color.grey;
            m_HasBeenClicked = true;
        }
        
        // Otherwise, brighten the image
        else if(m_HasBeenClicked)
            m_Image.color = Color.white;
    }
}
