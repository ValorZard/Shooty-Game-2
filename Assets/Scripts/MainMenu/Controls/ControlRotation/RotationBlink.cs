/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationBlink : RotationListener
{
    // Private variables
        // Reference to the image
        private Image m_Image;
        // Is the image currently active?
        private bool m_Active;

    protected override void OnStart()
    {
        // Grab the image
        m_Image = GetComponent<Image>();

        // The image starts darkened
        DarkenImage();
    }

    protected override void OnTick()
    {
        // If the image is active, darken the image
        if(m_Active)
        {
            DarkenImage();
        }
        // Otherwise, brighten the image
        else
        {
            BrightenImage();
        }
    }

    private void DarkenImage()
    {
        m_Image.color = Color.grey;
        m_Active = false;
    }

    private void BrightenImage()
    {
        m_Image.color = Color.white;
        m_Active = true;
    }
}
