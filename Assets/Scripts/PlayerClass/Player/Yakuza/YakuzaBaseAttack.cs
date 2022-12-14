using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaBaseAttack : SkillClass
{
    private void Start()
    {
        PP = 999;
        skillAttack = 075f;
        attackRange = 2;
        critChance = 2;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GetComponent<MouseCursor>();
    }
    
    public void YakuzaBaseFonc()
    {
        playerPos.TakeDamage(GetComponent<SkillClass>(), _mouseCursor.selectedEnemy.GetComponent<PlayerClass>());
        playerPos.hasAttacked = true;
    }
}
