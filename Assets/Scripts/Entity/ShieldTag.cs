/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTag : MonoBehaviour
{
    // Changes the tag of the shield to its parent's tag (assumes the shield has a parent)
    void Start()
    {
        
        gameObject.tag = transform.parent.tag;
    }
}
