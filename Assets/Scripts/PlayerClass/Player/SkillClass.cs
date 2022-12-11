using System.Collections;
using System.Collections.Generic;using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class SkillClass : MonoBehaviour
{
    public int PP;
    public float skillAttack;
    public int critChance;
    public int attackRange;

    public List<PlayerClass> enemyList = new List<PlayerClass>();
    
    // Range et détection
    public RangeFinder _rangeFinder;
    public PlayerClass playerPos;

    public void TilesInAttackRange(int range)
    {
        List<OverlayTiles> tilesInRangeList = _rangeFinder.GetTilesInRange(playerPos._characterTileInfo.activeTile, range);

        foreach (OverlayTiles tiles in tilesInRangeList)
        {
            if (tiles.characterOnTile == null)
            {
                break;
            }

            if (tiles.characterOnTile)
            {
                enemyList.Add(tiles.characterOnTile.GetComponent<PlayerClass>());
            }
        }
    }
    




}
