/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndScreen : MonoBehaviour
{
    // Public variables
        // List of references to objects
        public GameObject[] m_Objects;
        // Is the screen active?
        public bool m_Active;
    
    // Start is called before the first frame update
    void Start()
    {
        // The screen is not active at the beginning of the game
        m_Active = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the list has objects, AND if the screen is not active
        if(m_Objects.Length != 0
            && !m_Active)
        {
            // Go through the list
            for(int i = 0; i < m_Objects.Length; i++)
            {
                // If an object is active...
                if(m_Objects[i].activeSelf)
                {
                    // End the method early
                    return;
                }
            }
            
            // Otherwise, all objects are inactive, activate the screen
            ShowScreen();
            m_Active = true;
        }
    }

    // Activates the screen
    private void ShowScreen()
    {
        // Go through all the children of this object
        for(int i = 0; i < transform.childCount; i++)
        {
            // Enable the child
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
