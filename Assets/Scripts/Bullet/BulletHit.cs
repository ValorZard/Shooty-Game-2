/*
    Programmers: Manhattan Calabro, Pedro Longo
        Manhattan: Coded bullet collision,
                   generalized code to work with multiple objects
        Pedro: Added collision conditions for "EnemyView"-type objects
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    // Public variables
        // The amount of damage done if hit by the bullet
        public float m_Damage = 10f;
        // The tag not to harm
        public string m_Friend = "";
        // The tag to harm
        public string m_Enemy = "";

    // Private variables
        // Reference to the bullet's collider
        private CircleCollider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<CircleCollider2D>();

        // Let the bullet travel a specific distance
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collect all the colliders around the bullet
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, m_Collider.radius);

        // Go through all the colliders
        for(int i = 0; i < colliders.Length; i++)
        {
            // If the collider belongs to a bullet, skip it
            if(colliders[i].CompareTag("Bullet"))
                continue;
            
            // If the collider belongs to a powerup, skip it
            if(colliders[i].CompareTag("Powerup"))
                continue;

            // If the collider belongs to the shooter, skip it
            if(colliders[i].CompareTag(m_Friend))
                continue;

            // If the collider belongs to enemy view detection, skip it
            if (colliders[i].CompareTag("EnemyView"))
                continue;
            
            // If the owner is an "enemy", deal damage to the enemy
            if(colliders[i].CompareTag(m_Enemy))
            {
                // Grab the target's rigidbody
                Rigidbody2D targetRigidbody = colliders[i].GetComponent<Rigidbody2D>();

                // Grab the enemy's health script
                HealthScript health = targetRigidbody.GetComponent<HealthScript>();

                // Deal damage to the enemy
                health.TakeDamage(m_Damage);
            }

            // It hits an enemy/wall/something, so destroy the bullet
            Destroy(gameObject);
        }
    }

    public void setDamage(float amount)
    {
        m_Damage = amount;
    }
}
