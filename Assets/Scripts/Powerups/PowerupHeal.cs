/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class PowerupHeal : PowerupBase
{
    /*
        The value determines the amount of health the player will regain.
        There should be no duration for this powerup.
    */

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<CircleCollider2D>();
    }

    // Heals the player when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's health script
        BaseHealthScript playerHealth = targetRigidbody.GetComponent<BaseHealthScript>();

        // Heal the player
        playerHealth.Heal(m_Value);
    }
}