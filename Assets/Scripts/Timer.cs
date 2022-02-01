/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Public variables
        // The current time
        public float m_CurrentTime;

    // Update is called once per frame
    void Update()
    {
        // Grab the TMP
        TextMeshPro textMeshPro = GetComponent<TextMeshPro>();
        
        // Display the current time
        textMeshPro.text = Mathf.CeilToInt(m_CurrentTime).ToString();
    }
}
