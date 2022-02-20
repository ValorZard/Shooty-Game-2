/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    // Public variables
        // Reference to the second player
        public GameObject m_PlayerTwo;
    
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

    // Start is called before the first frame update
    void Start()
    {
        // Gets the controller before the game starts
        UpdateController();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks the first controller
        UpdateController();

        // Grab the second player's movement script
        PlayerController movementScript = m_PlayerTwo.GetComponent<PlayerController>();

        // Switch the movement script to the XBOX control scheme
        movementScript.m_HorizontalAxis = "Horizontal2" + m_InputAxis;
        movementScript.m_VerticalAxis = "Vertical2" + m_InputAxis;

        // Grab the second player's shooting script
        PlayerShooting shootScript = m_PlayerTwo.GetComponent<PlayerShooting>();

        // Switch the shooting script to the XBOX control scheme
        shootScript.m_FireButton = "Fire2" + m_InputAxis;

        // Grab the second player's aiming script
        PlayerAim aimScript = m_PlayerTwo.GetComponentInChildren<PlayerAim>();

        // Switch the aiming script to the XBOX control scheme
        aimScript.SetHorizontalAxis("AimHorizontal2" + m_InputAxis);
        aimScript.SetVerticalAxis("AimVertical2" + m_InputAxis);
    }
}
