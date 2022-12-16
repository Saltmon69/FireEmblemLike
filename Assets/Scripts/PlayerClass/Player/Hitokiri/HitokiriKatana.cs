using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitokiriKatana : SkillClass
{
    
    void Start()
    {
        PP = 15;
        skillAttack = 0.35f;
        critChance = 0;
        attackRange = 1;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
    }
    
    public override void Action()
    {
        if (PP >= 1)
        {
            playerPos.TakeDamage(_mouseCursor.selectedSkill, _mouseCursor.selectedEnemy.GetComponent<PlayerClass>());
            _mouseCursor.selectedEnemy.GetComponent<PlayerClass>().debuff = true;
        }
            
        playerPos.hasAttacked = true;
        playerPos.CheckFinishTurn();
    }
}
