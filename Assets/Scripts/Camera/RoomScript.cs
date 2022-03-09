// Made by Derek Chan and Sarah Harkins

// Helper functions for manipulating children of the Room object.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomScript : MonoBehaviour
{
    private GameObject[] players;
    private Tilemap walls;
    private Camera camera;

    public float camSize;
    public Camera reset;

    void FixedUpdate()
    {
        reset.gameObject.SetActive(false);
    }

    public void moveCamToRoom()
    {
        camera = this.gameObject.transform.GetChild(4).GetComponent<Camera>();
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
            Rect rect = camera.rect;
            rect.width = 1.0f; // full width
            rect.height = scaleHeight; // adjust height
            rect.x = 0; // unchanged x
            rect.y = (1.0f - scaleHeight / 2.0f); // adjust y to be the start of the boundary in camera
            
        }
        // Change width
        else
        {
            float scaleWidth = 1.0f / scaleHeight; // convert to width

            Rect rect = camera.rect;

            rect.width = scaleWidth; // adjust width
            rect.height = 1.0f; // full height
            rect.x = (1.0f - scaleWidth) / 2.0f; // adjust x to be the start of the boundary in camera
            rect.y = 0; // unchanged y

            camera.rect = rect;
        }

        // Work around for camera size being unable to change in the algorithm. The resolution will always be correct, the room designer should see what size 
        // properly fits the room and change it in the inspector.
        camera.orthographicSize = camSize;

        // Move the camera to the center of the room
        Vector3 center = walls.cellBounds.center;
        center[2] = -10;
        camera.transform.position = center;

        GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        foreach (GameObject cam in cameras)
        {
            cam.SetActive(false);
        }

        reset.gameObject.SetActive(true);

        camera.gameObject.SetActive(true);
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
