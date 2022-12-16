using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitokiriBaseAttack : SkillClass
{
    // Start is called before the first frame update
    void Start()
    {
        PP = 999;
        skillAttack = 0.8f;
        critChance = 2;
        attackRange = 2;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
    }
    
    public override void Action()
    {
        playerPos.TakeDamage(_mouseCursor.selectedSkill, _mouseCursor.selectedEnemy.GetComponent<PlayerClass>());
        playerPos.hasAttacked = true;
    }


}
