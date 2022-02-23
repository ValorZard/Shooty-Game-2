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
    // Private variables
        // Prefab of the bullet
        [SerializeField] private Rigidbody2D m_Bullet;
        // The force given to the bullet
        [SerializeField] private float m_Speed = 30f;
        // The delay before the player can shoot another bullet
        [SerializeField] private float m_Delay = 0.05f;
        // The power of the player's attacks
        [SerializeField] private float m_Damage = 10f;
        // Player number
        private int m_PlayerNumber = 1;
        // The input axis that is used for shooting bullets
        private string m_FireButton;
        // The current delay between shooting bullets
        private float m_CurrentDelay;
        // Reference to the player's aiming script
        private PlayerAim m_PlayerAim;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the input to shoot
        m_FireButton = "Fire" + m_PlayerNumber;

        // The current delay is reset
        m_CurrentDelay = 0f;

        // Grab the player's aim script
        m_PlayerAim = GetComponentInChildren<PlayerAim>();
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

    // Checks whether or not the player can shoot
    public bool CheckShootStatus()
    {
        // If the fire button is pressed,
        // AND the current delay is zero,
        // AND the player is aiming...
        if(Input.GetButton(m_FireButton)
            && m_CurrentDelay == 0f
            && m_PlayerAim.GetAimVector() != Vector2.zero)
            // ... the player can shoot
            return true;
        return false;
    }

    // Instantiate the bullet
    private void Fire()
    {
        // Assign variables to the bullet
        AssignBullet(m_PlayerAim.GetAimVector());
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

    private Vector2 CalculateVelocity(float angle)
    {
        // Calculate the bullet's horizontal movement
        float horizontal = Mathf.Cos(angle * Mathf.Deg2Rad);

        // Calculate the bullet's vertical movement
        float vertical = Mathf.Sin(angle * Mathf.Deg2Rad);

        if(m_PlayerAim.GetAimVector().x < 0)
        {
            horizontal *= -1;
            vertical *= -1;
        }

        return new Vector2(horizontal, vertical);
    }

    public float GetDamage() { return m_Damage; }
    public void SetDamage(float num) { m_Damage = num; }
    public void SetPlayerNumber(int num) { m_PlayerNumber = num; }
    public void SetFireButton(string str) { m_FireButton = str; }
}