using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoNoritoAttack : SkillClass
{
    // Start is called before the first frame update
    void Start()
    {
        PP = 15;
        skillAttack = 0.25f;
        critChance = 0;
        attackRange = 1;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
    }

    public override void Action()
    {
        if (PP >= 1)
            playerPos.Heal(_mouseCursor.selectedSkill);
        playerPos.hasAttacked = true;
        playerPos.CheckFinishTurn();
    }
}
