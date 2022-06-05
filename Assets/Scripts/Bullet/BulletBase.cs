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
        // How long this bullet has existed for
        protected float m_CurrentTime;
        // The deadline of when the bullet is automatically destroyed
        protected float m_Deadline;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the object's collider
        m_Collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_CurrentTime += Time.deltaTime;
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

    public void DestructTimer(float num)
    {
        m_Deadline = num;
        Destroy(gameObject, num);
    }

    public float GetCurrentTime() { return m_CurrentTime; }
    public float GetDeadline() { return m_Deadline; }
}
