/*
    Programmers: Srayan Jana, Pedro Longo, Manhattan Calabro
        Srayan: Worked on movement
        Pedro: Added player number differentiation, added NavMesh rotation code
        Manhattan: Refactoured to allow controller compatibility
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    // Public variables
        // The velocity of the player movement
        public float horizontalVelocity, verticalVelocity;
        // The horizontal movement input axis
        public string m_HorizontalAxis;
        // The vertical movement input axis
        public string m_VerticalAxis;
        // Reference to the player's rigidbody
        Rigidbody2D body;
        //Player number
        public int playerNumber;
        // The player's movement speed
        public float moveSpeed = 1.0f;

        NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        // Fix rotation of NavMesh agent
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;


        body = GetComponent<Rigidbody2D>();

        // Assign the input axes
        m_HorizontalAxis = "Horizontal" + playerNumber;
        m_VerticalAxis = "Vertical" + playerNumber;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalVelocity = Input.GetAxisRaw(m_HorizontalAxis);
        verticalVelocity = Input.GetAxisRaw(m_VerticalAxis);
        body.velocity = moveSpeed * (new Vector2(horizontalVelocity, verticalVelocity)).normalized;
    }
}
