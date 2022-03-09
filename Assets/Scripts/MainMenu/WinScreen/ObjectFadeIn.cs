/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectFadeIn : MonoBehaviour
{
    // Private variables
        // The time for a child to fade in
        [SerializeField] private float m_FadeTime;
        // The time to wait before fading in the next child
        [SerializeField] private float m_WaitTime;
        // The current fade time
        private float m_CurrentFadeTime;
        // The current wait time
        private float m_CurrentWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        // The current times start at 0
        m_CurrentFadeTime = m_CurrentWaitTime = 0;
        
        // Make sure all the text is hidden
        TextMeshProUGUI[] tmp = GetComponentsInChildren<TextMeshProUGUI>();
        foreach(TextMeshProUGUI t in tmp)
            t.alpha = 0;
        
        // Make sure all the images are hidden
        Image[] image = GetComponentsInChildren<Image>();
        foreach(Image i in image)
            i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the wait timer is at 0
        if(m_CurrentWaitTime == 0)
        {
            // Go through the list of children
            foreach(Transform child in transform)
            {
                // Get the child's text
                TextMeshProUGUI tmp = child.GetComponentInChildren<TextMeshProUGUI>();
                // Get the child's image
                Image image = child.GetComponentInChildren<Image>();

                // If the child isn't fully visible...
                if((tmp != null && tmp.alpha != 1)
                    || (image != null && image.color.a != 1))
                {
                    // The ratio between the current fade time and the final fade time
                    float ratio = m_CurrentFadeTime / m_FadeTime;

                    // ... make it more visible
                    if(tmp != null)
                        tmp.alpha = ratio;
                    if(image != null)
                        image.color = new Color(image.color.r, image.color.g, image.color.b, ratio);

                    // Increment the fade time
                    m_CurrentFadeTime += Time.deltaTime;
                    // Make sure fade time isn't above limit
                    m_CurrentFadeTime = Mathf.Min(m_CurrentFadeTime, m_FadeTime);

                    // If the child is now fully visible...
                    if((tmp != null && tmp.alpha == 1)
                        || (image != null && image.color.a == 1))
                    {
                        // ... start the wait timer
                        m_CurrentWaitTime = m_WaitTime;

                        // Reset the fade timer
                        m_CurrentFadeTime = 0;

                        // If this is the last child...
                        if(child == transform.GetChild(transform.childCount-1))
                            // ... disable this script
                            enabled = false;
                    }

                    // Exit out early, so it doesn't apply to the other children
                    return;
                }
            }
        }
        // Otherwise...
        else
        {
            // ... decrement the wait time
            m_CurrentWaitTime -= Time.deltaTime;
            // Make sure wait time is non-negative
            m_CurrentWaitTime = Mathf.Max(m_CurrentWaitTime, 0);
        }
    }
}
