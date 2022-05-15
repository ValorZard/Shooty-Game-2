/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDetect : MonoBehaviour
{
    // Private variables
        // List of controllers
        protected List<string> m_StringList;

    // Update is called once per frame
    void Update()
    {
        // Refresh the list
        RefreshControllerList();
    }

    // Refresh the controller list
    protected void RefreshControllerList()
    {
        // Reset the list
        m_StringList = new List<string>();

        // Go through all the controllers
        for(int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            // Grab the string at that index
            string str = Input.GetJoystickNames()[i];

            // Assign the controller name if it's not empty
            if(!str.Equals(""))
                m_StringList.Add(str);
        }

        /*
            Unfortunately, I have to use this roundabout way to track
            controllers, since Input returns empty controllers when
            there used to be a controller plugged in.
        */
    }
}
