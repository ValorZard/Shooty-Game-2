/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Base code,
            added NavMesh rotation code,
            added wander action
        Manhattan: Refactoured for better encapsulation
*/

using UnityEngine;
using UnityEngine.AI;

public class EnemyController : AIController
{
    // Private variables
        // Would the enemy flee?
        [SerializeField] private bool m_CanFlee;
        // Is the enemy currently fleeing?
        private bool m_IsFleeing = false;
        // Where to wander to
        private Vector2 m_WanderTarget;

        NavMeshAgent agent;

    protected override void OnStart()
    {
        m_Shooting = GetComponentInChildren<EnemyShooting>();
        m_WanderTarget = Vector2.zero;

        // Fix rotation of NavMesh agent
        agent = GetComponent<NavMeshAgent>();
        if(AgentExists())
        {
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }
    }

    private void Wander()
    {
        float wanderRadius = 5;

        m_WanderTarget += new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

        m_WanderTarget.Normalize();
        m_WanderTarget *= wanderRadius;

        Vector2 targetWorld = this.gameObject.transform.InverseTransformVector(m_WanderTarget);

        Seek(targetWorld);
    }

    private void Seek(Vector2 location)
    {
        if(AgentExists())
            agent.SetDestination(location);
        
        // Has the enemy been interrupted by seeing the player?
        if(!m_DetectionArea)
        {
            // Has the location been reached yet?
            if(transform.position.x != m_WanderTarget.x
                && transform.position.y != m_WanderTarget.y)
            {
                // If not, travel toward the location
                float horizontal = m_WanderTarget.x - transform.position.x;
                float vertical = m_WanderTarget.y - transform.position.y;
                Rigidbody2D body = GetComponent<Rigidbody2D>();
                body.velocity = new Vector2(horizontal, vertical).normalized * m_MoveSpeed;
            }
        }
    }

    protected override void Pursue()
    {
        Vector2 targetDir = target.transform.position - this.transform.position;

        float relativeHeading = Vector2.Angle(this.transform.forward, this.transform.TransformVector(target.transform.forward));
        float toTarget = Vector2.Angle(this.transform.forward, this.transform.TransformVector(targetDir));

        if ((toTarget > 90 && relativeHeading < 20) || m_MoveSpeed < 0.01f)
        {
            Seek(target.transform.position);
            return;
        }

        float lookAhead = targetDir.magnitude / (m_MoveSpeed);
        Seek(target.transform.position + target.transform.forward * lookAhead);
    }

    private void Flee(Vector3 location)
    {
        Vector3 fleeVector = (location - this.transform.position * 2.0f);

        if(AgentExists())
            agent.SetDestination(this.transform.position - fleeVector);
    }
  
    protected override void Evade()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        if(AgentExists())
        {
            float lookAhead = targetDir.magnitude / (agent.speed);
            Flee(target.transform.position + target.transform.forward * lookAhead);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the target exists, run
        if(target != null)
        {
            // Get distance from player
            float distanceFromPlayer = Vector2.Distance(target.position, transform.position);

            if (m_DetectionArea && distanceFromPlayer > m_ShootingRange && !m_IsFleeing)
            {
                //Enemy will pursue player on sight
                Debug.Log("ENEMY PURSUING");
                Pursue();

                if (m_Health.GetCurrentHealth() < 40.0f && m_CanFlee)
                {
                    m_IsFleeing = true;
                    // The enemy stops shooting while fleeing
                    m_Shooting.enabled = false;
                    //Enemy will flee the scene
                    Debug.Log("ENEMY FLEEING");
                }

            }
            else if(distanceFromPlayer < m_ShootingRange)
            {
                //Enemy will backup if the player is too close
                Debug.Log("ENEMY DISTANCING");
                Evade();
            }
        }
        else
        {
            Debug.Log("ENEMY WANDERING");
            Wander();
        }
    }

    // Does the agent exist?
    private bool AgentExists()
    {
        return agent != null && agent.enabled;
    }
}
