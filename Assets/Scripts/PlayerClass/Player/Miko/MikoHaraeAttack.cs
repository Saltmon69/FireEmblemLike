using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoHaraeAttack : SkillClass
{
    // Start is called before the first frame update
    void Start()
    {
        PP = 5;
        skillAttack = 0.8f;
        critChance = 0;
        attackRange = 2;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
    }
    
    public override void Action()
    {
        if (PP >= 1)
        {
            if (_mouseCursor.selectedEnemy.GetComponent<PlayerClass>().isEnemy)
            {
                _mouseCursor.selectedEnemy.GetComponent<PlayerClass>().debuff = true;
            }
            else if(_mouseCursor.selectedEnemy.GetComponent<PlayerClass>().isEnemy == false)
            {
                playerPos.Heal(_mouseCursor.selectedSkill);
            }
        }

        playerPos.hasAttacked = true;
        playerPos.CheckFinishTurn();
    }
    
}
