using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintokiriAnsatsu : SkillClass
{
    // Start is called before the first frame update
    void Start()
    {
        PP = 5;
        skillAttack = 1;
        critChance = 3;
        attackRange = 2;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
    }

    public override void Action()
    {
        if (PP >= 1)
        {
            playerPos.TakeDamage(_mouseCursor.selectedSkill, _mouseCursor.selectedEnemy.GetComponent<PlayerClass>());
            
        }
            
        playerPos.hasAttacked = true;
    }
}
