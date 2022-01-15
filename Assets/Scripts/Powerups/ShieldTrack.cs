using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTrack : MonoBehaviour
{
    // Public variables
        // Prefab of the player
        public Rigidbody2D m_Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player exists...
        if(m_Player != null)
            // Teleports to the player's location
            transform.position = m_Player.position;
    }
}
