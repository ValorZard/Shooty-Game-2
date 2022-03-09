// Written by Derek Chan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public bool isAttacking = false;

    private GameObject closestPlayer;
    private GameObject fartherPlayer;

    private BossAttacks attacks;

    // Start is called before the first frame update
    void Start()
    {
        getPlayers();
        attacks = this.gameObject.GetComponent<BossAttacks>();
    }

    // Update is called once per frame
    void Update()
    {
        getPlayers();
        if(isAttacking == false)
        {
            float rng = Random.Range(0.0f, 1.0f);
            if(rng < 0.20f)
            {
                isAttacking = true;
                attacks.execute("Adds", closestPlayer, fartherPlayer);
            }
            else if(rng < 0.4f)
            {
                isAttacking = true;
                attacks.execute("Beam", closestPlayer, fartherPlayer);
            }
            else if(rng < 0.6f)
            {
                isAttacking = true;
                attacks.execute("AOE", closestPlayer, fartherPlayer);
            }
            else if(rng < 0.8f)
            {
                isAttacking = true;
                attacks.execute("Moving", closestPlayer, fartherPlayer);
            }
            else
            {
                isAttacking = true;
                attacks.execute("Melee", closestPlayer, fartherPlayer);
            }
        }
    }

    void getPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length == 1)
        {
            closestPlayer = players[0];
            fartherPlayer = players[0];
        }
        else if (players.Length == 2)
        {
            if (Vector3.Distance(this.transform.position, players[0].transform.position) <= Vector3.Distance(this.transform.position, players[1].transform.position))
            {
                closestPlayer = players[0];
                fartherPlayer = players[1];
            }
            else
            {
                closestPlayer = players[1];
                fartherPlayer = players[0];
            }
        }
        else
        {
            Debug.Log("what");
        }
    }
}
