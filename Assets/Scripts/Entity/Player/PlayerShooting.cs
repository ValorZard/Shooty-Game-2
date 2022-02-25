/*
    Programmers: Manhattan Calabro, Pedro Longo
        Manhattan: Worked on shooting,
            reworked aim calculation,
            refactoured for better encapsulation
        Pedro: Added player number differentiation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : BaseShooting
{
    // Private variables
        // Player number
        private int m_PlayerNumber = 1;
        // The input axis that is used for shooting bullets
        private string m_FireButton;
        // Reference to the player's aiming script
        private PlayerAim m_PlayerAim;

    protected override void InitializeShooting()
    {
        // Assign the input to shoot
        m_FireButton = "Fire" + m_PlayerNumber;

        // Grab the player's aim script
        m_PlayerAim = GetComponentInChildren<PlayerAim>();
    }

    // Checks whether or not the player can shoot
    public override bool CheckShootStatus()
    {
        // If the fire button is pressed,
        // AND the current delay is zero,
        // AND the player is aiming...
        if (Input.GetButton(m_FireButton)
            && m_CurrentDelay == 0f
            && m_PlayerAim.GetAimVector() != Vector2.zero)
        {
            if (Input.GetButton(m_FireButton))
            {
                Debug.Log("FIRE BUTTON PRESSED");
            }
            // ... the player can shoot
            return true;

        }
        return false;
    }

    // Instantiate the bullet
    protected override void Fire()
    {
        Debug.Log("PLAYER SHOOTING");
        // Assign variables to the bullet
        AssignBullet(m_PlayerAim.GetAimVector());
    }

    // Instantiate the bullet
    public void Fire(float angle)
    {
        // Assign variables to the bullet
        AssignBullet(CalculateVelocity(angle));
    }

    // Calculate the velocity of the bullet
    private Vector2 CalculateVelocity(float angle)
    {
        // Calculate the bullet's horizontal movement
        float horizontal = Mathf.Cos(angle * Mathf.Deg2Rad);

        // Calculate the bullet's vertical movement
        float vertical = Mathf.Sin(angle * Mathf.Deg2Rad);

        if(m_PlayerAim.GetAimVector().x < 0)
        {
            horizontal *= -1;
            vertical *= -1;
        }

        return new Vector2(horizontal, vertical);
    }

    public void SetPlayerNumber(int num) { m_PlayerNumber = num; }
    public void SetFireButton(string str) { m_FireButton = str; }
}