/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    // Private variables
        // Reference to the reticle's sprite renderer
        private SpriteRenderer m_SpriteRenderer;
        // Reference to the player's aim script
        private PlayerAim m_PlayerAim;
        // Offset of the reticle
        private Vector2 m_Offset;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_PlayerAim = GetComponent<PlayerAim>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the offset
        m_Offset = m_PlayerAim.GetAimVector();

        // If the offset is not zero...
        if(m_Offset != Vector2.zero)
            // ... enable the sprite
            m_SpriteRenderer.enabled = true;
        // Otherwise, disable it
        else
            m_SpriteRenderer.enabled = false;

        // Update the reticle's position
        transform.position = transform.parent.position + new Vector3(m_Offset.x, m_Offset.y, -1f);
    }
}
