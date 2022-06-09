/*
    Programmers: Manhattan Calabro, Pedro Longo
        Manhattan: Coded bullet collision,
            generalized code to work with multiple objects,
            refactoured for better encapsulation
        Pedro: Added collision conditions for "EnemyView"-type objects
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : BulletBase
{
    // Private variables
        // The transform of the instantiator
        private Transform m_Instantiator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D[] colliders = new Collider2D[0];

        // Run if the bullet is a circle
        if(GetComponent<CircleCollider2D>() != null)
            // Collect all the colliders around the bullet
            colliders = Physics2D.OverlapCircleAll(transform.position, m_Collider.radius);

        // Special case for the barrel bullet (capsule)
        else if(GetComponent<CapsuleCollider2D>() != null)
        {
            CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();

            // Collect all the colliders around the bullet
            colliders = Physics2D.OverlapCapsuleAll(transform.position, capsule.size, capsule.direction, capsule.transform.rotation.z);
        }

        // Go through all the colliders
        for(int i = 0; i < colliders.Length; i++)
        {
            // If the collider is ignorable, skip it
            if(CheckTag(colliders[i]))
                continue;
            
            // If the owner is an "enemy", deal damage to the enemy
            if(colliders[i].CompareTag(m_Enemy))
            {
                DealDamage(colliders[i]);

                // If the owner has a player detector, reassign the target
                if(colliders[i].GetComponentInChildren<PlayerDetector>() != null)
                    colliders[i].GetComponentInChildren<PlayerDetector>().ReassignTarget(m_Instantiator);
            }

            // It hits an enemy/wall/something, so destroy the bullet
            Destroy(gameObject);
        }
    }

    public void SetInstantiator(Transform trans) { m_Instantiator = trans; }
}
