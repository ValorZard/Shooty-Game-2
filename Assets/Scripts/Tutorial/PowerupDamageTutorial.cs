/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script is made exclusively for the damage powerup section
    of the powerup tutorial.
    When the target is dead, the damage powerup spawns.
    When the damage powerup is picked up, the obstruction is disabled.
*/

public class PowerupDamageTutorial : MonoBehaviour
{
    // Private variables
        // Reference to the target
        [SerializeField] private GameObject m_Target;
        // Reference to the obstruction
        [SerializeField] private GameObject m_Obstruction;
        // The powerup spawner
        private PowerupSpawner m_PowerupSpawner;
        // Reference to the spawned powerup
        private GameObject m_Powerup;
        // Has the powerup been spawned yet?
        private bool m_HasSpawned;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the powerup spawner
        m_PowerupSpawner = GetComponent<PowerupSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the target is dead AND the powerup hasn't been spawned yet...
        if(!m_Target.activeSelf && !m_HasSpawned)
        {
            // ... spawn the powerup
            m_Powerup = m_PowerupSpawner.SpawnPowerup();
            m_HasSpawned = true;
        }
        
        // If the has been spawned AND the powerup no longer exists...
        if(m_HasSpawned && m_Powerup == null)
            // ... disable the obstruction
            m_Obstruction.SetActive(false);
    }
}
