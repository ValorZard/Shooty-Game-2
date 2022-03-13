/*
    Programmers: Derek Chan, Manhattan Calabro
        Derek: Base code
        Manhattan: Refactoured for better encapsulation
*/

using UnityEngine;

public class BossMovingAttack : DamageBase
{
    // Private variables
        // Reference to the rigidbody
        private Rigidbody2D rb;
        // How fast the attack moves
        [SerializeField] private float speed;
        // How much time before the attack changes direction
        private float timer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the rigidbody
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        // Move in a random direction
        RandomizeVelocity();
    }

    void FixedUpdate()
    {
        // When the timer reaches 0...
        if(timer <= 0.0f)
        {
            // ... change the direction
            RandomizeVelocity();

            // Restart the timer
            timer = 3.0f;
        }

        // Decrement the timer
        timer -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // If the attack collides with a player...
        if(other.gameObject.tag == m_Friend)
        {
            // Hurt the player
            DealDamage(other.collider);

            // Destroy the attack; it has completed its purpose
            Destroy(this.gameObject);
        }
    }
    
    // Assigns a random velocity
    private void RandomizeVelocity()
    {
        rb.velocity = new Vector3(Random.Range(-1.0f, 1.0f) * speed, Random.Range(-1.0f, 1.0f) * speed, 0.0f).normalized;
    }
}
