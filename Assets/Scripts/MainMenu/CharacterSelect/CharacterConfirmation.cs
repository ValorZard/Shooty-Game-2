/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConfirmation : MonoBehaviour
{
    // Private variables
        // Reference to the select script
        private CharacterSelect m_Script;
        // Reference to the children's sprite renderers
        private SpriteRenderer[] m_Renderers;
        // Reference to the rect transform
        private RectTransform m_Rect;
    
    // Start is called before the first frame update
    void Start()
    {
        // Grab the select script
        m_Script = transform.parent.GetComponentInChildren<CharacterSelect>();
    
        // Grab the children
        m_Renderers = GetComponentsInChildren<SpriteRenderer>();

        // Make sure the confirm cursor starts invisible
        SetAble(false);

        // Grab the rect transform
        m_Rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the confirm button is pressed, confirm the character
        if(Input.GetAxis("Fire" + m_Script.GetPlayerNumber()) > 0)
        {
            // Make sure the cursor is visible
            SetAble(true);

            // Change the cursor's position
            m_Rect.anchorMin = m_Script.GetRectTransform().anchorMin;
            m_Rect.anchorMax = m_Script.GetRectTransform().anchorMax;
            m_Rect.pivot = m_Script.GetRectTransform().pivot;
            
            // Hide the select cursor
            m_Script.SetAble(false);

            // Disable the select script
            m_Script.enabled = false;
        }

        // Otherwise, if the cancel button is pressed, go back to select
        else if(Input.GetAxis("Fire" + m_Script.GetPlayerNumber()) < 0)
        {
            // Make sure the cursor is invisible
            SetAble(false);

            // Enable the select script
            m_Script.enabled = true;

            // Show the select cursor
            m_Script.SetAble(true);
        }
    }

    // Enables/disables all children within the confirm cursor
    private void SetAble(bool b)
    {
        // Only run if the boolean and the cursor visibility are opposite
        if(m_Renderers[0].enabled != b)
            // Go through the list
            foreach(SpriteRenderer rend in m_Renderers)
                rend.enabled = b;
    }

    // Is the position set to the first character?
    public bool IsFirst()
    {
        return m_Script.IsFirst();
    }
}
