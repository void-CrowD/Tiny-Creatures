using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class ReusableOrganButton : DisposableOrganButton
{
    public override void Rise()
    {
        base.Rise();
        foreach (TrapDoor trapDoor in boundObjectList)
        {
            trapDoor.Move();
        }
        transform.position = new Vector2(transform.position.x, transform.position.y + depth);
    }
}