/*
    Programmer: Manhattan Calabro
*/

public class PlayerAIDisable : BaseDisable
{
    // Disables the player AI
    public override void DisableEntity()
    {
        DisableVelocity();

        // Disable the AI's movement
        GetComponentInParent<PlayerAIController>().enabled = false;

        // Disable the shooting
        GetComponentInParent<PlayerAIShooting>().enabled = false;
    }
}
