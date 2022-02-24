/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : BulletBase
{
    // Private variables
        // The force exerted to an enemy (pushes them away)
        [SerializeField] private float m_Force = 10f;

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
            // If the collider is ignorable, skip it
            if(CheckTag(colliders[i]))
                continue;
            
            // If the owner is an enemy...
            if(colliders[i].CompareTag(m_Enemy))
            {
                // ... deal damage to the enemy
                DealDamage(colliders[i]);

                // Launch the target
                LaunchTarget(colliders[i]);
            }
        }
    }

    // Launches the target away
    private void LaunchTarget(Collider2D target)
    {
        // Grab the target's rigidbody
        Rigidbody2D targetRigidbody = target.GetComponent<Rigidbody2D>();

        // Find the horizontal direction
        float horizontalForce = targetRigidbody.transform.localPosition.x - transform.localPosition.x;

        // Find the vertical direction
        float verticalForce = targetRigidbody.transform.localPosition.y - transform.localPosition.y;

        // Add force
        targetRigidbody.AddForce(new Vector2(horizontalForce, verticalForce).normalized * m_Force);
    }
}