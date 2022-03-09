// Written by Derek Chan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStandardAttack : MonoBehaviour
{
    public float timeLeftActive = 3.0f;
    public float timeLeftDestroy = 2.0f;
    public float totalTime = 5.0f;
    public float damageTaken = 25.0f;

    private bool active = false;
    private SpriteRenderer renderer;


    void Start()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active == false)
        {
            if (timeLeftActive <= 0.0)
            {
                this.gameObject.GetComponent<Collider2D>().enabled = true;
                active = true;
            }
            else
            {
                timeLeftActive -= Time.deltaTime;
            }
        }
        else
        {
            renderer.color = Color.red;
            if (timeLeftDestroy <= 0.0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                timeLeftDestroy -= Time.deltaTime;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            BaseHealthScript health = other.gameObject.GetComponent<BaseHealthScript>();
            health.TakeDamage(damageTaken);
        }
    }
}
