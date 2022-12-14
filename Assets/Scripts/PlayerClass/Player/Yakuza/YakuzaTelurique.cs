using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaTelurique : SkillClass
{
    // Start is called before the first frame update
    void Start()
    {
        PP = 5;
        skillAttack = 1.5f;
        attackRange = 8;
        critChance = 1;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GetComponent<MouseCursor>();
    }
    
    public void YakuzaTeluriqueFonc()
    {
        playerPos.TakeDamage(GetComponent<SkillClass>(), _mouseCursor.selectedEnemy.GetComponent<PlayerClass>());
        playerPos.hasAttacked = true;
    }
}