/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    // Private variables
        // The name of the first controller plugged in
        [SerializeField] private string m_ControllerName = "";
        // The input axis type that should be used
        [SerializeField] private string m_InputAxis = "";

    // Grabs the name of the first controller
    private void FindFirstController()
    {
        // If there's a controller plugged in...
        if(Input.GetJoystickNames().Length > 0)
        {
            // Grab the first name
            m_ControllerName = Input.GetJoystickNames()[0];
        }
    }

    // Checks if the first controller is an XBOX controller
    private void UpdateController()
    {
        // Find the first controller
        FindFirstController();

        // If the first controller is an XBOX controller...
        if(m_ControllerName.ToUpper().Contains("XBOX"))
        {
            // ... the controller is an XBOX controller
            m_InputAxis = "XBOX";
        }
        
        // Otherwise, return nothing
        else
            m_InputAxis = "";
    }

    // Update is called once per frame
    void Update()
    {
        // If the player isn't player two...
        if(GetComponentInParent<PlayerController>().GetPlayerNumber() != 2)
        {
            // ... disable this script
            enabled = false;

            // End the method early
            return;
        }

        // Checks the first controller
        UpdateController();

        // Grab the second player's movement script
        PlayerController movementScript = GetComponentInParent<PlayerController>();

        // Switch the movement script to the XBOX control scheme
        movementScript.SetHorizontalAxis("Horizontal2" + m_InputAxis);
        movementScript.SetVerticalAxis("Vertical2" + m_InputAxis);

        // Grab the second player's shooting script
        PlayerShooting shootScript = transform.parent.GetComponentInChildren<PlayerShooting>();

        // Switch the shooting script to the XBOX control scheme
        shootScript.SetFireButton("Fire2" + m_InputAxis);

        // Grab the second player's aiming script
        PlayerAim aimScript = transform.parent.GetComponentInChildren<PlayerAim>();

        // Switch the aiming script to the XBOX control scheme
        aimScript.SetHorizontalAxis("AimHorizontal2" + m_InputAxis);
        aimScript.SetVerticalAxis("AimVertical2" + m_InputAxis);
    }
}
