/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class PowerupShield : PowerupBase
{
    /*
        The value determines the amount of shield the player will gain.
        There should be no duration for this powerup.
    */

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<PolygonCollider2D>();
    }

    // Gives the player a shield when they touch it
    protected override void PlayerTrigger(Rigidbody2D targetRigidbody)
    {
        // Grab the player's shield child
        GameObject shield = targetRigidbody.transform.Find("Shield").gameObject;

        // Activate the shield
        shield.SetActive(true);

        // Get the shield's health script
        BaseHealthScript health = shield.GetComponent<BaseHealthScript>();

        // Heal the shield to max (in case the shield was previously depleted)
        health.Heal(health.GetCurrentHealth());
    }
}