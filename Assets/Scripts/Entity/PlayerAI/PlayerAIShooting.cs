/*
    Programmer: Manhattan Calabro
*/

public class PlayerAIShooting : AIShooting
{
    protected override void InitializeShooting()
    {
        // Grab the enemy's movement script
        m_Script = GetComponent<PlayerAIController>();
    }
}
