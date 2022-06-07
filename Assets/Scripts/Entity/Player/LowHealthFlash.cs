/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    This script is exclusively for the player and the player icon.
    When the player's health falls below a limit, the player/icon
    starts flashing red.
*/

public class LowHealthFlash : MonoBehaviour
{
    // Private variables
        // Reference to the player health script
        private BaseHealthScript m_PlayerHealth;
        // Reference to the UI health script
        private BaseHealthScript m_UIHealth;
        // The player sprite renderer to affect
        private SpriteRenderer m_SpriteRenderer;
        // The UI image to affect
        private Image m_Image;
        // The health limit
        private float m_Limit = 0.3f;
        // The current time within the animation
        private float m_CurrentTime = 0;
        // Is the animation currently fading toward red?
        private bool m_IsRed = true;
        // Was the animation just reset?
        private bool m_JustReset = true;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the player health
        m_PlayerHealth = GetComponent<BaseHealthScript>();

        // Grab the UI health
        try
        {
            m_UIHealth = transform.parent.parent.GetComponentInChildren<UIHealthBar>().GetHealthScript();
        } catch {}

        // Grab the sprite renderer
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        // Grab the image
        m_Image = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the player health exists
        if(m_PlayerHealth != null)
        {
            // If the player health runs below the limit, perform the flashing animation
            if(m_PlayerHealth.GetCurrentHealth() / m_PlayerHealth.GetStartingHealth() < m_Limit)
                FlashingAnimation();

            // Otherwise, set the colour to white
            else
                ResetAnimation();
        }

        // Only run if the UI health exists
        else if(m_UIHealth != null)
        {
            // If the UI health runs below the limit, perform the flashing animation
            if(m_UIHealth.GetCurrentHealth() / m_UIHealth.GetStartingHealth() < m_Limit)
                FlashingAnimation();

            // Otherwise, set the colour to white
            else
                ResetAnimation();
        }
        // Otherwise, try to find it
        else
        {
            try
            {
                m_UIHealth = transform.parent.parent.GetComponentInChildren<UIHealthBar>().GetHealthScript();
            } catch {}
        }
    }

    private void FlashingAnimation()
    {
        // Find the current time
        if(m_IsRed)
            m_CurrentTime = Mathf.Min(m_CurrentTime + Time.deltaTime, 1);
        else
            m_CurrentTime = Mathf.Max(m_CurrentTime - Time.deltaTime, 0);

        // Update the colour
        if(m_SpriteRenderer != null)
            m_SpriteRenderer.color = Color.Lerp(Color.white, Color.red, m_CurrentTime);
        else if(m_Image != null)
            m_Image.color = Color.Lerp(Color.white, Color.red, m_CurrentTime);

        // If the current time is equal to 1, fade to white
        if(m_CurrentTime == 1)
            m_IsRed = false;
        else if(m_CurrentTime == 0)
            m_IsRed = true;
        
        m_JustReset = false;
    }

    private void ResetAnimation()
    {
        if(!m_JustReset)
        {
            if(m_SpriteRenderer != null)
                m_SpriteRenderer.color = Color.white;
            else if(m_Image != null)
                m_Image.color = Color.white;
            m_CurrentTime = 0;
            m_IsRed = true;
            m_JustReset = true;
        }
    }
}
