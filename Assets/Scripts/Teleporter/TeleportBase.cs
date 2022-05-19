/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TeleportBase : MonoBehaviour
{
    // Private variables
        // Can the player use the teleporter?
        [SerializeField] protected bool m_Active = true;
        // The player tag to track
        protected string m_Tag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        StartAble();
    }

    // Run while the player is still inside the teleporter
    protected void OnTriggerStay2D(Collider2D other)
    {
        // If the player is touching the teleporter...
        if(IsPlayer(other))
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
                    MoveEnabled(other);
                }

                // If the enter animation is complete...
                if(anim.GetEnterFinished())
                {
                    // ... perform a unique action
                    EnterComplete(other);
                }
            }

            // Otherwise, the teleporter isn't active
            else
            {
                ExitComplete(other);
            }
        }
    }

    abstract protected void MoveEnabled(Collider2D other);

    abstract protected void EnterComplete(Collider2D other);

    abstract protected void ExitComplete(Collider2D other);

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
    protected void StartAble()
    {
        if(m_Active)
            Enable();
        else
            Disable();
    }

    // Is the "player" actually a player?
    protected bool IsPlayer(Collider2D other)
    {
        // Does it have the "Player" tag?
        if(other.CompareTag(m_Tag))
        {
            // If the "player" has a surface shield script...
            // ... OR a surface bullet script...
            // ... then it's not a player
            if(other.GetComponent<ShieldTag>()
                || other.GetComponent<BulletHit>())
                return false;
            
            return true;
        }

        return false;
    }

    public bool GetActive() { return m_Active; }
}
