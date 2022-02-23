/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    // Protected variables
        // How long the object should be active for
        [SerializeField] protected float m_MaxTime = 1f;
        // The amount of damage done if hit
        [SerializeField] protected float m_Damage = 10f;
        // The tag of friends to NOT hurt
        protected string m_Friend = "";
        // The tag of enemies to hurt
        protected string m_Enemy = "";
        // Reference to the collider
        protected CircleCollider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the object's collider
        m_Collider = GetComponent<CircleCollider2D>();

        // Let the object exist for a limited time
        Destroy(gameObject, m_MaxTime);
    }

    // Checks if the given collider has an ignorable tag
    protected bool CheckTag(Collider2D other)
    {
        // If the collider belongs to a bullet, return true
        if(other.CompareTag("Bullet"))
            return true;
        // If the collider belongs to a powerup, return true
        if(other.CompareTag("Powerup"))
            return true;
        // If the collider belongs to the shooter, return true
        if(other.CompareTag(m_Friend))
            return true;
        // If the collider belongs to enemy view detection, return true
        if(other.CompareTag("EnemyView"))
            return true;

        return false;
    }

    // Deals damage to a target
    protected void DealDamage(Collider2D target)
    {
        // Grab the target's rigidbody
        Rigidbody2D targetRigidbody = target.GetComponent<Rigidbody2D>();

        // Grab the target's health script
        HealthScript health = targetRigidbody.GetComponent<HealthScript>();

        // Deal damage to the target
        health.TakeDamage(m_Damage);
    }

    public void SetDamage(float num) { m_Damage = num; }
    public void SetFriend(string str) { m_Friend = str; }
    public void SetEnemy(string str) { m_Enemy = str; }
}
