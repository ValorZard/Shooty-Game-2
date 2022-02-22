using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomScript : MonoBehaviour
{
    private GameObject[] players;
    private Tilemap corridors;
    private Tilemap walls;
    private Tilemap floor;

    public Camera camera;
    public float camSize;

    // Start is called before the first frame update
    void Start()
    {
        corridors = this.gameObject.transform.GetChild(1).GetComponent<Tilemap>();
        walls = this.gameObject.transform.GetChild(0).GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void moveCamToRoom(Tilemap walls)
    {
        float screenRatio = (float) Screen.width / (float) Screen.height;
        float targetRatio = (float) walls.size[0] / (float) walls.size[1];
        float scaleHeight = (float) screenRatio / (float) targetRatio;

        Debug.Log(screenRatio);
        Debug.Log(targetRatio);
        Debug.Log(scaleHeight);

        if(scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight / 2.0f);
            
        }
        else
        {
            float scalewidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

        camera.orthographicSize = camSize;

        Vector3 center = walls.cellBounds.center;
        center[2] = -10;
        camera.transform.position = center;
    }
}
