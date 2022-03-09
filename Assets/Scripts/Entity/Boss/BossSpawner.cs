using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject boss;

    private Transform bossLocation;

    void Start()
    {
        bossLocation = this.gameObject.transform.GetChild(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(boss, bossLocation.position, bossLocation.rotation);
            Destroy(this.gameObject);
        }
    }
}
