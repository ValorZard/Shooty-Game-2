/*
    Programmer: Srayan Jana
*/

using UnityEngine;

public class TutorialTextScript : MonoBehaviour
{
    // Private variables
        // Reference to the camera of the second room
        [SerializeField] private GameObject m_Camera;

    // Update is called once per frame
    void Update()
    {
        // If the camera of the second room is active...
        if(m_Camera.activeSelf)
            // ... destroy the object this script is attached to
            Destroy(gameObject);
    }
}
