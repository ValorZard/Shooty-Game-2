/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // Private variables
        // Prefab of the powerup to spawn
        [SerializeField] private GameObject m_Powerup;

    public GameObject SpawnPowerup()
    {
        // Spawn the powerup
        return Instantiate(m_Powerup, transform.position, transform.rotation);
    }
}
