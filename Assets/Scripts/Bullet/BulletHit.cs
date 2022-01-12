// Programmer: Manhattan Calabro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    // Private variables
        // Reference to the bullet's collider
        private CircleCollider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<CircleCollider2D>();

        // here until other objects with collision are added, that way the game isn't bogged down by the amount of bullet prefabs flying around
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Collect all the colliders around the bullet
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_Collider.radius);

        // Go through all the colliders
        for(int i = 0; i < colliders.Length; i++)
        {
            // NOTE: give the player a collider
            // If the owner is a player, go on to the next collider
            if(false)
                continue;

            // If the owner is an enemy, deal damage to the enemy

            // Otherwise, it hits a wall or something, so destroy the bullet
            Destroy(gameObject);

            // is it possible that bullets will be immediately destroyed by detecting the player? check after giving the player a collider
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
