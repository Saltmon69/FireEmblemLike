using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : PlayerClass
{
    public PlayerClass playerToFocus;
    public SkillClass attack;
    private void Start()
    {
        // Texts
        
        className = "Mailman";
        
        //Stats
        
        life = 50f;
        movement = 8;
        dodge = 2f;
        classAttack = 20f;
        defense = 18f;
        
        //Attack

        attack = skillList[0];

        playerToFocus = attack.enemyList[UnityEngine.Random.Range(0, attack.enemyList.Count + 1)];


    }


    
    public override void Movement()
    {
        
    }
    
    private void Attack()
    {
        playerToFocus.TakeDamage(attack);
    }
}
