using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAttack : SkillClass
{
    private void Start()
    {
        attackRange = 0;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
    }

    public override void Action()
    {
        _mouseCursor.HidePreviousTiles();
        playerPos.hasAttacked = true;
        playerPos.CheckFinishTurn();
    }
}
