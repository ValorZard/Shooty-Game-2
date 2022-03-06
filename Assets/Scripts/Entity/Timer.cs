/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Private variables
        // Reference to the timer text
        private TextMeshProUGUI m_TMP;
        // The starting time (should be over 0)
        private float m_Time;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the text
        m_TMP = GetComponent<TextMeshProUGUI>();

        // The time must be started via outside sources
        m_Time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the timer
        UpdateTimer();
        
        // Display the current time
        DisplayTimer();
    }

    // Updates the time values, not the display
    private void UpdateTimer()
    {
        // Decrement the time
        m_Time -= Time.deltaTime;

        // If the current time is below 0...
        if(m_Time < 0)
            // ... set the time to 0 (prevents UI error with displaying negative time)
            m_Time = 0;
    }

    // Updates the display
    private void DisplayTimer()
    {
        // If the time is above 0, display the current time
        if(m_Time > 0)
            m_TMP.text = Mathf.CeilToInt(m_Time).ToString();
        // Otherwise, hide the timer
        else
            m_TMP.text = "";
    }

    public float GetTime() {  return m_Time; }
    public void SetTime(float num) { m_Time = num; }
}
