using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * Srayan Jana, Pedro Longo, Manhattan Calabro
 *  - Srayan: Refactored code
 *  - Manhattan: Added check for whether target exists (that way, there won't be several console exceptions),
        changed name of variable so it doesn't hide inherited member,
        refactoured for better encapsulation
    - Pedro: Base code, Added NavMesh rotation code, added pursuit, evade and wander actions for enemy
 */

public class EnemyController : MonoBehaviour
{
    //public variables
    [SerializeField] private float speed = 2.0f;
    public bool playerDetectionArea;
    [SerializeField] private float shootingRange = 4.0f;
    // The target to attack
    public Transform target;

    // Would the enemy flee?
    [SerializeField] private bool m_CanFlee;
    // Is the enemy currently fleeing?
    private bool m_IsFleeing = false;

    NavMeshAgent agent;

    // Reference to the health script
    private BaseHealthScript m_Health;
    // Reference to the shooting script
    private EnemyShooting m_Shooting;
    // Where to wander to
    private Vector2 m_WanderTarget;

    void Awake()
    {
        m_Health = GetComponentInChildren<BaseHealthScript>();
        m_Shooting = GetComponentInChildren<EnemyShooting>();
        m_WanderTarget = Vector2.zero;
    }

    private void Start()
    {
        // Fic rotation of NavMesh agent
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Seek(Vector2 location)
    {
        // Only run if the agent exists
        if(agent.enabled)
            agent.SetDestination(location);
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

    private void Pursue()
    {
        Vector2 targetDir = target.transform.position - this.transform.position;

        float relativeHeading = Vector2.Angle(this.transform.forward, this.transform.TransformVector(target.transform.forward));
        float toTarget = Vector2.Angle(this.transform.forward, this.transform.TransformVector(targetDir));

        if ((toTarget > 90 && relativeHeading < 20) || speed < 0.01f)
        {
            Seek(target.transform.position);
            return;
        }


        float lookAhead = targetDir.magnitude / (speed);
        Seek(target.transform.position + target.transform.forward * lookAhead);
    }

    private void Flee(Vector3 location)
    {
        Vector3 fleeVector = (location - this.transform.position * 2.0f);

        // Only run if the agent exists
        if(agent.enabled)
            agent.SetDestination(this.transform.position - fleeVector);
    }

    private void Evade()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        float lookAhead = targetDir.magnitude / (agent.speed);
        Flee(target.transform.position + target.transform.forward * lookAhead);

    }

    // Update is called once per frame
    void Update()
    {
        // If the target exists AND the speed is NOT 0, run
        if(target != null)
        {
            // Get distance from player
            float distanceFromPlayer = Vector2.Distance(target.position, transform.position);

            if (playerDetectionArea && distanceFromPlayer > shootingRange && !m_IsFleeing)
            {
                //transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
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
            else if(distanceFromPlayer < shootingRange )
            {
                //Enemy will backup if the player is too close
                //transform.position = Vector2.MoveTowards(this.transform.position, target.position, -speed * Time.deltaTime);
                Debug.Log("ENEMY DISTANCING");
                Evade();
            }
        }
        else
        {
            Wander();
        }
    }
}
