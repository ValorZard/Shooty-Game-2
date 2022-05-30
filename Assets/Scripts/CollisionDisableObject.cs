/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    When colliding with the trigger; this script disables the given
    object(s).
*/

public class CollisionDisableObject : MonoBehaviour
{
    // Private variables
        // The given obejct to disable
        [SerializeField] private GameObject m_Object;
        // The player tag
        private string m_Tag = "Player";
    
    // Update is called once per frame
    void Update()
    {
        // The number of players left
        int num = FindObjectOfType<FindEntities>().GetPlayersManualRefresh().Count;

        // If there is only one player left, disable the object(s)
        if(num == 1)
            Enable(false);
    }

    // Run when the player first touches the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player is touching the trigger, disable the object(s)
        if(IsPlayer(other))
            Enable(false);
    }

    // Run when the player first leaves the trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        // If the player leaves the trigger, enable the object(s)
        if(IsPlayer(other))
            Enable(true);
    }

    // Enables/disables the object(s) depending on the input
    private void Enable(bool b)
    {
        // Enable/disable the object
        m_Object.SetActive(b);

        // If the object has children, enable/disable them too
        for(int z = 0; z < m_Object.transform.childCount; z++)
            m_Object.transform.GetChild(z).gameObject.SetActive(b);
    }

    // Is the "player" actually a player?
    private bool IsPlayer(Collider2D other)
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
}
