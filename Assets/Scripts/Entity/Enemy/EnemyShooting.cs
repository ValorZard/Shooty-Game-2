/*
    Programmers: Manhattan Calabro, Pedro Longo
        Manhattan: Created PlayerShooting (what this script is based off of),
            added check for whether target exists (that way, there won't be several console exceptions),
            added overriding (relevant for EnemyShootingBurst),
            refactoured for better encapsulation
        Pedro: Added target and direction to shooting
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : BaseShooting
{
    // Protected variables
        // For getting enemy sight
        protected EnemyController m_Script;

    protected override void InitializeShooting()
    {
        // Grab the enemy's movement script
        m_Script = GetComponent<EnemyController>();
    }

    // If the current delay is zero, the enemy can shoot
    public override bool CheckShootStatus()
    {
        return m_CurrentDelay == 0;
    }

    // Instantiate the bullet
    protected override void Fire()
    {
        // If the target exists, run
        if (m_Script.target != null)
        {
            // UPDATED (Pedro Longo)
            // Get position of player in sight
            if (m_Script.playerDetectionArea)
            {
                // Shoot the bullet
                AssignBullet(CalculateVelocity());
            }
        }
    }

    // Calculate the velocity of the bullet
    protected Vector2 CalculateVelocity()
    {
        // Initialize velocity
        Vector2 moveDir = (m_Script.target.transform.position - transform.position).normalized * m_Speed;
        return new Vector2(moveDir.x, moveDir.y);
    }
}
