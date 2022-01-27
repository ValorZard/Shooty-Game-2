using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Srayan Jana, Pedro Longo
 *  - Srayan: Refactored code
 */

public class EnemyController : MonoBehaviour
{
    //public variables
    public float speed = 2.0f;
    public bool playerInSight;
    public GameObject player;
    public Transform target;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInSight)
        {
            //Enemy will pursue player on sight
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
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
