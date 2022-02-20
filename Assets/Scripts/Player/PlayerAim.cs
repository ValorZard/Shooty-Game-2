/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Public variables
        // How far away the reticle should be from the player
        public float m_Radius = 1;

    // Private variables
        // The player's aim vector
        private Vector2 m_Aim;
        // The horizontal input axis to read from
        private string m_HorizontalAxis;
        // The vertical input axis to read from
        private string m_VerticalAxis;
        // The player's number
        private int m_PlayerNumber;

    // Start is called before the first frame update
    void Start()
    {
        m_Aim = Vector2.zero;

        // Get the player's controller script
        PlayerController controllerScript = GetComponentInParent<PlayerController>();

        // Get the player number from the controller script
        m_PlayerNumber = controllerScript.playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        m_Aim = UpdatePlayerAim();
    }

    // Calculate the player's aim vector
    private Vector2 UpdatePlayerAim()
    {
        // If it's the first player, calculate for the first player
        if(m_PlayerNumber == 1)
            return UpdatePlayerAimOne();
        
        // Otherwise, calculate for the second player
        return UpdatePlayerAimTwo();
    }

    // Calculate the first player's aim vector
    private Vector2 UpdatePlayerAimOne()
    {
        // Get the mouse's position relative to the screen
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get the player's position
        Vector2 pos = transform.parent.position;

        // Calculate the vector
        float horizontal = mousePos.x - pos.x;
        float vertical = mousePos.y - pos.y;

        // Normalized version of the vector
        Vector2 norm = new Vector2(horizontal, vertical).normalized * m_Radius;

        float minX = 0;
        float minY = 0;

        // If the axis is non-negative, check for the smallest
        if(horizontal >= 0)
            minX = Mathf.Min(horizontal, norm.x);
        else
            minX = Mathf.Max(horizontal, norm.x);
        if(vertical >= 0)
            minY = Mathf.Min(vertical, norm.y);
        else
            minY = Mathf.Max(vertical, norm.y);

        // Minimum vector
        return new Vector2(minX, minY);
    }

    // Calculate the second player's aim vector
    private Vector2 UpdatePlayerAimTwo()
    {
        // Get the inputs from the controller
        float horizontalVelocity = Input.GetAxisRaw(m_HorizontalAxis);
        float verticalVelocity = Input.GetAxisRaw(m_VerticalAxis);
        return new Vector2(horizontalVelocity, verticalVelocity) * m_Radius;
    }

    // Gets the aim vector
    public Vector2 GetAimVector()
    {
        return m_Aim;
    }

    // Sets the horizontal input axis
    public void SetHorizontalAxis(string str)
    {
        m_HorizontalAxis = str;
    }

    // Sets the vertical input axis
    public void SetVerticalAxis(string str)
    {
        m_VerticalAxis = str;
    }
}
