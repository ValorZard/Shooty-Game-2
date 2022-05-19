/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Similar to the Teleport script; however, when this teleporter is
    activated, another scene loads.
*/

public class TeleportExit : TeleportBaseInScene
{
    protected override void EnterComplete(Collider2D other)
    {
        // Move to the next scene
        GetComponent<StartScript>().StartGame();
    }
}
