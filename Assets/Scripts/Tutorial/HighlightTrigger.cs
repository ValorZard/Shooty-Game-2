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

    // Start is called before the first frame update
    void Start()
    {
        // Grab the image
        m_Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the trigger is held down, darken the image
        if(Input.GetAxisRaw("Fire2") > 0
            || Input.GetAxisRaw("Fire2XBOX") > 0)
            m_Image.color = Color.grey;
        
        // Otherwise, brighten the image
        else
            m_Image.color = Color.white;
    }
}
