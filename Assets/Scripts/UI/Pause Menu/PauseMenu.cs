/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
    Pauses the game by disabling everything - excluding the pause menu -
    and enabling the pause menu's children.
    Resuming the game performs the reverse.
*/

public class PauseMenu : MonoBehaviour
{
    // Private variables
        // The list of objects to affect
        private List<GameObject> m_Objects;
        // Reference to the child bullet tracker
        private BulletTracker m_BulletTracker;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the lists
        m_Objects = new List<GameObject>();

        // Grab the child bullet tracker
        m_BulletTracker = GetComponentInChildren<BulletTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the pause button is pressed
        if(Input.GetButtonDown("Pause1"))
        {
            // Enable/disable the pause menu's children (except the bullet tracker)
            for(int z = 0; z < transform.childCount; z++)
                if(transform.GetChild(z).GetComponent<BulletTracker>() == null)
                    transform.GetChild(z).gameObject.SetActive(!transform.GetChild(z).gameObject.activeSelf);

            // If the list is empty, pause the game
            if(m_Objects.Count == 0)
                Pause();

            // Otherwise, if the list has elements, play the game
            else
                Play();
        }
    }

    // Disables the objects in the list
    private void Pause()
    {
        // Pause the tracker
        m_BulletTracker.SetIsPaused(true);

        // Go through all objects within the scene
        foreach(GameObject obj in FindObjectsOfType<GameObject>())
        {
            // If the object passes the ignore conditions...
            if(IgnoreConditions(obj))
            {
                // ... add it to the list
                m_Objects.Add(obj);

                // Disable the given object
                obj.SetActive(false);
            }

            // If the object is the camera rig, disable the camera controller
            else if(obj.GetComponent<CameraController>() != null)
                obj.GetComponent<CameraController>().enabled = false;
        }
    }

    // Enables the objects in the list and clears the list
    private void Play()
    {
        // Play the tracker
        m_BulletTracker.SetIsPaused(false);

        // Enable all the objects within the list
        foreach(GameObject obj in m_Objects)
            // Only run if the object still exists
            if(obj != null)
                obj.SetActive(true);
        
        // Empty the list
        m_Objects.Clear();

        // Enable the camera controller
        FindObjectOfType<CameraController>().enabled = true;
    }

    // Conditions to exclude for objects to pause
    private bool IgnoreConditions(GameObject obj)
    {
        // If the object is active...
        // ... AND if the object isn't the camera...
        // ... AND if the object isn't the camera rig...
        // ... AND if the object isn't the event system...
        // ... AND if the object isn't the pause menu nor its child...
        // ... AND if the object isn't the music...
        // ... return true
        return obj.activeInHierarchy
            && obj.GetComponent<Camera>() == null
            && obj.GetComponent<CameraController>() == null
            && obj.GetComponent<EventSystem>() == null
            && !obj.transform.IsChildOf(this.transform)
            && obj.GetComponent<AudioSource>() == null;
    }
}
