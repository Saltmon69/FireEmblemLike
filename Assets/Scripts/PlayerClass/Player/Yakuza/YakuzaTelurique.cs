using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaTelurique : SkillClass
{
    PathFinder _pathfinder;
    // Start is called before the first frame update
    void Start()
    {
        PP = 5;
        skillAttack = 8f;
        attackRange = 8;
        critChance = 1;
        playerPos = GetComponent<PlayerClass>();
        _mouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
        _pathfinder = new PathFinder();
    }
    public override void Action()
    {
        List<OverlayTiles> tiles = _pathfinder.FindPath(GetComponent<CharacterTileInfo>().activeTile, _mouseCursor.selectedEnemy.GetComponent<CharacterTileInfo>().activeTile);
        tiles.Remove(GetComponent<CharacterTileInfo>().activeTile);
        
        foreach(var tile in tiles)
        {
            if(tile.characterOnTile != null && tile.characterOnTile.GetComponent<PlayerClass>().isEnemy) 
            {
                skillAttack = skillAttack/tiles.IndexOf(tile);
                skillAttack = -skillAttack;
                playerPos.TakeDamage(this, tile.characterOnTile.GetComponent<PlayerClass>());
                skillAttack = -skillAttack;

            }
        }

        playerPos.hasAttacked = true;
        playerPos.CheckFinishTurn();
    }
}
