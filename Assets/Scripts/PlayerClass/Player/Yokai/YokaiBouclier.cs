using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokaiBouclier : SkillClass
{
    // Start is called before the first frame update
    void Start()
    {
        PP = 10;
        skillAttack = 0;
        critChance = 0;
        attackRange = 0;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
    }
    
    public override void Action()
    {
        if (PP >= 1)
        {
            if (playerPos.poupee)
            {
                Debug.Log("Déjà en taunt");
                return;
            }

            if (playerPos.monstre)
            {
                playerPos.poupee = true;
                playerPos.oldLife = playerPos.life;
                playerPos.life = 30f;
                playerPos.hasAttacked = true;
                playerPos._GameManager.playerPlayedCounter++;
                playerPos.CheckFinishTurn();
            }

        }
    }


}
