/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPan : MonoBehaviour
{
    // Private variables
        // Max height to pan to
        private float m_MaxHeight;
        // How long to pan for
        [SerializeField] private float m_PanTime;
        // How long the object has been panning for
        private float m_CurrentTime;
        // The original y-position
        private float m_PosY;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the max height from the canvas scaler (half the height, and negative so it pans upward)
        m_MaxHeight = GetComponentInParent<CanvasScaler>().referenceResolution.y/-2;

        // Time starts at 0
        m_CurrentTime = 0;

        // Grab the y position
        m_PosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        // If the current time hasn't reached the max time...
        if(m_CurrentTime < m_PanTime)
        {
            // Ratio of the times
            float ratio = m_MaxHeight * m_CurrentTime / m_PanTime;

            // Pan the image along the y-axis
            RectTransform image = GetComponent<RectTransform>();
            image.localPosition = new Vector3(image.localPosition.x, m_PosY + ratio, image.localPosition.z);

            // Increment the pan time
            m_CurrentTime += Time.deltaTime;
            // Make sure the time doesn't pass the limit
            m_CurrentTime = Mathf.Min(m_CurrentTime, m_PanTime);
        }
    }

    public float GetMaxTime() { return m_PanTime; }
    public float GetCurrentTime() { return m_CurrentTime; }
}
