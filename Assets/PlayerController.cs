using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalVelocity, verticalVelocity;
    Rigidbody2D body;

    public float moveSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalVelocity = Input.GetAxisRaw("Horizontal");
        verticalVelocity = Input.GetAxisRaw("Vertical");
        body.velocity = moveSpeed * (new Vector2(horizontalVelocity, verticalVelocity)).normalized;
    }
}
