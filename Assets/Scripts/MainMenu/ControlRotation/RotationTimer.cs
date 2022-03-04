/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class RotationTimer : MonoBehaviour
{
    // Private variables
        // The time to wait
        [SerializeField] private float m_MaxTime;
        // The current time
        private float m_CurrentTime;
        // Has the time past yet?
        private bool m_Tick;
    
    // Start is called before the first frame update
    void Start()
    {
        // The time should start at 0
        m_CurrentTime = 0f;

        // The timer hasn't started yet
        m_Tick = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the time
        m_CurrentTime += Time.deltaTime;

        // If the current time is past the max...
        if(m_CurrentTime >= m_MaxTime)
        {
            // Reset the current time to 0
            m_CurrentTime = 0;
            m_Tick = true;
        }
        else
            m_Tick = false;
    }

    public bool GetTick() { return m_Tick; }
}
