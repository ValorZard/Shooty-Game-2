/*
    Programmer: Pedro Longo
*/

public class PlayerDetector : AIDetector
{
    // Start is called before the first frame update
    void Start()
    {
        // Grab the scripts
        m_Movement = GetComponentInParent<EnemyController>();
        m_Shooting = GetComponentInParent<EnemyShooting>();
    }

    protected override void ResetTarget()
    {
        // There is no valid target
        m_Movement.target = null;
    }
}