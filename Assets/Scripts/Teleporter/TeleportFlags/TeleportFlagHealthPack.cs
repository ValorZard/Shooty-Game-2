/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFlagHealthPack : TeleportFlagBase
{
    protected override void FlagStart() {}

    public override bool FlagCondition()
    {
        PowerupHeal[] scripts = FindObjectsOfType<PowerupHeal>();

        return scripts.Length == 0;
    }

    protected override void FlagActivation()
    {
        m_Teleporter.GetComponent<TeleportBase>().Enable();
    }

    protected override void FlagAlternate() {}
}
