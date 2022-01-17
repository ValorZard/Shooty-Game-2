// Programmer: Manhattan Calabro

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

        // here until other objects with collision are added, that way the game isn't bogged down by the amount of bullet prefabs flying around
        // EDIT: collision with other objects has been added; however, the player can just walk out of bounds and shoot an infinite number of bullets into the distance. remove this destroy command once the player is trapped
        Destroy(gameObject, 2f);
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
            
            // If the owner is an "enemy", deal damage to the enemy
            if(colliders[i].CompareTag(m_Enemy))
            {
                // Grab the enemy's rigidbody
                Rigidbody2D targetRigidBody = colliders[i].GetComponent<Rigidbody2D>();

                // Grab the enemy's health script
                HealthScript enemyHealth = targetRigidBody.GetComponent<HealthScript>();

                // Deal damage to the enemy
                enemyHealth.TakeDamage(m_Damage);
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
