/*
    Programmer: Manhattan Calabro

    This script is a base of the professor's attacks.
*/

using UnityEngine;

public class ProfessorAttackBase : MonoBehaviour
{
    // Protected variables
        // Time before the attack activates
        protected float m_TimeLeftActive = 0;
        // Time before the attack destroys itself
        protected float m_TimeBeforeDestroy = 0;

    // Returns a rotation pointed at the target
    protected Quaternion LookAt2D(GameObject target)
    {
        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    protected Quaternion LocalLookAt2D(GameObject target, Transform trans)
    {
        Vector2 dir = target.transform.position - trans.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.Euler(0, 0, 90);
    }

    public float GetTimeLeftActive() { return m_TimeLeftActive; }
    public float GetTimeBeforeDestroy() { return m_TimeBeforeDestroy; }
}
