/*
    Programmers: Srayan Jana, Pedro Longo, Manhattan Calabro
        Srayan: Worked on movement
        Pedro: Added player number differentiation
        Manhattan: Refactoured to allow controller compatibility,
            refactoured for better encapsulation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private variables
        // The horizontal velocity and vertical velocity
        private float m_HorizontalVelocity, m_VerticalVelocity;
        // The horizontal and vertical movement input axes
        private string m_HorizontalAxis, m_VerticalAxis;
        // The player's movement speed
        [SerializeField] private float m_MoveSpeed = 1.0f;
        // Reference to the player's rigidbody
        private Rigidbody2D m_Body;
        // Player number
        private int m_PlayerNumber = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Body = GetComponent<Rigidbody2D>();

        // Assign the input axes
        m_HorizontalAxis = "Horizontal" + m_PlayerNumber;
        m_VerticalAxis = "Vertical" + m_PlayerNumber;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_HorizontalVelocity = Input.GetAxisRaw(m_HorizontalAxis);
        m_VerticalVelocity = Input.GetAxisRaw(m_VerticalAxis);
        m_Body.velocity = m_MoveSpeed * (new Vector2(m_HorizontalVelocity, m_VerticalVelocity)).normalized;
    }

    public float GetHorizontalVelocity() { return m_HorizontalVelocity; }
    public float GetVerticalVelocity() { return m_VerticalVelocity; }
    public void SetHorizontalAxis(string str) { m_HorizontalAxis = str; }
    public void SetVerticalAxis(string str) { m_VerticalAxis = str; }
    public float GetMoveSpeed() { return m_MoveSpeed; }
    public void SetMoveSpeed(float num) { m_MoveSpeed = num; }
    public int GetPlayerNumber() { return m_PlayerNumber; }
    public void SetPlayerNumber(int num) { m_PlayerNumber = num; }
}
