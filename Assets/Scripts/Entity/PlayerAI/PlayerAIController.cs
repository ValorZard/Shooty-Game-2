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

    void Awake()
    {
        m_Health = GetComponentInChildren<BaseHealthScript>();
        m_Shooting = GetComponentInChildren<EnemyShooting>();
    }

    private void Pursue()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, target.position, m_MoveSpeed * Time.deltaTime);
    }

    private void Follow()
    {
        
    }

    private void Evade()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, target.position, -m_MoveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // If the target exists AND the speed is NOT 0, run
        if (target != null)
        {
            // Get distance from target
            float distanceFromTarget = Vector2.Distance(target.position, transform.position);

            Pursue();

            if (distanceFromTarget < shootingRange)
            {
                Evade();
            }
        }
    }

    public bool GetDetection() { return enemyDetectionArea; }
    public void SetDetection(bool b) { enemyDetectionArea = b; }
}
