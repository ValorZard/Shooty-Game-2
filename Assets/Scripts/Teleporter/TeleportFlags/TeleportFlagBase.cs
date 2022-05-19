/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TeleportFlagBase : MonoBehaviour
{
    // Private variables
        // The teleporter to track
        [SerializeField] protected GameObject m_Teleporter;

    // Start is called before the first frame update
    void Start()
    {
        // If the teleporter isn't assigned, log an error
        if(m_Teleporter == null)
            Debug.Log("ERROR: No teleporter was assigned!");
        
        FlagStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(FlagCondition())
        {
            FlagActivation();

            // Disable script
            enabled = false;
        }
        else
            FlagAlternate();
    }

    // Is there anything else that has to be done at the start?
    abstract protected void FlagStart();

    // What must be true for the action to take place?
    abstract public bool FlagCondition();

    // What is the action?
    abstract protected void FlagActivation();

    // Should there be an alternate action?
    abstract protected void FlagAlternate();

    protected bool GetActive() { return m_Teleporter.GetComponent<TeleportBase>().GetActive(); }
}
