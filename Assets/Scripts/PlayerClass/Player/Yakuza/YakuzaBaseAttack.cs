using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaBaseAttack : SkillClass
{
    private void Start()
    {
        PP = 999;
        skillAttack = 0.75f;
        attackRange = 2;
        critChance = 2;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
    }
    
    public override void Action()
    {
        playerPos.TakeDamage(GetComponent<SkillClass>(), _mouseCursor.selectedEnemy.GetComponent<PlayerClass>());
        playerPos.hasAttacked = true;
        playerPos.CheckFinishTurn();
    }
}
