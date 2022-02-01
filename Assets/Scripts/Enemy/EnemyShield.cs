/*
    Programmers: Pedro Longo, Manhattan Calabro
        Pedro: Coded shield activation
        Manhattan: Deleted unused line of code
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Add enemy shield
        GameObject shield = gameObject.transform.Find("Shield").gameObject;

        // Activate the shield
        shield.SetActive(true);
    }
}
