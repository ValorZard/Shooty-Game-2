/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseShooting : MonoBehaviour
{
    // Protected variables
        // Prefab of the bullet
        [SerializeField] protected Rigidbody2D m_Bullet;
        // The force given to the bullet
        [SerializeField] protected float m_Speed;
        // The delay before another bullet can be shot
        [SerializeField] protected float m_Delay;
        // The power of the attack
        [SerializeField] protected float m_Damage;
        // The current delay between shooting bullets
        protected float m_CurrentDelay;
        // The tag of friends to NOT hurt
        protected string m_Friend; 
        // The tag of enemies to hurt
        protected string m_Enemy;
    
    void Start()
    {
        // The current delay is reset
        m_CurrentDelay = 0f;

        // Assign the friendly tag
        m_Friend = transform.tag;
        
        // Assign the enemy tag
        if(m_Friend == "Player")
            m_Enemy = "Enemy";
        else
            m_Enemy = "Player";

        // Complete any other specialized tasks
        InitializeShooting();
    }

    // Update is called once per frame
    void Update()
    {
        // If the object can shoot...
        if(CheckShootStatus())
        {
            // ... shoot the bullet
            Fire();

            // Delay the next shot
            m_CurrentDelay = m_Delay;
        }

        // Decrement the delay by the time
        m_CurrentDelay -= Time.deltaTime;

        // If current delay is less than zero...
        if(m_CurrentDelay < 0f)
            // ... set it to zero (prevents a ludicrous amount generating)
            m_CurrentDelay = 0f;
    }

    // Assign variables to a bullet
    protected void AssignBullet(Vector2 velocity)
    {
        // Create an instance of the bullet and store a reference to its rigidbody
        Rigidbody2D bulletInstance = Instantiate(m_Bullet, transform.position, transform.rotation) as Rigidbody2D;

        // Grab the bullet script
        BulletHit bulletScript = bulletInstance.GetComponent<BulletHit>();

        // Set the attack power of the bullet (this is here in case the player gets an attack powerup; the bullet spawns with the new attack)
        bulletScript.SetDamage(m_Damage);

        // Set the friendly tag
        bulletScript.SetFriend(m_Friend);

        // Set the enemy tag
        bulletScript.SetEnemy(m_Enemy);

        // Set the bullet's velocity
        // Note: Don't use Time.deltaTime; seems to break speed consistency between bullets
        bulletInstance.velocity = velocity.normalized * m_Speed;
    }

    abstract protected void InitializeShooting();
    // Checks whether or not the object can shoot
    abstract public bool CheckShootStatus();
    abstract protected void Fire();
    
    public float GetDamage() { return m_Damage; }
    public void SetDamage(float num) { m_Damage = num; }
    public string GetFriend() { return m_Friend; }
    public void SetFriend(string str) { m_Friend = str; }
    public string GetEnemy() { return m_Enemy; }
    public void SetEnemy(string str) { m_Enemy = str; }
}
