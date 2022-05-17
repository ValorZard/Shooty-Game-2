/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

abstract public class RotationListener : MonoBehaviour
{
    // Protected variables
        // Reference to the timer
        protected RotationTimer m_Timer;

    // Start is called before the first frame update
    void Start()
    {
        // Get the timer
        m_Timer = GetComponentInParent<RotationTimer>();

        // Grab anything else that might be needed
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        // If the timer has ticked...
        if(m_Timer.GetTick())
        {
            // ... perform some action
            OnTick();
        }
    }

    abstract protected void OnStart();
    abstract protected void OnTick();
}
