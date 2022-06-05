/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class EnemyShooting : AIShooting
{
    protected override void InitializeShooting()
    {
        // Grab the enemy's movement script
        m_Script = GetComponent<EnemyController>();
    }

    // Creates the bullet
    protected new Rigidbody2D CreateBullet()
    {
        // Create an instance of the bullet and store a reference to its rigidbody
        Rigidbody2D bulletInstance = Instantiate(m_Bullet, transform.position, transform.rotation);

        // Change the colour to differentiate from player bullets
        bulletInstance.GetComponent<SpriteRenderer>().color = Color.yellow;

        // Grab the bullet script
        BulletBase bulletScript = bulletInstance.GetComponent<BulletHit>();

        // If the bullet script doesn't exist...
        if(bulletScript == null)
            //... it's actually an explosion
            bulletScript = bulletInstance.GetComponent<BulletExplosion>();

        // Destroy the bullet after a certain amount of time
        bulletScript.DestructTimer(m_ActiveTime);

        // Set the attack power of the bullet (this is here in case the player gets an attack powerup; the bullet spawns with the new attack)
        bulletScript.SetDamage(m_Damage);

        // Set the friendly and enemy tags
        bulletScript.SetFriend(m_Friend);
        bulletScript.SetEnemy(m_Enemy);

        return bulletInstance;
    }
}
