/*
    Programmers: Pedro Longo, Srayan Jana, Manhattan Calabro
        Pedro: Base code,
            added pursuit and evade actions
        Srayan: Refactoured code
        Manhattan: Added check for whether target exists (that way, there won't be several console exceptions),
            refactoured for better encapsulation
*/

using UnityEngine;

abstract public class AIController : MonoBehaviour
{
    // Public variables
        // The target to attack
        public Transform target;

    // Protected variables
        // The movement speed
        [SerializeField] protected float m_MoveSpeed = 2.0f;
        // Does it see an enemy?
        protected bool m_DetectionArea;
        [SerializeField] protected float m_ShootingRange = 4.0f;
        // Reference to the health script
        protected BaseHealthScript m_Health;
        // Reference to the shooting script
        protected AIShooting m_Shooting;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the health script
        m_Health = GetComponentInChildren<BaseHealthScript>();

        // Do anything else that needs doing
        OnStart();
    }

    abstract protected void OnStart();
    abstract protected void Pursue();
    abstract protected void Evade();

    public bool GetDetection() { return m_DetectionArea; }
    public void SetDetection(bool b) { m_DetectionArea = b; }
}
