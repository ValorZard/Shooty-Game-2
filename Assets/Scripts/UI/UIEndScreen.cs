/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEndScreen : MonoBehaviour
{
    // Private variables
        // Reference to the player and enemy lists
        private FindEntities m_Entities;

    // Start is called before the first frame update
    void Start()
    {
        m_Entities = GetComponentInParent<FindEntities>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the screen isn't showing
        if(!GetActive())
        {
            // If all players are inactive...
            if(AllObjectsInactive(m_Entities.GetPlayersManualRefresh()))
                // ... the players have lost
                ShowScreen("GAME OVER");
        }
    }

    // Check if the objects are active
    private bool AllObjectsInactive(List<GameObject> objects)
    {
        // If the list has objects...
        if(objects.Count != 0)
            // Go through the list
            for(int i = 0; i < objects.Count; i++)
                // If the object is active...
                if(objects[i].activeSelf)
                    // ... all objects are not inactive
                    return false;
        
        // Otherwise, all objects are inactive
        return true;
    }

    // Activates the screen
    private void ShowScreen(string str)
    {
        // Go through all the children of this object
        for(int i = 0; i < transform.childCount; i++)
            // Enable the child
            transform.GetChild(i).gameObject.SetActive(true);

        // Change the text
        GetComponentInChildren<TextMeshProUGUI>().text = str;
    }

    public bool GetActive() { return transform.GetChild(0).gameObject.activeSelf; }
}
