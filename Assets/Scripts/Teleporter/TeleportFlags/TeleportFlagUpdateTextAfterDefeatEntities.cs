/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFlagUpdateTextAfterDefeatEntities : TeleportFlagUpdateText
{
    public override bool FlagCondition()
    {
        return GetComponent<TeleportFlagDefeatEntities>().FlagCondition();
    }
}
