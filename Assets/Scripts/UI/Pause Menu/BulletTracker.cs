/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Keeps track of all bullets active per frame, except when the game is
    paused.
    When paused, this class creates clones of the bullets that
    were active that frame.
    These clones won't activate the destruction timer until
    the game plays again.
    They also won't set their velocities until the game plays again.
*/

public class BulletTracker : MonoBehaviour
{
    // Private variables
        // The bullet prefab
        [SerializeField] private GameObject m_BulletPrefab;
        // The list of bullet clones
        [SerializeField] private List<GameObject> m_Bullets;
        // The velocities the clones should have
        [SerializeField] private List<Vector3> m_Velocities;
        // The times left for the clones' destruction timers
        [SerializeField] private List<float> m_Times;
        // Is the game currently paused?
        [SerializeField] private bool m_IsPaused;
        // Was the game just previously paused?
        [SerializeField] private bool m_WasPaused;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the lists
        m_Bullets = new List<GameObject>();
        m_Velocities = new List<Vector3>();
        m_Times = new List<float>();

        // The game starts not paused
        m_IsPaused = false;
        m_WasPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the game isn't paused
        if(!m_IsPaused)
        {
            // Only run if the game wasn't previously paused
            if(!m_WasPaused)
            {
                // Destroy all the bullets within the previous list
                foreach(GameObject bullet in m_Bullets)
                    Destroy(bullet);

                // Clear the lists
                m_Bullets.Clear();
                m_Velocities.Clear();
                m_Times.Clear();

                // Go through all bullets
                GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
                foreach(GameObject bullet in bullets)
                {
                    // The clone bullet
                    GameObject clone = Instantiate(m_BulletPrefab, bullet.transform.position, bullet.transform.rotation);

                    // Grab the bullet scripts
                    BulletHit scriptClone = clone.GetComponent<BulletHit>();
                    BulletHit scriptBullet = bullet.GetComponent<BulletHit>();

                    // Set the damage
                    scriptClone.SetDamage(scriptBullet.GetDamage());
                    // Set the friend tag
                    scriptClone.SetFriend(scriptBullet.GetFriend());
                    // Set the enemy tag
                    scriptClone.SetEnemy(scriptBullet.GetEnemy());

                    // Attach the clone to this tracker
                    clone.transform.parent = transform;

                    // Disable the clone
                    clone.SetActive(false);

                    // Add the clone to the list
                    m_Bullets.Add(clone);

                    // Grab the velocity
                    m_Velocities.Add(bullet.GetComponent<Rigidbody2D>().velocity);

                    // Grab the destruction time
                    m_Times.Add(scriptBullet.GetDeadline() - scriptBullet.GetCurrentTime());
                }
            }

            // Otherwise, the game was previously paused
            else
            {
                // Go through the clone list
                for(int z = 0; z < m_Bullets.Count; z++)
                {
                    // Enable the clone
                    m_Bullets[z].SetActive(true);

                    // Assign the velocity to the bullet
                    m_Bullets[z].GetComponent<Rigidbody2D>().velocity = m_Velocities[z];

                    // Assign the destruction time to the bullet
                    Destroy(m_Bullets[z], m_Times[z]);
                }

                // Pre-emptively clear the lists (prevents early destruction)
                m_Bullets.Clear();
                m_Velocities.Clear();
                m_Times.Clear();

                // The game is no longer previously paused
                m_WasPaused = false;
            }
        }

        // Otherwise, the game is paused
        else
            m_WasPaused = true;
    }

    public void SetIsPaused(bool b) { m_IsPaused = b; }
}
