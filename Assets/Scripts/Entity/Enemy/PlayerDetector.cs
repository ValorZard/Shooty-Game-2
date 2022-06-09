/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Base code
        Manhattan: Added special enemy type checking
*/

using UnityEngine;

public class PlayerDetector : AIDetector
{
    // Private variables
        // The current amount of time before the enemy forgets the player
        [SerializeField] private float m_CurrentTime = 0;
        // The amount of time that should pass before the enemy forgets the player
        private float m_ActiveTime = 3;

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

    // Update is called once per frame
    void Update()
    {
        // Only run if a target has been assigned
        if(m_Movement.target != null)
        {
            // Only run if there are no targets within vicinity
            if(!m_EnemyInVicinity)
            {
                // If a certain amount of time has passed, reset the target
                if(m_CurrentTime >= m_ActiveTime)
                {
                    ResetTarget();
                    m_CurrentTime = 0;
                }
                else
                    m_CurrentTime += Time.deltaTime;
            }
            else
                m_CurrentTime = 0;
        }
        else
            m_CurrentTime = 0;
    }

    protected override void ResetTarget()
    {
        // There is no valid target
        m_Movement.target = null;
    }
}