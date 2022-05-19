/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : TeleportBaseInScene
{
    // Private variables
        // The linked teleporter
        [SerializeField] private GameObject m_Link;

    protected override void EnterComplete(Collider2D other)
    {
        // Create a burst of particles at the player's position before teleporting
        Instantiate(m_Particles, other.transform.position, other.transform.rotation);

        // Teleport the player
        other.transform.position = new Vector3(m_Link.transform.position.x,
                                            m_Link.transform.position.y,
                                            other.transform.position.z);

        // Create another burst of particles at the player's position after teleporting
        Instantiate(m_Particles, other.transform.position, other.transform.rotation);

        // Disable the linked teleporter (prevents repeated teleportation)
        m_Link.GetComponent<Teleport>().Disable();

        // Perform the player's exit teleport animation
        TeleportAnimation anim = other.GetComponentInChildren<TeleportAnimation>();
        anim.SetExit(true);
        anim.SetEnter(false);
    }

    // Only run when the player first STOPS touching the teleporter
    private void OnTriggerExit2D(Collider2D other)
    {
        // If the player stops touching the teleporter...
        if(IsPlayer(other))
        {
            // Enable the teleporter
            Enable();
        }
    }
}
