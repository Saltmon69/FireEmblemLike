using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaAkimbo : SkillClass
{
    // Start is called before the first frame update
    void Start()
    {
        PP = 10;
        skillAttack = 1f;
        attackRange = 3;
        critChance = 1;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GetComponent<MouseCursor>();
        
    }

    public void YakuzaAkimboFonc()
    {
        playerPos.TakeDamage(GetComponent<SkillClass>(), _mouseCursor.selectedEnemy.GetComponent<PlayerClass>());
        playerPos.hasAttacked = true;
    }
    
}
