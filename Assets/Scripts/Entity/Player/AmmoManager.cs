/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    // Private variables
        // The max amount of ammo the player can have
        [SerializeField] private int m_MaxAmmo;
        // The current amount of ammo
        [SerializeField] private int m_CurrentAmmo;
        // The amount of time the player needs to reload
        [SerializeField] private float m_MaxTime;
        // The current amount of time before the player finishes reloading
        [SerializeField] private float m_CurrentTime;

    // Start is called before the first frame update
    void Start()
    {
        // The player has max ammo at the beginning of the game
        m_CurrentAmmo = m_MaxAmmo;

        // The time counts up to the max time
        m_CurrentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has no ammo...
        if(m_CurrentAmmo <= 0)
        {
            // ... increment the time
            m_CurrentTime += Time.deltaTime;

            // If the current time is above the max time...
            if(m_CurrentTime >= m_MaxTime)
            {
                // ... set it to the max time (prevents a large number from generating)
                m_CurrentTime = m_MaxTime;

                // Refill the ammo
                m_CurrentAmmo = m_MaxAmmo;
            }
        }

        // Otherwise...
        else
            // ... set the current time to zero
            m_CurrentTime = 0f;
    }

    // Removes a bullet from the canister
    public void DecrementAmmo() { m_CurrentAmmo--; }

    public int GetMaxAmmo() { return m_MaxAmmo; }
    public int GetCurrentAmmo() { return m_CurrentAmmo; }
}
