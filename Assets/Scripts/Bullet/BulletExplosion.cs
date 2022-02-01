/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    // Public variables
        // How long the explosion will be active for
        public float m_MaxTime;
        // Damage done to an enemy caught up in the explosion
        public float m_Damage;
        // The force exerted to an enemy (pushes them away)
        public float m_Force = 10f;
        // The tag of friends to NOT hurt
        public string m_Friend;
        // The tag of enemies to hurt
        public string m_Enemy;
    
    // Private variables
        // Reference to the explosion's collider
        private CircleCollider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the object's collider
        m_Collider = GetComponent<CircleCollider2D>();

        Destroy(gameObject, m_MaxTime);
    }

    // Specifically has to be done in FixedUpdate
    // If done in any OnTrigger or OnCollision method, if the explosion spawns on top of the player, it won't track their collisions
    void FixedUpdate()
    {
        // The list of colliders currently touching this object
        List<Collider2D> colliders = new List<Collider2D>();
        m_Collider.OverlapCollider(new ContactFilter2D().NoFilter(), colliders);

        // Go through all the colliders
        for(int i = 0; i < colliders.Count; i++)
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
            if(colliders[i].CompareTag("EnemyView"))
                continue;
            
            // If the owner is an enemy, deal damage to the enemy
            if(colliders[i].CompareTag(m_Enemy))
            {
                // Grab the target's rigidbody
                Rigidbody2D targetRigidbody = colliders[i].GetComponent<Rigidbody2D>();

                // Grab the enemy's health script
                HealthScript health = targetRigidbody.GetComponent<HealthScript>();

                // Deal damage to the enemy
                health.TakeDamage(m_Damage);

                // Find the horizontal direction
                float horizontalForce = targetRigidbody.transform.localPosition.x - transform.localPosition.x;

                // Find the vertical direction
                float verticalForce = targetRigidbody.transform.localPosition.y - transform.localPosition.y;

                // Add force
                targetRigidbody.AddForce(new Vector2(horizontalForce, verticalForce).normalized * m_Force);
            }
        }
    }
}