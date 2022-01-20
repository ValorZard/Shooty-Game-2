/*
    Programmers: Manhattan Calabro, Cuervo94
        Manhattan: Worked on shooting
        Cuervo: Added player number differentiation
*/

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
        // The power of the player's attacks
        public float m_Damage = 10f;
    // Player number
    public int playerNumber = 1;
    
    // Private variables
        // The input axis that is used for shooting bullets
        [HideInInspector] public string m_FireButton;
        // The current delay between shooting bullets
        [HideInInspector] public float m_CurrentDelay;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the input to shoot
        m_FireButton = "Fire" + playerNumber;

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

    // Calculates the velocity between the cursor and the player
    public Vector2 CalculateVelocity()
    {
        // Get the mouse's position relative to the screen
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get the player's position
        Vector2 pos = transform.position;

        // Calculate the bullet's horizontal movement
        float horizontal = mousePos.x - pos.x;

        // Calculate the bullet's vertical movement
        float vertical = mousePos.y - pos.y;

        return new Vector2(horizontal, vertical);
    }

    private Vector2 CalculateVelocity(float angle)
    {
        // Calculate the bullet's horizontal movement
        float horizontal = Mathf.Cos(angle * Mathf.Deg2Rad);

        // Calculate the bullet's vertical movement
        float vertical = Mathf.Sin(angle * Mathf.Deg2Rad);

        if(CalculateVelocity().x < 0)
        {
            horizontal *= -1;
            vertical *= -1;
        }

        return new Vector2(horizontal, vertical);
    }

    // Assigns variables to a bullet
    private void AssignBullet(Vector2 velocity)
    {
        // Create an instance of the bullet and store a reference to its rigidbody
        Rigidbody2D bulletInstance = Instantiate(m_Bullet, transform.position, transform.rotation) as Rigidbody2D;

        // Grab the bullet script
        BulletHit bulletScript = bulletInstance.GetComponent<BulletHit>();

        // Set the attack power of the bullet (this is here in case the player gets an attack powerup; the bullet spawns with the new attack)
        bulletScript.setDamage(m_Damage);

        // Set the friendly tag
        bulletScript.m_Friend = "Player";

        // Set the enemy tag
        bulletScript.m_Enemy = "Enemy";

        // Set the bullet's velocity (note: don't use Time.deltaTime; seems to break speed consistency between bullets)
        bulletInstance.velocity = velocity.normalized * m_Speed;
    }

    // Instantiate the bullet
    private void Fire()
    {
        Debug.Log("Player " + playerNumber + " is shooting!!");
        // Assign variables to the bullet
        AssignBullet(CalculateVelocity());
    }

    // Instantiate the bullet
    public void Fire(float angle)
    {
        // Assign variables to the bullet
        AssignBullet(CalculateVelocity(angle));
    }
}