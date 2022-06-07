/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAnimation : MonoBehaviour
{
    // Private variables
        // Reference to the animation manager's sprite renderer
        private SpriteRenderer m_Renderer;
        // Is the enter animation playing?
        private bool m_Enter;
        // Is the exit animation playing?
        private bool m_Exit;
        // Animation speed multiplier
        [SerializeField] private float m_Speed;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the sprite renderer
        m_Renderer = GetComponent<SpriteRenderer>();

        // The teleportation animation is not playing
        m_Enter = m_Exit = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Run the exit animation first
        if(m_Exit)
            ExitAnimation();
        
        else if(m_Enter)
            EnterAnimation();
    }

    // The enter animation
    private void EnterAnimation()
    {
        // Fade into opaque colour
        if(m_Renderer.color.a < 1)
            m_Renderer.color = new Color(m_Renderer.color.r,
                                         m_Renderer.color.g,
                                         m_Renderer.color.b,
                                         Mathf.Min(m_Renderer.color.a + Time.deltaTime * m_Speed, 1));
    }

    // The exit animation
    private void ExitAnimation()
    {
        // Fade out of opaque colour
        if(m_Renderer.color.a > 0)
            m_Renderer.color = new Color(m_Renderer.color.r,
                                         m_Renderer.color.g,
                                         m_Renderer.color.b,
                                         Mathf.Max(m_Renderer.color.a - Time.deltaTime * m_Speed, 0));
    }

    public void ResetAnimation()
    {
        // Immediately returns to transparent
        m_Renderer.color = new Color(m_Renderer.color.r,
                                     m_Renderer.color.g,
                                     m_Renderer.color.b,
                                     0);
        SetEnter(false);
        SetExit(false);
    }

    public bool GetEnter() { return m_Enter; }
    public bool GetExit() { return m_Exit; }
    public void SetEnter(bool b) { m_Enter = b; }
    public void SetExit(bool b) { m_Exit = b;}
    public bool GetEnterFinished() { return m_Renderer.color.a == 1; }
    public bool GetExitFinished() { return m_Renderer.color.a == 0; }
}
