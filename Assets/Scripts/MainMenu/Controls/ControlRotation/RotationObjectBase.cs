/*
    Programmer: Manhattan Calabro
*/

using System.Collections.Generic;
using UnityEngine;

abstract public class RotationObjectBase<T> : RotationListener
{
    // Protected variables
        // List to rotate through
        [SerializeField] protected List<T> m_List;
        // The current index
        protected int index;

    protected override void OnStart()
    {
        // The index should be the first in the list
        index = 0;

        // Grab anything else that might be needed
        Fetch();
    }

    protected override void OnTick()
    {
        // Move to the next element
        BeforeIndex();
        index++;

        // If the index is greater than or equal to the list size...
        if(index >= m_List.Count)
            // ... reset the index to 0
            index = 0;
        
        // Perform any last actions
        AfterIndex();
    }

    abstract protected void Fetch();
    abstract protected void BeforeIndex();
    abstract protected void AfterIndex();
}
