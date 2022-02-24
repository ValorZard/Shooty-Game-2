/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class PowerupSpeed : PowerupBase
{
    /*
        The value determines how much the player's speed will increase.
    */

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
    }

    // Increases the player's speed for a limited time when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's speed multiplier script
        PlayerEffectSpeed multiplier = targetRigidbody.GetComponentInChildren<PlayerEffectSpeed>();

        // Enable the player's speed multiplier script...
        // ... and assign the powerup's value and duration
        multiplier.Activate(m_Value, m_MaxTime);
    }
}