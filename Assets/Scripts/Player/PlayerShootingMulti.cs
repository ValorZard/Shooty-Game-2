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
        // Reference to the player's multishot effect script
        private PlayerEffectMulti m_PlayerEffect;
        // Reference to the player's aiming script
        private PlayerAim m_PlayerAim;
        // The angle offset to shoot the bullets at
        private float m_Offset;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerScript = GetComponent<PlayerShooting>();
        m_PlayerEffect = GetComponentInChildren<PlayerEffectMulti>();
        m_PlayerAim = GetComponentInChildren<PlayerAim>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player can shoot...
        if(m_PlayerScript.CheckShootStatus())
        {
            // ... shoot the bullet
            Fire();
        }
    }

    // Instantiate the additional bullets
    private void Fire()
    {
        // Calculates the velocity between the cursor and the player
        Vector2 velocity = m_PlayerAim.GetAimVector().normalized;

        // Find the current angle
        float angle = Mathf.Atan(velocity.y / velocity.x) * Mathf.Rad2Deg;

        // Fire the first bullet
        m_PlayerScript.Fire(angle + m_Offset);

        // Fire the second bullet
        m_PlayerScript.Fire(angle - m_Offset);
    }

    public void SetOffset(float num) { m_Offset = num; }
}