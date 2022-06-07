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
        // The cooldown child
        private GameObject m_Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the icon child
        m_Icon = gameObject.transform.Find("PowerupBarIcon").gameObject;

        // Grab the background child
        m_Background = gameObject.transform.Find("PowerupBarBackground").gameObject;

        // Grab the cooldown child
        m_Cooldown = gameObject.transform.Find("PowerupBarCooldown").gameObject;

        // Make sure the powerup UI is off at the beginning of the game
        m_CurrentTime = 0f;
    }

    // Activates the powerup UI
    public void Activate()
    {
        m_Icon.SetActive(true);
        m_Background.SetActive(true);
        m_Cooldown.SetActive(true);
    }

    // Deactivates the powerup UI
    public void Deactivate()
    {
        m_Icon.SetActive(false);
        m_Background.SetActive(false);
        m_Cooldown.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If the current time is greater than or equal to the max time, disable the UI object
        if(m_CurrentTime >= m_MaxTime)
            Deactivate();
        
        // Otherwise, change the cooldown's scale depending on the ratio of the current and max time
        else
        {
            // Make sure the object is visible
            Activate();

            // The ratio of the current and max time
            float ratio = m_CurrentTime / m_MaxTime;

            // Grab the cooldown image
            Image cooldownImage = m_Cooldown.GetComponent<Image>();

            // Change the scale of the cooldown image
            cooldownImage.rectTransform.localScale = new Vector3(cooldownImage.rectTransform.localScale.x,
                                                                 ratio,
                                                                 cooldownImage.rectTransform.localScale.z);
        }
    }

    public void SetMaxTime(float num) { m_MaxTime = num; }
    public void SetCurrentTime(float num) { m_CurrentTime = num; }
}