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
    private void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            // Collect all the colliders around the bullet
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, m_Collider.radius);

            // Go through all the colliders
            for(int i = 0; i < colliders.Length; i++)
            {
                // If the collider is ignorable, skip it
                if(CheckTag(colliders[i]))
                    continue;
                
                // If the owner is an "enemy", deal damage to the enemy
                if(colliders[i].CompareTag(m_Enemy))
                    DealDamage(colliders[i]);

                // It hits an enemy/wall/something, so destroy the bullet
                Destroy(gameObject);
            }
        }
        catch
        {
            CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();

            // Collect all the colliders around the bullet
            Collider2D[] colliders = Physics2D.OverlapCapsuleAll(transform.position, capsule.size, capsule.direction, capsule.transform.rotation.z);

            // Go through all the colliders
            for(int i = 0; i < colliders.Length; i++)
            {
                // If the collider is ignorable, skip it
                if(CheckTag(colliders[i]))
                    continue;
                
                // If the owner is an "enemy", deal damage to the enemy
                if(colliders[i].CompareTag(m_Enemy))
                    DealDamage(colliders[i]);

                // It hits an enemy/wall/something, so destroy the bullet
                Destroy(gameObject);
            }
        }
    }
}
