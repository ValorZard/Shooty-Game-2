/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    // Private variables
        // Reference to the player's front sprite
        [SerializeField] private Sprite m_PlayerFront;
        // Reference to the player's back sprite
        [SerializeField] private Sprite m_PlayerBack;
        // Reference to the player's side sprite
        [SerializeField] private Sprite m_PlayerSide;
        // Reference to the player's movement script
        private PlayerController m_MovementScript;
        // Reference to the player's SpriteRenderer
        private SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the player's movement script
        m_MovementScript = GetComponentInParent<PlayerController>();

        // Grab the player's sprite renderer
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the vertical input is negative...
        if(m_MovementScript.GetVerticalVelocity() < 0)
        {
            // ... display the front sprite
            m_SpriteRenderer.sprite = m_PlayerFront;
        }
        // Otherwise, if the vertical input is positive...
        else if(m_MovementScript.GetVerticalVelocity() > 0)
        {
            // ... display the back sprite
            m_SpriteRenderer.sprite = m_PlayerBack;
        }
        // Otherwise, if the horizontal input is negative...
        else if(m_MovementScript.GetHorizontalVelocity() < 0)
        {
            // ... display the left sprite (flipped version of right sprite)
            m_SpriteRenderer.sprite = m_PlayerSide;
            m_SpriteRenderer.flipX = true;
        }
        // Otherwise, if the horizontal input is positive...
        else if(m_MovementScript.GetHorizontalVelocity() > 0)
        {
            // ... display the right sprite
            m_SpriteRenderer.sprite = m_PlayerSide;
            m_SpriteRenderer.flipX = false;
        }
    }
}
