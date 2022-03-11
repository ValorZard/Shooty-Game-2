/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // Private variables
        // Prefab of the powerup to spawn
        [SerializeField] private GameObject m_Powerup;

    public void SpawnPowerup()
    {
        // Spawn the powerup
        Instantiate(m_Powerup, transform.position, transform.rotation);
    }
}
