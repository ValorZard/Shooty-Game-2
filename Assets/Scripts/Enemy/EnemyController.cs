using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * Srayan Jana, Pedro Longo, Manhattan Calabro
 *  - Srayan: Refactored code
 *  - Manhattan: Added check for whether target exists (that way, there won't be several console exceptions),
                 changed name of variable so it doesn't hide inherited member
    - Pedro: Base code, Added NavMesh rotation code, added pursuit and wander actions for enemy
 */

public class EnemyController : MonoBehaviour
{
    //public variables
    public float speed = 2.0f;
    public bool playerDetectionArea;
    public bool playerInSight;
    public float shootingRange = 4.0f;
    public GameObject player;
    public Transform target;
    public float distanceFromPlayer;

    public NavMeshAgent agent;

    private CircleCollider2D m_Collider;

    private Vector2 wanderTarget = Vector2.zero;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_Collider = GetComponentInChildren<CircleCollider2D>();
    }

    private void Start()
    {
        //Fic rotation of NavMesh agent
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Seek(Vector2 location)
    {
        agent.SetDestination(location);
    }

    private void Wander()
    {
        float wanderRadius = 5;

        wanderTarget += new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector2 targetWorld = this.gameObject.transform.InverseTransformVector(wanderTarget);

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
        Vector3 fleeVector = location - this.transform.position;
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
        // If the target exists, run
        if(target != null)
        {
            // Get distance from player
            distanceFromPlayer = Vector2.Distance(target.position, transform.position);

            if (playerDetectionArea == true && distanceFromPlayer > shootingRange)
            {
                //Enemy will pursue player on sight
                //transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
                Pursue();
            }
            else if(distanceFromPlayer < shootingRange)
            {
                //Enemy will backup if the player is too close
                //transform.position = Vector2.MoveTowards(this.transform.position, target.position, -speed * Time.deltaTime);
                Evade();
            }
        }
        else
        {
            Wander();
        }
    }

    /*
    // the following two functions are for the targeting and tracking of players

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Whenever a player enters enemy sight it will target them
        if(collision.gameObject.tag == "Player")
        {
            playerInSight = true;

            //set new target
            target = collision.gameObject.transform;     
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If player exits enemy sight it will stop pursuing
        if(collision.gameObject.tag == "Player")
        {
            playerInSight = false;

            //restart target
            target = null;
        }
    }
    */
}
