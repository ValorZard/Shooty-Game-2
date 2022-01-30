using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Srayan Jana, Pedro Longo, Manhattan Calabro
 *  - Srayan: Refactored code
 *  - Manhattan: Added check for whether target exists (that way, there won't be several console exceptions)
 */

public class EnemyController : MonoBehaviour
{
    //public variables
    public float speed = 2.0f;
    public bool playerInSight;
    public float shootingRange = 4.0f;
    public GameObject player;
    public Transform target;

    private CircleCollider2D collider;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collider = GetComponentInChildren<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the target exists, run
        if(target != null)
        {
            // Get distance from player
            float distanceFromPlayer = Vector2.Distance(target.position, transform.position);

            if (playerInSight == true && distanceFromPlayer > shootingRange)
            {
                //Enemy will pursue player on sight
                transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
            }
            else if(distanceFromPlayer < shootingRange)
            {
                //Enemy will backup if the player is too close
                transform.position = Vector2.MoveTowards(this.transform.position, target.position, -speed * Time.deltaTime);
            }
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
