/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Private variables
        // How far away the reticle should be from the player
        [SerializeField] private float m_Radius = 1;
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
        m_PlayerNumber = controllerScript.GetPlayerNumber();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerAim();
    }

    // Calculate the player's aim vector
    private void UpdatePlayerAim()
    {
        // If it's the first player, calculate for the first player
        if(m_PlayerNumber == 1)
            UpdatePlayerAimOne();
        
        // Otherwise, calculate for the second player
        UpdatePlayerAimTwo();
    }

    // Calculate the first player's aim vector
    private void UpdatePlayerAimOne()
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
        m_Aim = new Vector2(minX, minY);
    }

    // Calculate the second player's aim vector
    private void UpdatePlayerAimTwo()
    {
        try
        {
            // Get the inputs from the controller
            float horizontalVelocity = Input.GetAxisRaw(m_HorizontalAxis);
            float verticalVelocity = Input.GetAxisRaw(m_VerticalAxis);
            m_Aim = new Vector2(horizontalVelocity, verticalVelocity) * m_Radius;
        } catch{};
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
