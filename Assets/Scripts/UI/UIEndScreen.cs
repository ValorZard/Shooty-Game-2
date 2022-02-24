/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndScreen : MonoBehaviour
{
    // Private variables
        // List of references to objects
        private GameObject[] m_Objects;
        // Is the screen active?
        private bool m_Active;
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the array
        m_Objects = new GameObject[0];

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

    public GameObject[] GetObjects() { return m_Objects; }
    public void SetObjects(GameObject[] obj) { m_Objects = obj; }
    public bool GetActive() { return m_Active; }
}
