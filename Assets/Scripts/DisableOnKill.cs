/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

/*
    This script is used to enable/disable a group of objects when
    some other group of objects is enabled/disabled.
*/

public class DisableOnKill : MonoBehaviour
{
    // Private variables
        // The group of objects that must be disabled first
        [SerializeField] private GameObject[] m_FirstGroup;
        // The group of objects to disable afterward
        [SerializeField] private GameObject[] m_SecondGroup;
        // Should the first group be enabled or disabled?
        [SerializeField] private bool m_FirstActive = false;
        // Should the second group be enabled or disabled?
        [SerializeField] private bool m_SecondActive = false;

    // Update is called once per frame
    void Update()
    {
        // If all the members of the first group are disabled...
        if(CheckFirstGroup())
        {
            // ... disable all the members of the second group
            foreach(GameObject obj in m_SecondGroup)
                obj.SetActive(m_SecondActive);
        }
    }

    // Checks if all the members of the first group have been disabled
    private bool CheckFirstGroup()
    {
        // If at least one of the members is enabled, return false
        foreach(GameObject obj in m_FirstGroup)
            if(obj.activeSelf != m_FirstActive)
                return false;

        return true;
    }
}
