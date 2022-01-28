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

    // Checks if the first controller is an XBOX controller
    private void UpdateController()
    {
        // If there's a controller plugged in...
        if(Input.GetJoystickNames().Length > 0)
        {
            // ... AND if the first controller is an XBOX controller...
            if(Input.GetJoystickNames()[0].ToUpper().Contains("XBOX"))
            {
                // .... the controller is an XBOX controller
                m_ControllerName = "XBOX";
            }
        }
        
        // Otherwise, return nothing
        else
            m_ControllerName = "";
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
        movementScript.m_HorizontalAxis = "Horizontal1" + m_ControllerName;
        movementScript.m_VerticalAxis = "Vertical1" + m_ControllerName;

        // Grab the second player's shooting script
        PlayerShooting shootScript = m_PlayerTwo.GetComponent<PlayerShooting>();

        // Switch the shooting script to the XBOX control scheme
        shootScript.m_FireButton = "Fire1" + m_ControllerName;
    }
}
