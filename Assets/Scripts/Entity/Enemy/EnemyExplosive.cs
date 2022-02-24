/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyExplosive : MonoBehaviour
{
    // Private variables
        // How long will the timer last?
        [SerializeField] private float m_MaxTime;
        // Damage the explosion will do
        [SerializeField] private float m_Damage;
        // Reference to explosion prefab
        [SerializeField] private GameObject m_Explosion;
        // Reference to the timer's text
        [SerializeField] private GameObject m_Timer;
        // The current time before the timer goes off
        [SerializeField] private float m_CurrentTime;
        // Reference to the movement script
        private EnemyController m_MovementScript;
        // The tag of friends to NOT hurt
        private string m_Friend;
        // The tag of enemies to hurt
        private string m_Enemy;

    // Start is called before the first frame update
    void Start()
    {
        // Max out the timer
        m_CurrentTime = m_MaxTime;

        // Grab the movement script
        m_MovementScript = GetComponentInParent<EnemyController>();

        // Grab the friend tag
        m_Friend = transform.parent.tag;
    }

    // Check if the player has entered the enemy's hitbox
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only run if the tag has been initialized
        if(m_Enemy != null && m_Enemy != "")
        {
            // If the collider belongs to the player...
            if(other.CompareTag(m_Enemy))
            {
                // ... stop moving
                m_MovementScript.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the player exists
        if(m_MovementScript.target != null)
            // Grab the enemy tag
            m_Enemy = m_MovementScript.target.tag;

        // Only run while the enemy isn't moving (the timer has begun)
        if(!m_MovementScript.enabled)
        {
            // If the timer is at 0...
            if(m_CurrentTime == 0)
                // ... explode
                Explode();
            
            // Otherwise...
            else
            {
                // ... update the timer
                m_CurrentTime -= Time.deltaTime;

                // If the current time is below 0...
                if(m_CurrentTime < 0)
                    // ... set the time to 0 (prevents UI error with displaying negative time)
                    m_CurrentTime = 0;
            }

            // Grab the timer's text
            TextMeshProUGUI timerText = m_Timer.GetComponent<TextMeshProUGUI>();

            if(timerText == null)
                Debug.Log("Timer does not have TextMeshPro.");

            // Display the current time
            timerText.text = Mathf.CeilToInt(m_CurrentTime).ToString();
        }
    }

    // The enemy explodes
    private void Explode()
    {
        // Spawn an explosion
        GameObject explosion = Instantiate(m_Explosion, transform.position, transform.rotation);

        // Grab the explosion's script
        BulletExplosion explosionScript = explosion.GetComponent<BulletExplosion>();

        // Set the explosion's damage
        explosionScript.SetDamage(m_Damage);

        // Set the explosion's friend tag
        explosionScript.SetFriend(m_Friend);

        // Set the explosion's enemy tag
        explosionScript.SetEnemy(m_Enemy);

        // Disable the enemy
        transform.parent.gameObject.SetActive(false);
    }
}
