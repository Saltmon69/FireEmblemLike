using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaAkimbo : SkillClass
{
    public RangeFinder _rangeFinder;
    // Start is called before the first frame update
    void Start()
    {
        PP = 10;
        skillAttack = 1f;
        attackRange = 3;
        critChance = 1;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();

        _rangeFinder = new RangeFinder();

    }

    public override void Action()
    {
        SkillClass skillUsed = GetComponent<SkillClass>();
        List<OverlayTiles> listForRicochet = _rangeFinder.GetTilesInRange(playerPos._characterTileInfo.activeTile, 1);

        foreach (var tiles in listForRicochet)
        {
            if (tiles.characterOnTile != null)
            {
               playerPos.entityInRangeList.Add(tiles.characterOnTile.GetComponent<PlayerClass>());
            }
        }

        print(_mouseCursor.selectedEnemy);

        playerPos.TakeDamage(skillUsed, _mouseCursor.selectedEnemy.GetComponent<PlayerClass>());
        if (playerPos.entityInRangeList.Count > 0)
        {
            foreach (var enemy in playerPos.entityInRangeList)
            {
                print(playerPos.TakeDamageForRicochet(skillUsed, enemy));
            }
        }
        
        playerPos.entityInRangeList.Clear();
        
        playerPos.hasAttacked = true;
        playerPos.CheckFinishTurn();
    }
    
}
