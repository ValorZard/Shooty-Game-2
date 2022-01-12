// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Public variables
        // Prefab of the bullet
        public Rigidbody2D m_Bullet;
        // The force given to the bullet
        public float m_Speed = 30f;
        // The delay before the player can shoot another bullet
        public float m_Delay = 0.05f;
    
    // Private variables
        // The input axis that is used for shooting bullets
        private string m_FireButton;
        // The current delay between shooting bullets
        public float m_CurrentDelay;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the input to shoot
        m_FireButton = "Fire1";

        // The currently delay is reset
        m_CurrentDelay = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // If the fire button is pressed, AND the current delay is zero...
        if(Input.GetButton(m_FireButton)
            && m_CurrentDelay == 0)
        {
            // ... shoot the bullet
            Fire();

            // Delay the next shot
            m_CurrentDelay = m_Delay;
        }

        // Decrement the delay by the time
        m_CurrentDelay -= Time.deltaTime;

        // If current delay is less than zero...
        if(m_CurrentDelay < 0)
        {
            // ... set it to zero (prevents a ludicrous amount generating)
            m_CurrentDelay = 0;
        }
    }

    // Instantiate the bullet
    private void Fire()
    {
        // Create an instance of the bullet and store a reference to its rigidbody
        Rigidbody2D bulletInstance = Instantiate(m_Bullet, transform.position, transform.rotation) as Rigidbody2D;

        // Get the mouse's position relative to the screen
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get the player's position
        Vector2 pos = transform.position;

        // Calculate the bullet's horizontal movement
        float horizontal = mousePos.x - pos.x;

        // Calculate the bullet's vertical movement
        float vertical = mousePos.y - pos.y;

        // Combine the horizontal and vertical movement
        Vector2 velocity = new Vector2(horizontal, vertical);

        // Set the bullet's velocity (note: don't use Time.deltaTime; seems to break speed consistency between bullets)
        bulletInstance.velocity = velocity.normalized * m_Speed;
    }
}
