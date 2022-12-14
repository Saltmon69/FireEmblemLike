using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : PlayerClass
{
    public MouseCursor _MouseCursor;
    public PlayerClass playerToFocus;
    public SkillClass attack;
    public EntitiesPositions playerList;
    public GameManager gameManager;
    List<CharacterTileInfo> playersInRange = new List<CharacterTileInfo>();

    private bool playerInRange;
    
    private void Start()
    {
        //Scripts
        _RangeFinder = new RangeFinder();
        _PathFinder = new PathFinder();
        _MouseCursor = new MouseCursor();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
        
        // Texts
        
        className = "Mailman";
        
        //Stats
        
        life = 50f;
        movement = 8;
        dodge = 2f;
        classAttack = 20f;
        defense = 18f;
        
        //Attack

        attack = skillList[0];
        
        playerToFocus = entityInRangeList[UnityEngine.Random.Range(0, entityInRangeList.Count -1)];
        
        //States
        hasAttacked = false;
        hasMoved = false;

    }

    private void Update()
    {
        if (!playerToFocus.isActiveAndEnabled)
            playerToFocus = entityInRangeList[UnityEngine.Random.Range(0, entityInRangeList.Count -1)];
        
        if (gameManager.enemyTurn)
        {
            CheckIfInAttackRange();
            Debug.Log("Je viens de check si un player est dans la range");
            print(playerInRange);
            
            if (!playerInRange && !hasMoved)
            {
                Movement();
            }

            if (playerInRange && !hasAttacked)
            {
                Attack();
            }

            if (!playerInRange && !hasMoved)
            {
                hasAttacked = true;
            }
        }

        if (hasAttacked)
            hasMoved = true;
            gameManager.enemyPlayedCounter++;
        
        


    }


    private void Attack()
    {
        TakeDamage(attack, playerToFocus);
    }
    
    public void Movement()
    {
        List<OverlayTiles> tilesRange = _RangeFinder.GetTilesInRange(_characterTileInfo.activeTile, movement);
        List<OverlayTiles> pathfindingTiles =
            _PathFinder.FindPath(_characterTileInfo.activeTile, playerToFocus._characterTileInfo.activeTile);
        List<OverlayTiles> pathInRange = new List<OverlayTiles>();


        foreach (OverlayTiles tilesInGloblalPath in pathfindingTiles)
        {
            foreach (OverlayTiles tilesInRange in tilesRange)
            {
                if (tilesInRange == tilesInGloblalPath)
                {
                    pathInRange.Add(tilesInRange);
                }
                else
                {
                    tilesRange.Remove(tilesInRange);
                }
            }
        }
        foreach (var tiles in pathInRange)
        {
            pathfindingTiles.Remove(tiles);
        }
        
        _MouseCursor.MoveAlongPath(pathInRange, _characterTileInfo);

        pathInRange.Clear();
        
    }

    public void CheckIfInAttackRange()
    {
        List<OverlayTiles> rangeList = _RangeFinder.GetTilesInRange(_characterTileInfo.activeTile, attack.attackRange);

        foreach (var tilesInRange in rangeList)
        {
            foreach (CharacterTileInfo playerPos in playerList.playerPositions)
            {
                if (playerPos.activeTile == tilesInRange)
                {
                    playerInRange = true;
                    playersInRange.Add(playerPos);
                    break;
                }
                else
                {
                    playerInRange = false;
                }
            }
        }
    }

}
