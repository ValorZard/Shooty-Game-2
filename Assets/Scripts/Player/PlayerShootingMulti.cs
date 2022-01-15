using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingMulti : MonoBehaviour
{
    // Public variables
        // The angle the additional bullets will be shot at
        public float m_Angle = 15f;
    
    // Private variables
        // Reference to the player's shooting script
        private PlayerShooting m_PlayerAttack;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerAttack = gameObject.GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the fire button is pressed, AND the current delay is zero...
        if(Input.GetButton(m_PlayerAttack.m_FireButton)
            && m_PlayerAttack.m_CurrentDelay == 0)
        {
            // ... shoot the bullet
            Fire();
        }

        // Don't take anything else from the regular player shooting script, since everything else is just delay handling
    }

    // Instantiate the additional bullets
    private void Fire()
    {
        // Get the mouse's position relative to the screen
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get the player's position
        Vector2 pos = transform.position;

        // Calculate the bullet's horizontal movement
        float horizontal = mousePos.x - pos.x;

        // Calculate the bullet's vertical movement
        float vertical = mousePos.y - pos.y;

        // Find the current angle
        float angle = Mathf.Atan(vertical / horizontal) * Mathf.Rad2Deg;



        // First new horizontal
        float firstHorizontal = Mathf.Cos((angle + m_Angle) * Mathf.Deg2Rad);

        // First new vertical
        float firstVertical = Mathf.Sin((angle + m_Angle) * Mathf.Deg2Rad);
        
        // Second new horizontal
        float secondHorizontal = Mathf.Cos((angle - m_Angle) * Mathf.Deg2Rad);

        // Second new vertical
        float secondVertical = Mathf.Sin((angle - m_Angle) * Mathf.Deg2Rad);

        // Please don't ask me why or this is required; it has to do with the unit circle, and I'm not diving down that rabbit hole again (I've spent two hours trying to figure this out)
        if(horizontal < 0)
        {
            firstHorizontal *= -1;
            firstVertical *= -1;
            secondHorizontal *= -1;
            secondVertical *= -1;
        }



        // First velocity to move in
        Vector2 firstVelocity = new Vector2(firstHorizontal, firstVertical);

        // Create the first bullet
        Rigidbody2D firstBulletInstance = Instantiate(m_PlayerAttack.m_Bullet, transform.position, transform.rotation) as Rigidbody2D;

        // Get the first bullet's script
        BulletHit firstBulletScript = firstBulletInstance.GetComponent<BulletHit>();

        // Set the attack power of the first bullet
        firstBulletScript.setDamage(m_PlayerAttack.m_Damage);

        // Fire the first bullet
        firstBulletInstance.velocity = firstVelocity.normalized * m_PlayerAttack.m_Speed;



        // second velocity to move in
        Vector2 secondVelocity = new Vector2(secondHorizontal, secondVertical);

        // Create the second bullet
        Rigidbody2D secondBulletInstance = Instantiate(m_PlayerAttack.m_Bullet, transform.position, transform.rotation) as Rigidbody2D;

        // Get the second bullet's script
        BulletHit secondBulletScript = secondBulletInstance.GetComponent<BulletHit>();

        // Set the attack power of the second bullet
        secondBulletScript.setDamage(m_PlayerAttack.m_Damage);

        // Fire the second bullet
        secondBulletInstance.velocity = secondVelocity.normalized * m_PlayerAttack.m_Speed;
    }
}
