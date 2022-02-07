/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexElement : MonoBehaviour
{
    // Public variable
        // Reference to a prefab
        public GameObject m_Prefab;

    // Start is called before the first frame update
    void Start()
    {
        // Set the icon to the prefab's sprite
        GetComponentInChildren<Image>().sprite = m_Prefab.GetComponent<SpriteRenderer>().sprite;
    }
}
