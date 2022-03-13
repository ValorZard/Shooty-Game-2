/*
    Programmer: Manhattan Calabro
*/

public class PlayerDisable : BaseDisable
{
    // Disables the player
    public override void DisableEntity()
    {
        DisableVelocity();

        // Disable the player's movement
        GetComponentInParent<PlayerController>().enabled = false;

        // Disable the shooting child
        transform.parent.Find("ShootingManager").gameObject.SetActive(false);

        // Disable the sprite controller
        transform.parent.GetComponentInChildren<PlayerSpriteController>().enabled = false;

        // Disable the aim child
        transform.parent.Find("AimReticle").gameObject.SetActive(false);

        // Disable the joystick manager
        transform.parent.GetComponentInChildren<JoystickManager>().enabled = false;
    }
}
