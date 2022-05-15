/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDetectSpriteRenderers : ControllerDetect
{
    // Update is called once per frame
    void Update()
    {
        // Refresh the list
        RefreshControllerList();

        // Check the sprite renderer list
        CheckRenderers();
    }

    // Enables/disables the children
    private void CheckRenderers()
    {
        // If a controller is detected, enable the children
        // Otherwise, disable the children
        for(int z = 0; z < transform.childCount; z++)
            transform.GetChild(z).gameObject.SetActive(m_StringList.Count > 0);
    }
}
