/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightStickAim : MonoBehaviour
{
    // Private variables
        // Limit on how far away the stick can be from the center
        [SerializeField] private float m_Limit = 1;

    // Update is called once per frame
    void Update()
    {
        // Input from a normal controller
        Vector2 normal = new Vector2(Input.GetAxisRaw("AimHorizontal2"),
                                     Input.GetAxisRaw("AimVertical2"));
        normal *= m_Limit;

        // Input from an XBOX controller
        Vector2 xbox = new Vector2(Input.GetAxisRaw("AimHorizontal2XBOX"),
                                   Input.GetAxisRaw("AimVertical2XBOX"));
        xbox *= m_Limit;

        // If there is input from the normal controller, read the normal axes
        if(normal != Vector2.zero)
            transform.position = transform.parent.GetChild(0).position
                                    + new Vector3(normal.x, normal.y, 0);
        
        // Otherwise, read the XBOX axes
        else
            transform.position = transform.parent.GetChild(0).position
                                    + new Vector3(xbox.x, xbox.y, 0);
    }
}
