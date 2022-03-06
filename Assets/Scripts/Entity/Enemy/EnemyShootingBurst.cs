/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingBurst : EnemyShooting
{
    // Private variables
        // The angle to shoot in
        private float m_Angle = 15f;

    // Instantiate a ring of bullets
    protected override void Fire()
    {
        // If the target exists, run
        if(m_Script.target != null)
        {
            // The current angle to shoot in
            float angle = 0f;

            // Repeat until angle is greater than or equal to 360
            while(angle < 360)
            {
                // Shoot the bullet
                LaunchBullet(CalculateVelocity(angle));

                // Increment the angle
                angle += m_Angle;
            }
        }
    }

    // Calculate the velocity of the bullet
    protected Vector2 CalculateVelocity(float angle)
    {
        // Calculate the bullet's horizontal movement
        float horizontal = Mathf.Cos(angle * Mathf.Deg2Rad);

        // Calculate the bullet's vertical movement
        float vertical = Mathf.Sin(angle * Mathf.Deg2Rad);

        return new Vector2(horizontal, vertical);
    }
}
