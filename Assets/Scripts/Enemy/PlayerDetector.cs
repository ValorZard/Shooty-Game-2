using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Srayan Jana, Pedro Longo
 *  - Srayan: refactored code to its own class
 */


public class PlayerDetector : MonoBehaviour
{
    private EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.transform.parent.gameObject.GetComponent<EnemyController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Whenever a player enters enemy sight it will target them
        if (collision.gameObject.tag == "Player")
        {
            enemy.playerInSight = true;

            //set new target
            enemy.target = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If player exits enemy sight it will stop pursuing
        if (collision.gameObject.tag == "Player")
        {
            enemy.playerInSight = false;

            //restart target
            enemy.target = null;
        }
    }
}
