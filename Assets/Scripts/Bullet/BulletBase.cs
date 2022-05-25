/*
    Programmers: Manhattan Calabro, Pedro Longo
        Manhattan: Created base class
        Pedro: Added ignoring the AI player's view
*/

using UnityEngine;

public class BulletBase : DamageBase
{
    // Protected variables
        // Reference to the collider
        protected CircleCollider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the object's collider
        m_Collider = GetComponent<CircleCollider2D>();
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
        // If the collider belongs to Player AI detection, return true
        if (other.CompareTag("ViewAI"))
            return true;
        // If the collider is a background object, return true
        if(other.CompareTag("Background"))
            return true;
        // If the collider is a corridor object, return true
        if(other.CompareTag("Corridor"))
            return true;

        return false;
    }

    public void DestructTimer(float num) { Destroy(gameObject, num); }
}
