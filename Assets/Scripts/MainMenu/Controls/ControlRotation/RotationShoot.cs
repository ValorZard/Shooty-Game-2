/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class RotationShoot : RotationListener
{
    // Private variables
        // Is the image currently active?
        private bool m_Active;

    protected override void OnStart()
    {
        // The image starts active
        m_Active = true;
    }

    protected override void OnTick()
    {
        // If the image is active, hide the image
        if(m_Active)
            m_Active = false;
        // Otherwise, show the image
        else
            m_Active = true;

        DisplayChildren();
    }

    private void DisplayChildren()
    {
        // Go through all the children
        for(int i = 0; i < transform.childCount; i++)
            // Show/hide the children
            transform.GetChild(i).gameObject.SetActive(m_Active);
    }
}
