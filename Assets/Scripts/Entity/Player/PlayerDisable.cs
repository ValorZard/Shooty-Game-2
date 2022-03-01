/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class PlayerDisable : MonoBehaviour
{
    // Disables the player
    public void DisablePlayer()
    {
        // Disable the player's movement
        GetComponentInParent<PlayerController>().enabled = false;

        // Stops the player's current movement
        GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;

        // Disable the shooting script
        transform.parent.GetComponentInChildren<PlayerShooting>().enabled = false;

        // Disable the multishooting script
        transform.parent.GetComponentInChildren<PlayerShootingMulti>().enabled = false;

        // Disable the sprite controller
        transform.parent.GetComponentInChildren<PlayerSpriteController>().enabled = false;

        // Disable the aim child
        transform.parent.Find("AimReticle").gameObject.SetActive(false);

        // Disable the joystick manager
        transform.parent.GetComponentInChildren<JoystickManager>().enabled = false;

        /*
            I could save all of these as variables to make it look neater...
            ... but then it would be taking up unnecessary memory.
        */
    }
}
