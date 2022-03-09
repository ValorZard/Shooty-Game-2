// Written by Derek Chan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovingAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float damageTaken;
    private float timer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(Random.Range(-1.0f, 1.0f) * speed, Random.Range(-1.0f, 1.0f) * speed, 0.0f);
    }

    void FixedUpdate()
    {
        if(timer <= 0.0f)
        {
            rb.velocity = new Vector3(Random.Range(-1.0f, 1.0f) * speed, Random.Range(-1.0f, 1.0f) * speed, 0.0f);
            timer = 3.0f;
        }
        timer -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            BaseHealthScript health = other.gameObject.GetComponent<BaseHealthScript>();
            health.TakeDamage(damageTaken);
            Destroy(this.gameObject);
        }
    }
}
