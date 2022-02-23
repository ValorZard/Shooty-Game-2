/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingBurst : EnemyShooting
{
    // Public variables
        // The angle to shoot in
        public float m_Angle = 15f;

    // Instantiate a ring of bullets
    protected override void Fire()
    {
        // If the target exists, run
        if(enemy.target != null)
        {
            // The current angle to shoot in
            float angle = 0f;

            // Repeat until angle is greater than or equal to 360
            while(angle < 360)
            {
                // Calculate the bullet's horizontal movement
                float horizontal = Mathf.Cos(angle * Mathf.Deg2Rad);

                // Calculate the bullet's vertical movement
                float vertical = Mathf.Sin(angle * Mathf.Deg2Rad);

                // Get the velocity
                Vector2 velocity = new Vector2(horizontal, vertical);

                // Create an instance of the bullet and store a reference to its rigidbody
                Rigidbody2D bulletInstance = Instantiate(m_Bullet, transform.position, transform.rotation) as Rigidbody2D;

                // Grab the bullet script
                BulletHit bulletScript = bulletInstance.GetComponent<BulletHit>();

                // Set the attack power of the bullet
                bulletScript.SetDamage(m_Damage);

                // Set the friendly tag
                bulletScript.SetFriend(m_Friend);

                // Set the enemy tag
                bulletScript.SetEnemy(m_Enemy);

                // Set the bullet's velocity
                bulletInstance.velocity = velocity.normalized * m_Speed;

                // Increment the angle
                angle += m_Angle;
            }
        }
    }
}
