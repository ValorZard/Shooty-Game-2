using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

/*
    Programmer: Pedro Longo,
    Pedro: Base code,
        Added NavMesh rotation code,
        added pursuit,
        evade and wander actions for enemy
*/

public class PlayerAIController : MonoBehaviour
{
    // Private variables
    // The enemy's movement speed
    [SerializeField] private float m_MoveSpeed = 2.0f;
    // Does the enemy see a player?
    private bool enemyDetectionArea;
    [SerializeField] private float shootingRange = 4.0f;
    // The target to attack
    public Transform target;
    // Reference to the health script
    private BaseHealthScript m_Health;
    // Reference to the shooting script
    private EnemyShooting m_Shooting;
    //Player to follow
    private GameObject m_Player;

    void Awake()
    {
        m_Health = GetComponentInChildren<BaseHealthScript>();
        m_Shooting = GetComponentInChildren<EnemyShooting>();
    }

    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Pursue()
    {
        /*
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
        */

        transform.position = Vector2.MoveTowards(this.transform.position, target.position, m_MoveSpeed * Time.deltaTime);
    }

    private void Follow()
    {
        
    }

    /*
    private void Flee(Vector3 location)
    {
        Vector3 fleeVector = (location - this.transform.position * 2.0f);

        // Only run if the agent exists
        if(agent.enabled)
            agent.SetDestination(this.transform.position - fleeVector);
    }
    */

    private void Evade()
    {
        /*
        Vector3 targetDir = target.transform.position - this.transform.position;
        float lookAhead = targetDir.magnitude / (agent.speed);
        Flee(target.transform.position + target.transform.forward * lookAhead);
        */

        transform.position = Vector2.MoveTowards(this.transform.position, target.position, -m_MoveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // If the target exists AND the speed is NOT 0, run
        if (target != null)
        {
            // Get distance from target
            float distanceFromEnemy = Vector2.Distance(target.position, transform.position);

            Pursue();

            if (distanceFromEnemy < shootingRange)
            {
                Evade();
            }
        }
    }

    public bool GetDetection() { return enemyDetectionArea; }
    public void SetDetection(bool b) { enemyDetectionArea = b; }
}
