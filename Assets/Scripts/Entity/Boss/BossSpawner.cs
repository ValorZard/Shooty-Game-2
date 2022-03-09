/*
    Programmers: Derek Chan, Manhattan Calabro
        Derek: Base code
        Manhattan: Refactoured for better encapsulation,
            added boss tracker
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    // Private variables
        // Prefab of the boss
        [SerializeField] private GameObject boss;
        // Where the boss will spawn
        private Transform bossLocation;
        // Prefab of the boss tracker
        [SerializeField] private GameObject m_BossTracker;

    void Start()
    {
        // Grab the location from the child
        bossLocation = this.gameObject.transform.GetChild(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // When the player enters the room...
        if(other.gameObject.tag == "Player")
        {
            // ... spawn the boss
            GameObject spawned = Instantiate(boss, bossLocation.position, bossLocation.rotation);

            // Spawn the boss tracker
            GameObject tracker = Instantiate(m_BossTracker, m_BossTracker.transform.position, m_BossTracker.transform.rotation);

            // Assign the boss to the boss tracker to track
            tracker.GetComponent<BossTracker>().SetBoss(spawned);

            // Destroy the spawner; it's no longer needed
            Destroy(this.gameObject);
        }
    }
}
