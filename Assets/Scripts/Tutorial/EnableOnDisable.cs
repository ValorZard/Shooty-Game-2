/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script is made exclusively for the damage powerup section
    of the powerup tutorial.
    When the first target is disabled, enable the second target.
*/

public class EnableOnDisable : MonoBehaviour
{
    // Private variables
        // Reference to the first target
        [SerializeField] private GameObject m_FirstTarget;
        // Reference to the second target
        [SerializeField] private GameObject m_SecondTarget;

    // Update is called once per frame
    void Update()
    {
        // If the first target is disabled, enable the second target
        if(!m_FirstTarget.activeSelf)
            m_SecondTarget.SetActive(true);
    }
}
