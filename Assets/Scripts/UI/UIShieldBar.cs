/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShieldBar : UIHealthBar
{
    // Start is called before the first frame update
    void Start()
    {
        // Fetch the shield bar meter (hopefully overrides the other start)
        m_HealthBarMeter = gameObject.transform.Find("ShieldBarMeter");
    }
}