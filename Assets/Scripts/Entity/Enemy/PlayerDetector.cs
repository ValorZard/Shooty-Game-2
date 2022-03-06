/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Base code
        Manhattan: Added special enemy type checking
*/

public class PlayerDetector : AIDetector
{
    // Start is called before the first frame update
    void Start()
    {
        // Grab the scripts
        m_Movement = GetComponentInParent<EnemyController>();
        m_Shooting = GetComponentInParent<EnemyShooting>();

        // Does the enemy have a special attack script?
        if(m_Shooting == null)
        {
            // Check if the enemy is a burst enemy
            if(GetComponentInParent<EnemyShootingBurst>() != null)
                m_Shooting = GetComponentInParent<EnemyShootingBurst>();

            // Check if the enemy is an explosive enemy
            else if(transform.parent.GetComponentInChildren<EnemyExplosive>() != null)
                m_Shooting = transform.parent.GetComponentInChildren<EnemyExplosive>();
        }
    }

    protected override void ResetTarget()
    {
        // There is no valid target
        m_Movement.target = null;
    }
}