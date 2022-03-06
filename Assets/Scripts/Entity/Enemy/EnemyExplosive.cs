/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyExplosive : BaseShooting
{
    // Private variables
        // How long will the timer last?
        [SerializeField] private float m_MaxTime;
        // Reference to the timer child
        private Timer m_Timer;
        // Reference to the movement script
        private EnemyController m_MovementScript;

    protected override void InitializeShooting()
    {
        // Grab the timer child
        m_Timer = transform.parent.GetComponentInChildren<Timer>();

        // Grab the movement script
        m_MovementScript = GetComponentInParent<EnemyController>();
    }

    // Check if the player has entered the enemy's hitbox
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only run if the enemy is able to move
        if(m_MovementScript.enabled)
        {
            // Only run if the tag has been initialized
            if(m_Enemy != null && m_Enemy != "")
            {
                // If the collider belongs to the player...
                if(other.CompareTag(m_Enemy))
                {
                    // ... start the timer
                    m_Timer.SetTime(m_MaxTime);

                    // Stop moving
                    m_MovementScript.enabled = false;
                    Rigidbody2D body = transform.parent.GetComponent<Rigidbody2D>();
                    body.velocity = Vector2.zero;
                    body.bodyType = RigidbodyType2D.Kinematic;
                    GetComponentInParent<NavMeshAgent>().enabled = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckShootStatus())
            Fire();
    }

    // Checks whether the enemy is moving and the timer's time
    public override bool CheckShootStatus()
    {
        return !m_MovementScript.enabled && m_Timer.GetTime() == 0;
    }

    // The enemy explodes
    protected override void Fire()
    {
        // Spawn an explosion
        CreateBullet();

        // Disable the enemy
        transform.parent.gameObject.SetActive(false);
    }
}
