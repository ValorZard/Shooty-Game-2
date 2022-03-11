// Made by Derek Chan, Sarah Harkins, and Srayan Jana

// Srayan Jana: did some refactoring

// Helper functions for manipulating children of the Room object.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomScript : MonoBehaviour
{
    // Private variables
        private Tilemap walls;
        private Camera m_Camera;
        [SerializeField] private float camSize;
        [SerializeField] private Camera reset;
    // Public variables
    //public bool isRoomOne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        reset.gameObject.SetActive(false);
    }

    public void moveCamToRoom()
    {
        m_Camera = this.gameObject.transform.GetChild(4).GetComponent<Camera>();
        walls = this.gameObject.transform.GetChild(0).GetComponent<Tilemap>();

        // Current screen ratio
        float screenRatio = (float) Screen.width / (float) Screen.height;

        // The ratio we want our camera (size of wall)
        float targetRatio = (float) walls.size[0] / (float) walls.size[1];

        // Do we need to change the current resolution's width or height?
        float scaleHeight = (float) screenRatio / (float) targetRatio;

        // Change height
        if(scaleHeight < 1.0f)
        {
            Rect rect = m_Camera.rect;
            rect.width = 1.0f; // full width
            rect.height = scaleHeight; // adjust height
            rect.x = 0; // unchanged x
            rect.y = (1.0f - scaleHeight / 2.0f); // adjust y to be the start of the boundary in camera
            
        }
        // Change width
        else
        {
            float scaleWidth = 1.0f / scaleHeight; // convert to width

            Rect rect = m_Camera.rect;

            rect.width = scaleWidth; // adjust width
            rect.height = 1.0f; // full height
            rect.x = (1.0f - scaleWidth) / 2.0f; // adjust x to be the start of the boundary in camera
            rect.y = 0; // unchanged y

            m_Camera.rect = rect;
        }

        // Work around for camera size being unable to change in the algorithm. The resolution will always be correct, the room designer should see what size 
        // properly fits the room and change it in the inspector.
        m_Camera.orthographicSize = camSize;

        // Move the camera to the center of the room
        Vector3 center = walls.cellBounds.center;
        center[2] = -10;
        m_Camera.transform.position = center;

        GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        foreach (GameObject cam in cameras)
        {
            cam.SetActive(false);
        }

        reset.gameObject.SetActive(true);

        m_Camera.gameObject.SetActive(true);
    }

    public void disableDoor()
    {
        // Self-explanatory
        Tilemap door = this.gameObject.transform.GetChild(3).GetComponent<Tilemap>();
        door.gameObject.SetActive(false);
    }

    public void enableDoor()
    {
        // Self-explanatory
        Tilemap door = this.gameObject.transform.GetChild(3).GetComponent<Tilemap>();
        door.gameObject.SetActive(true);
        
    }
}
