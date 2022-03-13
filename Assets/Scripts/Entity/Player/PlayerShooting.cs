/*
    Programmers: Manhattan Calabro, Pedro Longo
        Manhattan: Worked on shooting,
            reworked aim calculation,
            refactoured for better encapsulation
        Pedro: Added player number differentiation
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

        // Reference to the player's ammo script
        private AmmoManager m_AmmoManager;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the input to shoot
        m_FireButton = "Fire" + playerNumber;

        // The current delay is reset
        m_CurrentDelay = 0f;

        // Grab the ammo manager
        m_AmmoManager = GetComponent<AmmoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player can shoot...
        if(CheckShootStatus())
        {
            // ... shoot the bullet
            Fire();
            

            // Delay the next shot
            m_CurrentDelay = m_Delay;
        }

        // Decrement the delay by the time
        m_CurrentDelay -= Time.deltaTime;

        // If current delay is less than zero...
        if(m_CurrentDelay < 0f)
        {
            // ... set it to zero (prevents a ludicrous amount generating)
            m_CurrentDelay = 0f;
        }
    }

    // Instantiate the bullet
    private void Fire()
    {
        // Assign variables to the bullet
        AssignBullet(CalculateVelocity());

        // Removes one from the ammo count
        m_AmmoManager.DecrementAmmo();
    }

    // Instantiate the bullet
    public void Fire(float angle)
    {
        // Assign variables to the bullet
        AssignBullet(CalculateVelocity(angle));
    }

    // Assigns variables to a bullet
    private void AssignBullet(Vector2 velocity)
    {
        // Create an instance of the bullet and store a reference to its rigidbody
        Rigidbody2D bulletInstance = Instantiate(m_Bullet, transform.position, transform.rotation) as Rigidbody2D;

        // Grab the bullet script
        BulletHit bulletScript = bulletInstance.GetComponent<BulletHit>();

        // Set the attack power of the bullet (this is here in case the player gets an attack powerup; the bullet spawns with the new attack)
        bulletScript.SetDamage(m_Damage);

        // Set the friendly tag
        bulletScript.SetFriend("Player");

        // Set the enemy tag
        bulletScript.SetEnemy("Enemy");

        // Set the bullet's velocity (note: don't use Time.deltaTime; seems to break speed consistency between bullets)
        bulletInstance.velocity = velocity.normalized * m_Speed;
    }

    // Calculates the velocity between the cursor and the player
    public Vector2 CalculateVelocity()
    {
        // Second player calculation
        if(playerNumber == 2)
        {
            float horizontal2 = Input.GetAxisRaw("AimHorizontal2");
            float vertical2 = Input.GetAxisRaw("AimVertical2");
            return new Vector2(horizontal2, vertical2);
        }

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

    // Checks if the player can shoot
    public bool CheckShootStatus()
    {
        // Can only shoot if the shooting button is held down...
        return Input.GetButton(m_FireButton)
            // ... if the current delay is zero...
            && m_CurrentDelay == 0f
            // ... and if the player has ammo
            && m_AmmoManager.GetCurrentAmmo() != 0
            // ... and the shooting velocity isn't zero
            && CalculateVelocity() != Vector2.zero;
    }

    public float GetDamage() { return m_Damage; }
    public void SetDamage(float num) { m_Damage = num; }
    public void SetPlayerNumber(int num) { playerNumber = num; }
    public void SetFireButton(string str) { m_FireButton = str; }
}