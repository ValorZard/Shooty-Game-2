/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class PowerupMultishot : PowerupBase
{
    /*
        The value determines the offset the additional bullets will be shot at.
    */

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
    }

    // Gives the player a multishot for a limited time when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's multishot script
        PlayerEffectMulti multishot = targetRigidbody.GetComponentInChildren<PlayerEffectMulti>();

        // Enable the player's multishot script...
        // ... and assign the powerup's value and duration
        multishot.Activate(m_Value, m_MaxTime);
    }
}