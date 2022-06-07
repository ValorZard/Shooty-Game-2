/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TeleportBaseInScene : TeleportBase
{
    // Private variables
        // Prefab of the player teleportation particles
        [SerializeField] protected GameObject m_Particles;

    protected override void MoveEnabled(Collider2D other)
    {
        // Grab the player's teleport animation script
        TeleportAnimation anim = other.GetComponentInChildren<TeleportAnimation>();
        // Grab the player's movement script
        PlayerController move = other.GetComponentInChildren<PlayerController>();

        // If the player stops moving during the teleportation process...
        if(other.GetComponentInChildren<Rigidbody2D>().velocity == Vector2.zero)
        {
            // ... disable the player's movement (so they don't move away from the teleporter during the teleportation animation)
            move.enabled = false;

            // Perform the player's enter teleport animation
            anim.SetEnter(true);
        }
    }

    protected override void ExitComplete(Collider2D other)
    {
        // Grab the player's teleport animation script
        TeleportAnimation anim = other.GetComponentInChildren<TeleportAnimation>();
        // Grab the player's movement script
        PlayerController move = other.GetComponentInChildren<PlayerController>();

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
