/*
    Programmers: Manhattan Calabro, Pedro Longo
        Manhattan: Created BaseShooting,
            added check for whether target exists (that way, there won't be several console exceptions),
            refactoured for better encapsulation
        Pedro: Added target and direction to shooting
*/

using UnityEngine;

abstract public class AIShooting : BaseShooting
{
    // Protected variables
        // For getting enemy sight
        protected AIController m_Script;

    // If the current delay is zero, they can shoot
    public override bool CheckShootStatus()
    {
        return m_CurrentDelay == 0;
    }

    // Instantiate the bullet
    protected override void Fire()
    {
        // If the target exists, run
        if(m_Script.target != null)
        {
            // UPDATED (Pedro Longo)
            // Get position of player in sight
            if (m_Script.GetDetection())
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
        return moveDir;
    }
}
