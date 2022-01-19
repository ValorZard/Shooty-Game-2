// Programmer: Srayan Jana

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalVelocity, verticalVelocity;
    Rigidbody2D body;

    //Player number
    public int playerNumber = 1;

    public float moveSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalVelocity = Input.GetAxisRaw("Horizontal" + playerNumber);
        verticalVelocity = Input.GetAxisRaw("Vertical" + playerNumber);
        body.velocity = moveSpeed * (new Vector2(horizontalVelocity, verticalVelocity)).normalized;

    }
}
