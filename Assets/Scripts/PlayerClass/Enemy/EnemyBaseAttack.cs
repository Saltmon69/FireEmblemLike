using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseAttack : SkillClass
{
    
    private void Start()
    {
        PP = 999;
        skillAttack = 0.5f;
        critChance = 2;
        attackRange = 3;

    }
    
    public override void Action()
    {

    }


    
    
    
}
