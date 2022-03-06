/*
    Programmers: Srayan Jana, Pedro Longo, Manhattan Calabro
        Pedro: Base code
        Srayan: Refactored code to its own class
        Manhattan: Reformatted for readability,
            fixed enemy targeting error,
            refactoured for better encapsulation
*/

using UnityEngine;

abstract public class AIDetector : MonoBehaviour
{
    // Protected variables
        // Reference to the movement script
        protected AIController m_Movement;
        // Reference to the shoot script
        protected BaseShooting m_Shooting;

    protected void OnTriggerStay2D(Collider2D other)
    {
        // While an enemy stays within sight...
        if(other.CompareTag(m_Shooting.GetEnemy()))
        {
            // ... target it
            m_Movement.SetDetection(true);

            // Set new target
            m_Movement.target = other.transform;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        // If an enemy exits enemy sight...
        if(other.CompareTag(m_Shooting.GetEnemy()))
        {
            // ... stop pursuing
            m_Movement.SetDetection(false);

            // Reset target
            ResetTarget();
        }
    }

    abstract protected void ResetTarget();
}
