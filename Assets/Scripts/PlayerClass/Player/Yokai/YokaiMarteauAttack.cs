using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokaiMarteauAttack : SkillClass
{
    public RangeFinder rangeFinder;
    // Start is called before the first frame update
    void Start()
    {
        PP = 5;
        skillAttack = 1f;
        critChance = 1;
        attackRange = 2;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
        rangeFinder = new RangeFinder();
    }
    
    public override void Action()
    {
        if (PP >= 1)
        {
            List<OverlayTiles> tilesInRange = rangeFinder.GetTilesInRange(playerPos._characterTileInfo.activeTile, attackRange);

            foreach (var tiles in tilesInRange.ToArray())
            {
                if (tiles.characterOnTile != null)
                {
                    var ennemis = tiles.characterOnTile.GetComponent<PlayerClass>();

                    playerPos.TakeDamage(_mouseCursor.selectedSkill, ennemis);
                }

            }
        }
        
        playerPos.hasAttacked = true;
        playerPos._GameManager.playerPlayedCounter++;
        playerPos.CheckFinishTurn();
    }

    
}
