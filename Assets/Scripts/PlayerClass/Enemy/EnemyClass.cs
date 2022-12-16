using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class EnemyClass : PlayerClass
{
    public MouseCursor _MouseCursor;
    public PlayerClass playerToFocus;
    public SkillClass attack;
    public EntitiesPositions playerList;
    public GameManager gameManager;
    
    public List<GameObject> playersInRange = new List<GameObject>();
    public List<OverlayTiles> pathfindingTiles = new List<OverlayTiles>();
    public List<OverlayTiles> pathInRange = new List<OverlayTiles>();
    public List<OverlayTiles> rangeList = new List<OverlayTiles>();
    public List<OverlayTiles> tilesRange = new List<OverlayTiles>();
    
    public int debuffcounter;

    private bool playerInRange;
    
    private void Start()
    {
        //Scripts
        _RangeFinder = new RangeFinder();
        _PathFinder = new PathFinder();
        
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _characterTileInfo = GetComponent<CharacterTileInfo>();
        _MouseCursor = GameObject.Find("Cursor").GetComponent<MouseCursor>();
        
        
        // Texts
        
        className = "Mailman";
        
        //Stats
        
        life = 50f;
        movement = 3;
        dodge = 2f;
        classAttack = 20f;
        defense = 18f;
        
        //Attack

        attack = skillList[0];
        
        //States
        hasAttacked = false;
        hasMoved = false;

    }
    private void Update()
    {
        
        if (!playerToFocus.isActiveAndEnabled)
        {
            Debug.Log("je cherche un ennemi");
            playerToFocus = playerList.playerPositions[UnityEngine.Random.Range(0, playerList.playerPositions.Count + 1)].GetComponent<PlayerClass>();
        }  
        
        if (gameManager.enemyTurn)
        {
            Debug.Log("C'est le tour de l'ennemi");
            if (debuffcounter >= 2)
            {
                debuff = false;
                debuffcounter = 0;
            }
            if (debuff)
            {
                debuffcounter++;
            }
            hasMoved = false;
            hasAttacked = false;
            if (_characterTileInfo != null)
                CheckIfInAttackRange(_characterTileInfo.activeTile);

           
            Debug.Log("Je viens de check si un player est dans la range");
            print(playerInRange);
            
            if (!playerInRange && !hasMoved)
            {
                Debug.Log("Je bouge");
                Movement(_characterTileInfo);
                hasMoved = true;
            }

            if (playerInRange && !hasAttacked)
            {
                
                var dodgedice = UnityEngine.Random.Range(1, 7);
                if (playerToFocus.dodge >= dodgedice)
                {
                    Debug.Log("Le Joueur a esquivé");
                    hasAttacked = true;
                }

                if (playerToFocus.dodge < dodgedice)
                {
                    Attack();
                    Debug.Log("J'attaque");
                    hasAttacked = true;
                }
                _GameManager.CheckIfEnemyTurnFinished();
            }

            if (hasAttacked) {
                hasMoved = true;
                gameManager.enemyPlayedCounter++;
            }
        }

    }
    private void Attack()
    {
        print(TakeDamage(attack, playerToFocus));

    }
    public void Movement(CharacterTileInfo characterTileInfo)
    {
        tilesRange.Clear();
        pathInRange.Clear();
        _characterTileInfo = GetComponent<CharacterTileInfo>();
        tilesRange = _RangeFinder.GetTilesInRange(characterTileInfo.activeTile, movement);
        pathfindingTiles = _PathFinder.FindPath(characterTileInfo.activeTile, playerToFocus._characterTileInfo.activeTile);
        


        foreach (OverlayTiles tilesInGloblalPath in pathfindingTiles.ToArray())
        {
            foreach (OverlayTiles tilesInRange in tilesRange.ToArray())
            {
                if (tilesInRange == tilesInGloblalPath)
                {
                    pathInRange.Add(tilesInRange);
                }
            }
        }

        if(pathInRange[pathInRange.Count-1].characterOnTile == null) 
        {
            PositionCharacterOnTile(pathInRange[pathInRange.Count - 1], _characterTileInfo);
        } else {
            PositionCharacterOnTile(pathInRange[pathInRange.Count - 2], _characterTileInfo);
        }
        

        foreach (var tiles in pathInRange)
        {
            pathfindingTiles.Remove(tiles);
        }
        
    }
    public void CheckIfInAttackRange(OverlayTiles characterTileInfo)
    {
        print(characterTileInfo);
        playersInRange.Clear();
        
        rangeList = _RangeFinder.GetTilesInRange(characterTileInfo, 3);

        foreach (var tilesInRange in rangeList.ToArray())
        {
            if (tilesInRange.characterOnTile != null &&
                !tilesInRange.characterOnTile.GetComponent<PlayerClass>().isEnemy)
            {
                playersInRange.Add(tilesInRange.characterOnTile);
            }
            
        }

        if(playersInRange.Count > 0) 
        {
            playerInRange = true;
            playerToFocus = playersInRange[0].GetComponent<PlayerClass>();
        } else {
            playerInRange = false;
        }
    }
    public void PositionCharacterOnTile(OverlayTiles newTile, CharacterTileInfo character)
    {
        character.transform.position = new Vector3(newTile.transform.position.x, newTile.transform.position.y+1f, newTile.transform.position.z);
        character.GetComponentInChildren<SpriteRenderer>().sortingOrder = newTile.GetComponent<SpriteRenderer>().sortingOrder + 1;
        character.activeTile.characterOnTile = null;
        character.activeTile = newTile;
        newTile.characterOnTile = character.gameObject;
    }
}
