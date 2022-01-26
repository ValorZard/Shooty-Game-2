/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // If there's a controller plugged in...
        if(Input.GetJoystickNames().Length > 0)
        {
            // ... output the name of the first controller
            Debug.Log(Input.GetJoystickNames()[0]);
        }
    }
}