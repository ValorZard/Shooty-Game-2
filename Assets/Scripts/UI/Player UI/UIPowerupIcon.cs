/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPowerupIcon : MonoBehaviour
{
    // Private variables
        // How long the powerup will be active for
        private float m_MaxTime;
        // How long the powerup has been active for
        private float m_CurrentTime;
        // The icon child
        private GameObject m_Icon;
        // The background child
        private GameObject m_Background;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the icon child
        m_Icon = gameObject.transform.Find("PowerupBarIcon").gameObject;

        // Grab the background child
        m_Background = gameObject.transform.Find("PowerupBarBackground").gameObject;

        // Make sure the powerup UI is off at the beginning of the game
        m_CurrentTime = 0f;
    }

    // Activates the powerup UI
    public void Activate()
    {
        m_Icon.SetActive(true);
        m_Background.SetActive(true);
    }

    // Deactivates the powerup UI
    public void Deactivate()
    {
        m_Icon.SetActive(false);
        m_Background.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If the current time is greater than or equal to the max time...
        if(m_CurrentTime >= m_MaxTime)
        {
            // ... disable the UI object
            Deactivate();
        }
        
        // Otherwise, change the alpha depending on the ratio of the current and max time
        else
        {
            // Make sure the object is visible
            Activate();

            // The ratio of the current and max time
            float ratio = (m_MaxTime - m_CurrentTime) / m_MaxTime;

            // Grab the icon image
            Image iconImage = m_Icon.GetComponent<Image>();

            // Grab the background image
            Image backgroundImage = m_Background.GetComponent<Image>();

            // Change the alpha of the icon image
            iconImage.color = new Color(iconImage.color.r, iconImage.color.g, iconImage.color.b, ratio);

            // Change the alpha of the background image
            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, ratio);
        }
    }

    public void SetMaxTime(float num) { m_MaxTime = num; }
    public void SetCurrentTime(float num) { m_CurrentTime = num; }
}