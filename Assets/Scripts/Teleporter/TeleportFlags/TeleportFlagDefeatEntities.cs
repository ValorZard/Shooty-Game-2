/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFlagDefeatEntities : TeleportFlagBase
{
    // Private variables
        // The list of entities that must be defeated
        [SerializeField] private GameObject[] m_Entities;

    // Start is called before the first frame update
    protected override void FlagStart()
    {
        // If there are no entities, log an error
        if(m_Entities == null)
            Debug.Log("ERROR: No entities were assigned!");
    }

    // Are all entities defeated?
    public override bool FlagCondition()
    {
        // Go through the list
        foreach(GameObject entity in m_Entities)
        {
            // If the entity is active, return false
            if(entity.activeSelf)
                return false;
        }

        // Otherwise, all entities are defeated; return true
        return true;
    }

    // Activate the teleporter
    protected override void FlagActivation()
    {
        // Only run if the teleporter exists
        if(m_Teleporter != null)
            m_Teleporter.GetComponent<TeleportBase>().Enable();
    }

    // Alternately, disable the teleporter
    protected override void FlagAlternate()
    {
        // Only run if the teleporter exists
        if(m_Teleporter != null)
            m_Teleporter.GetComponent<TeleportBase>().Disable();
    }
}
