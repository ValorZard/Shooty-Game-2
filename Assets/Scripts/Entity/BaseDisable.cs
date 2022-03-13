/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

abstract public class BaseDisable : MonoBehaviour
{
    // Zeroes the rigidbody's velocity
    protected void DisableVelocity()
    {
        // Stops the entity's current movement
        GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
    }

    abstract public void DisableEntity();
}
