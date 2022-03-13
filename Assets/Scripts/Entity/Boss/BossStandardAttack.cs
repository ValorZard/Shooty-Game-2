/*
    Programmers: Derek Chan, Manhattan Calabro
        Derek: Base code
        Manhattan: Refactoured for better encapsulation
*/

using UnityEngine;

public class BossStandardAttack : DamageBase
{
    // Private variables
        // Time before the attack activates
        [SerializeField] private float timeLeftActive = 3.0f;
        // Time before the attack destroys itself
        [SerializeField] private float timeLeftDestroy = 2.0f;
        // Reference to the attack's sprite renderer
        private SpriteRenderer m_Renderer;


    void Start()
    {
        // Grab the sprite renderer
        m_Renderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the attack isn't active yet...
        if (!GetComponent<Collider2D>().enabled)
        {
            // If the setup time is over, activate the collider
            if (timeLeftActive <= 0.0)
                this.gameObject.GetComponent<Collider2D>().enabled = true;
            // Otherwise, decrement the time
            else
                timeLeftActive -= Time.deltaTime;
        }
        // Otherwise...
        else
        {
            // ... the attack is now active and can harm the player
            m_Renderer.color = Color.red;

            // Destroy the object when the attack is done
            Destroy(gameObject, timeLeftDestroy);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with the attack...
        if(other.gameObject.tag == "Player")
        {
            // ... the player is damaged
            DealDamage(other);
        }
    }

    public float GetTotalTime() { return timeLeftActive + timeLeftDestroy; }
}
