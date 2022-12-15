using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAttack : SkillClass
{
    private void Start()
    {
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GetComponent<MouseCursor>();
    }

    public override void Action()
    {
        playerPos.hasAttacked = true;
    }
}
