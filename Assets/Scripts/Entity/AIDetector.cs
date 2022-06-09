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
        // Is there an enemy inside the detector?
        protected bool m_EnemyInVicinity = false;

    protected void OnTriggerStay2D(Collider2D other)
    {
        // While an enemy stays within sight...
        if(other.CompareTag(m_Shooting.GetEnemy()))
        {
            // ... target it
            ReassignTarget(other);

            m_EnemyInVicinity = true;
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

            m_EnemyInVicinity = false;
        }
    }

    // Reassign the target
    public void ReassignTarget(Collider2D other)
    {
        m_Movement.SetDetection(true);
        m_Movement.target = other.transform;
    }

    public void ReassignTarget(Transform trans)
    {
        m_Movement.SetDetection(true);
        m_Movement.target = trans;
    }

    abstract protected void ResetTarget();
}
