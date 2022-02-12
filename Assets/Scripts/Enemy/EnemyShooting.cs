/*
    Programmers: Manhattan Calabro, Pedro Longo
        Manhattan: Created PlayerShooting (what this script is based off of),
                   added check for whether target exists (that way, there won't be several console exceptions),
                   added overriding (relevant for EnemyShootingBurst)
        Pedro: Added target and direction to shooting
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // Public variables
        // Prefab of the bullet
        public Rigidbody2D m_Bullet;
        // The force given to the bullet
        public float m_Speed = 30f;
        // The delay before the enemy can shoot another bullet
        public float m_Delay = 0.5f;
        // The power of the enemy's attacks
        public float m_Damage = 10f;
        //For getting enemy sight
        public EnemyController enemy;
    
    // Protected variables
        // Friendly tag
        protected string m_Friend; 
        // Enemy tag
        protected string m_Enemy;


    // Private variables
    // The current delay between shooting bullets
    private float m_CurrentDelay;

    // Start is called before the first frame update
    void Start()
    {
        // The current delay is reset
        m_CurrentDelay = 0f;

        enemy = GetComponent<EnemyController>();

        m_Friend = "Enemy";
        m_Enemy = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        // If the current delay is zero...
        if (m_CurrentDelay == 0f)
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
    protected virtual void Fire()
    {
        //Initialize velocity
        Vector2 velocity = Vector2.zero;

        // If the target exists, run
        if (enemy.target != null)
        {
            //UPDATED (Pedro Longo)
            //get position of player in sight
            if (enemy.playerDetectionArea)
            {
                Vector2 moveDir = (enemy.target.transform.position - transform.position).normalized * m_Speed;
                velocity = new Vector2(moveDir.x, moveDir.y);
            }



            // Create an instance of the bullet and store a reference to its rigidbody
            Rigidbody2D bulletInstance = Instantiate(m_Bullet, transform.position, transform.rotation) as Rigidbody2D;

            // Grab the bullet script
            BulletHit bulletScript = bulletInstance.GetComponent<BulletHit>();

            // Set the attack power of the bullet
            bulletScript.setDamage(m_Damage);

            // Set the friendly tag
            bulletScript.m_Friend = "Enemy";

            // Set the enemy tag
            bulletScript.m_Enemy = "Player";

            // Set the bullet's velocity
            bulletInstance.velocity = velocity.normalized * m_Speed;
        }
    }
}
