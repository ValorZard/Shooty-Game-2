/*
    Programmers: Derek Chan, Manhattan Calabro
        Derek: Base code
        Manhattan: Refactoured for better encapsulation,
                   fixed beam rotation
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    // Private variables
        // Prefab of the melee attack
        [SerializeField] private GameObject melee;
        // Prefab of the beam attack
        [SerializeField] private GameObject beam;
        // Prefab of the AOE attack
        [SerializeField] private GameObject aoe;
        // Prefab of the moving attack
        [SerializeField] private GameObject moving;
        // Prefab of the basic enemy
        [SerializeField] private GameObject enemy;
        // Reference to the AI script
        private BossAI ai;
        // Reference to the enemy spawners
        private GameObject[] addSpawners;
        // Rest time before the boss attacks again
        [SerializeField] private float m_RestTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        ai = this.gameObject.GetComponent<BossAI>();
        addSpawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Executes an attack, depending on the input
    public void execute(string s, GameObject closestPlayer, GameObject fartherPlayer)
    {
        if(s == "Melee")
        {
            // Performs a sweeping melee attack centered on the boss
            GameObject attack = Instantiate(melee, this.transform.position, this.transform.rotation);
            Invoke("delay", attack.GetComponent<BossStandardAttack>().GetTotalTime() + m_RestTime);
        }

        else if(s == "Beam")
        {
            // Shoots a beam aimed at the closest player
            GameObject attack = Instantiate(beam, this.transform.position, lookAt2D(closestPlayer) * Quaternion.Euler(0, 0, 90));
            Invoke("delay", attack.GetComponent<BossStandardAttack>().GetTotalTime() + m_RestTime);
        }

        else if(s == "AOE")
        {
            // Spawns on AOE attack on each player
            if(fartherPlayer == closestPlayer)
            {
                GameObject attack = Instantiate(aoe, closestPlayer.transform.position, this.transform.rotation);
                Invoke("delay", attack.GetComponent<BossStandardAttack>().GetTotalTime() + m_RestTime);
            }
            else
            {
                GameObject attack = Instantiate(aoe, closestPlayer.transform.position, this.transform.rotation);
                GameObject attack2 = Instantiate(aoe, fartherPlayer.transform.position, this.transform.rotation);
                Invoke("delay", attack.GetComponent<BossStandardAttack>().GetTotalTime() + m_RestTime);
                Invoke("delay", attack2.GetComponent<BossStandardAttack>().GetTotalTime() + m_RestTime);
            }
        }

/*
        else if(s == "Moving")
        {
            // Shoot a moving attack at the farthest player
            Instantiate(moving, this.transform.position, lookAt2D(fartherPlayer));
            Invoke("delay", m_RestTime*2);
        }

        else if(s == "Adds")
        {
            // Spawns a gorup of enemies
            foreach (GameObject spawner in addSpawners)
            {
                Instantiate(enemy, spawner.transform.position, enemy.transform.rotation);
                Invoke("delay", m_RestTime*4);
            }
        }
*/
    }

    private void delay()
    {
        ai.SetAttacking(false);
    }

    // Returns a rotation pointed at the target
    private Quaternion lookAt2D(GameObject target)
    {
        Vector2 dir = target.transform.position - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
