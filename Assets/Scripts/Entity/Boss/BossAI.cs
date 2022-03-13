/*
    Programmers: Derek Chan, Manhattan Calabro
        Derek: Base code
        Manhattan: Refactoured for better encapsulation,
            refactoured player-finding
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    // Private variables
        // Is the boss attacking?
        private bool isAttacking = false;
        // The player closest to the boss
        private GameObject closestPlayer;
        // The player farthest to the boss
        private GameObject fartherPlayer;
        // Reference to the boss attacking script
        private BossAttacks attacks;
        // Reference to the players
        private FindEntities m_Players;

    // Start is called before the first frame update
    void Start()
    {
        attacks = this.gameObject.GetComponent<BossAttacks>();

        // Grab the players
        m_Players = GameObject.FindObjectOfType<FindEntities>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the active players
        getPlayers();

        // If the boss isn't attacking yet...
        if(isAttacking == false)
        {
            // ... choose a random attack
            float rng = Random.Range(0.0f, 1.0f);
            if(rng < 0.2f)
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

    // Finds the closest and farthest players
    private void getPlayers()
    {
        // Initialize the player list
        List<GameObject> players = m_Players.GetPlayersRefresh();
        
        // If there is only one player...
        if(players.Count == 1)
        {
            // ... the player is both targets
            closestPlayer = players[0];
            fartherPlayer = players[0];
        }

        // Otherwise, if there's two players...
        else if (players.Count == 2)
        {
            // Run if the first player is closer
            if (Vector3.Distance(this.transform.position, players[0].transform.position) <= Vector3.Distance(this.transform.position, players[1].transform.position))
            {
                closestPlayer = players[0];
                fartherPlayer = players[1];
            }
            // Otherwise, the second player is closer
            else
            {
                closestPlayer = players[1];
                fartherPlayer = players[0];
            }
        }

        // It shouldn't come to this, since there should only be two players
        else
        {
            // what
            Debug.Log("what");
        }
    }

    public void SetAttacking(bool b) { isAttacking = b; }
}
