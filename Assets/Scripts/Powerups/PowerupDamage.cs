/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class PowerupDamage : PowerupBase
{
    /*
        The value determines how much the player's attack will increase.
    */

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<PolygonCollider2D>();
    }

    // Increases the player's attack power for a limited time when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's attack multiplier script
        PlayerEffectDamage multiplier = targetRigidbody.GetComponentInChildren<PlayerEffectDamage>();

        // Enable the player's attack multiplier script...
        // ... and assign the powerup's value and duration
        multiplier.Activate(m_Value, m_MaxTime);
    }
}