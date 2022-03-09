// Written by Derek Chan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public GameObject melee;
    public GameObject beam;
    public GameObject aoe;
    public GameObject moving;
    public GameObject enemy;

    private BossAI ai;
    private GameObject[] addSpawners;

    // Start is called before the first frame update
    void Start()
    {
        ai = this.gameObject.GetComponent<BossAI>();
        addSpawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    public void execute(string s, GameObject closestPlayer, GameObject fartherPlayer)
    {
        if(s == "Melee")
        {
            GameObject attack = Instantiate(melee, this.transform.position, this.transform.rotation);
            Invoke("delay", attack.GetComponent<BossStandardAttack>().totalTime + 1.0f);
        }
        if(s == "Beam")
        {
            lookAt2D(closestPlayer);
            GameObject attack = Instantiate(beam, this.transform.position, this.transform.rotation);
            Invoke("delay", attack.GetComponent<BossStandardAttack>().totalTime + 1.0f);
        }
        if(s == "AOE")
        {
            if(fartherPlayer == closestPlayer)
            {
                GameObject attack = Instantiate(aoe, closestPlayer.transform.position, this.transform.rotation);
                Invoke("delay", attack.GetComponent<BossStandardAttack>().totalTime + 1.0f);
            }
            else
            {
                GameObject attack = Instantiate(aoe, closestPlayer.transform.position, this.transform.rotation);
                GameObject attack2 = Instantiate(aoe, fartherPlayer.transform.position, this.transform.rotation);
                Invoke("delay", attack.GetComponent<BossStandardAttack>().totalTime + 1.0f);
                Invoke("delay", attack2.GetComponent<BossStandardAttack>().totalTime + 1.0f);
            }
        }
        if(s == "Moving")
        {
            lookAt2D(fartherPlayer);
            Instantiate(moving, this.transform.position, this.transform.rotation);
            Invoke("delay", 2.0f);
        }
        if(s == "Adds")
        {
            foreach (GameObject spawner in addSpawners)
            {
                Instantiate(enemy, spawner.transform.position, spawner.transform.rotation);
                Invoke("delay", 4.0f);
            }
        }
    }

    private void delay()
    {
        ai.isAttacking = false;
    }

    private void lookAt2D(GameObject target)
    {
        Vector2 dir = target.transform.position - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
