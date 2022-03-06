/*
    Programmer: Manhattan Calabro
*/

public class EnemyShooting : AIShooting
{
    protected override void InitializeShooting()
    {
        // Grab the enemy's movement script
        m_Script = GetComponent<EnemyController>();
    }
}
