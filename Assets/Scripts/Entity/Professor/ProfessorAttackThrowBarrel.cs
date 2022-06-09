/*
    Programmer: Manhattan Calabro

    This script contains the professor's attack to throw a barrel.
*/

using UnityEngine;

public class ProfessorAttackThrowBarrel : ProfessorAttackBase
{
    // Private variables
        // Reference to the barrel prefab
        [SerializeField] private GameObject m_Barrel;
    
    // Start is called before the first frame update
    void Start()
    {
        m_TimeLeftActive = 0;
        m_TimeBeforeDestroy = 2;
    }

    // Throws a barrel toward the given player
    public void ThrowBarrel(GameObject player)
    {
        // Instantiate the barrel
        Rigidbody2D barrel = Instantiate(m_Barrel, transform.position, LookAt2D(player)).GetComponent<Rigidbody2D>();

        // Set the bullet's velocity
        float horizontal = player.transform.position.x - transform.position.x;
        float vertical = player.transform.position.y - transform.position.y;
        barrel.velocity = new Vector2(horizontal, vertical).normalized * 20;

        // Destroy the barrel after some time
        Destroy(barrel.gameObject, m_TimeBeforeDestroy);
    }
}
