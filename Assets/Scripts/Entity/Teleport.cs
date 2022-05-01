/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Private variables
        // The linked teleporter
        [SerializeField] private GameObject m_Link;
        // Can the player use the teleporter?
        private bool m_Active;
        // The player tag to track
        private string m_Tag = "Player";
        // Prefab of player teleportation particles
        [SerializeField] private GameObject m_Particles; 

    // Start is called before the first frame update
    void Start()
    {
        Enable();
    }

    // Run while the player is still inside the teleporter
    private void OnTriggerStay2D(Collider2D other)
    {
        // If the player is touching the teleporter...
        if(other.CompareTag(m_Tag))
        {
            // Grab the player's teleport animation script
            TeleportAnimation anim = other.GetComponentInChildren<TeleportAnimation>();
            // Grab the player's movement script
            PlayerController move = other.GetComponentInChildren<PlayerController>();

            // If the teleporter is active...
            if(m_Active)
            {
                // Only run once
                if(move.enabled)
                {
                    // If the player stops moving during the teleportation process...
                    if(other.GetComponentInChildren<Rigidbody2D>().velocity == Vector2.zero)
                    {
                        // ... disable the player's movement (so they don't move away from the teleporter during the teleportation animation)
                        move.enabled = false;

                        // Perform the player's enter teleport animation
                        anim.SetEnter(true);
                    }
                }

                // If the enter animation is complete...
                if(anim.GetEnterFinished())
                {
                    // ... create a burst of particles at the player's position before teleporting
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
                    anim.SetExit(true);
                    anim.SetEnter(false);
                }
            }

            // Otherwise, the teleporter isn't active...
            else
            {
                // If the exit animation is complete...
                if(anim.GetExitFinished())
                {
                    // ... enable the player's movement
                    move.enabled = true;

                    // Stop the player's exit teleport animation
                    anim.SetExit(false);
                }
            }
        }
    }

    // Only run when the player first STOPS touching the teleporter
    private void OnTriggerExit2D(Collider2D other)
    {
        // If the player stops touching the teleporter...
        if(other.CompareTag(m_Tag))
        {
            // Enable the teleporter
            Enable();
        }
    }

    public void Enable()
    {
        // The player can use the teleporter
        m_Active = true;

        // Enable the particle system
        GetComponentInChildren<ParticleSystem>().Play();
    }
    public void Disable()
    {
        // The player can't use the teleporter
        m_Active = false;

        // Disable the particle system
        GetComponentInChildren<ParticleSystem>().Stop();
    }
}
