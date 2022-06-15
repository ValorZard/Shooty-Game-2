/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingMulti : MonoBehaviour
{
    // Private variables
        // Reference to the player's shooting script
        private PlayerShooting m_PlayerScript;
        // Reference to the player's aiming script
        private PlayerAim m_PlayerAim;
        // The angle offset to shoot the bullets at
        [SerializeField] private float m_Offset;
        // Has the player fired yet?
        [SerializeField] private bool m_HasFired = false;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerScript = GetComponent<PlayerShooting>();
        m_PlayerAim = GetComponentInChildren<PlayerAim>();
    }

    // OnEnable is called whenever the script is enabled
    void OnEnable()
    {
        m_HasFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player can shoot...
        if(m_PlayerScript.CheckShootStatusIgnoreDelay() && !m_HasFired)
        {
            // ... shoot the bullet
            Fire();
            m_HasFired = true;
        }
        else if(m_PlayerScript.CheckShootStatus())
        {
            Fire();
            m_HasFired = true;
        }
        else if(!m_PlayerScript.CheckShootStatusInput())
            m_HasFired = false;
    }

    // Instantiate the additional bullets
    private void Fire()
    {
        // Calculates the velocity between the cursor and the player
        Vector2 velocity = m_PlayerScript.CalculateVelocity();

        // Find the current angle
        float angle = Mathf.Atan(velocity.y / velocity.x) * Mathf.Rad2Deg;

        // Fire the normal bullet
        m_PlayerScript.Fire(angle);

        // Fire the first bullet
        m_PlayerScript.Fire(angle + m_Offset);

        // Fire the second bullet
        m_PlayerScript.Fire(angle - m_Offset);

        // Removes one from the ammo count
        m_PlayerScript.DecrementAmmo();
    }

    public void SetOffset(float num) { m_Offset = num; }
}