/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Similar to the TeleportExit script; however, this teleporter is linked.
    Both teleporters need to be stepped on in order to go to the next scene.
*/

public class TeleportExitLink : TeleportBase
{
    // Private variables
        // The linked teleporter
        private GameObject m_Link;
        // Is the player ready to teleport?
        private bool m_Ready = false;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the other exit teleporter
        TeleportExitLink[] links = FindObjectsOfType<TeleportExitLink>();
        foreach(TeleportExitLink link in links)
            if(link != this)
                m_Link = link.gameObject;
        if(m_Link == null)
            m_Link = gameObject;
        
        StartAble();
    }

    // Update is called once per frame
    void Update()
    {
        // The number of players left
        int num = FindObjectOfType<FindEntities>().GetPlayersManualRefresh().Count;

        // If there is only one player left, become ready
        if(num == 1)
            m_Ready = true;
    }

    protected override void MoveEnabled(Collider2D other)
    {
        // Grab the player's teleport animation script
        TeleportAnimation anim = other.GetComponentInChildren<TeleportAnimation>();
        // Grab the player's movement script
        PlayerController move = other.GetComponentInChildren<PlayerController>();

        // If the player stops moving during the teleportation process...
        if(other.GetComponentInChildren<Rigidbody2D>().velocity == Vector2.zero)
        {
            // ... the player is ready to teleport
            m_Ready = true;
        }
        // Otherwise, the player is still moving
        else
            m_Ready = false;

        // If both players aren't moving...
        if(m_Ready && m_Link.GetComponent<TeleportExitLink>().GetReady())
        {
            // ... disable the player's movement (so they don't move away from the teleporter during the teleportation animation)
            move.enabled = false;

            // Perform the player's enter teleport animation
            anim.SetEnter(true);
        }
    }

    protected override void EnterComplete(Collider2D other)
    {
        // Move to the next scene
        GetComponent<StartScript>().StartGame();
    }

    protected override void ExitComplete(Collider2D other) {}

    public bool GetReady() { return m_Ready; }
}
