/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    When the background reaches the top, it stops abruptly.
    A little before the background reaches the top, the screen will
    fade white, obscuring the background's abrupt stop.
*/
public class FlashFade : MonoBehaviour
{
    // Private variables
        // Reference to the background panning script
        private BackgroundPan m_Pan;
        // Time difference between background pan and flash fade-in
        [SerializeField] private float m_DifferenceTime;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the panning script
        m_Pan = GetComponentInParent<BackgroundPan>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the time difference of the panning
        float diff = m_Pan.GetMaxTime() - m_Pan.GetCurrentTime();

        // If the difference is less than or equal to the given difference...
        if(diff <= m_DifferenceTime)
        {
            // Set the alpha to the ratio of the differences
            float ratio = (m_DifferenceTime-diff) / m_DifferenceTime;
            // Make sure the ratio isn't above 1
            ratio = Mathf.Min(ratio, 1);

            Image image = GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, ratio);

            // If the ratio is maxed out, disable this script
            if(ratio == 1)
                enabled = false;
        }
    }
}
