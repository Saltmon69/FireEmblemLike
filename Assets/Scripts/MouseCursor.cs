using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    
    public float speed;
    [SerializeField] private LayerMask _layer;
    public GameObject characterPrefab;
    private GameObject takedCharacter; // Character choiced by left click
    private GameObject selectedCharacter; // Character choiced by right click
    private OverlayTiles previousTile;

    private List<OverlayTiles> inRangeTiles = new List<OverlayTiles>();

    private PathFinder _pathfinder;
    private RangeFinder _rangefinder;


    private bool selectingAction = false;
    public SkillClass selectedSkill;
    public GameObject selectedEnemy;

    private void Start()
    {
        _pathfinder = new PathFinder();
        _rangefinder = new RangeFinder();
    }

    // Update is called once per frame
    void Update()
    {
        var focusedTileHit = GetFocusedOnTile();
        
        if (focusedTileHit.HasValue)
        {
            OverlayTiles hoveredTile = focusedTileHit.Value.collider.gameObject.GetComponent<OverlayTiles>();
            if(!selectingAction) transform.position = hoveredTile.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = hoveredTile.gameObject.GetComponent<SpriteRenderer>().sortingOrder+1;

            if (Input.GetMouseButtonDown(0))
            {
               
                if(selectingAction) return;
                
                // If Player using skill
                if(hoveredTile.characterOnTile != null &&  hoveredTile.characterOnTile.GetComponent<PlayerClass>().isEnemy)
                {
                    selectedEnemy = hoveredTile.characterOnTile;
                    if (selectedSkill != null)
                    {
                        HidePreviousTiles();
                        selectedEnemy.GetComponent<PlayerClass>().TakeDamage(selectedSkill, selectedCharacter.GetComponent<PlayerClass>());
                        print( selectedEnemy.GetComponent<PlayerClass>().life);
                        selectedCharacter = null;
                        selectedSkill = null;
                    }
                    else
                    {
                        return;
                    }
                    return;   
                }
                
                
                // Moving Character Part ↓
                
                if (takedCharacter == null && hoveredTile.characterOnTile != null)
                {
                    print("character clicked");
                    takedCharacter = hoveredTile.characterOnTile;
                    previousTile = hoveredTile;
                    hoveredTile.characterOnTile = null;
                    GetInRangeTiles(takedCharacter.GetComponent<CharacterTileInfo>(), 3);
                    takedCharacter.GetComponent<CharacterTileInfo>().activeTile = null;
                }
                else
                {
                    // Check if tile is in range
                    if(!CheckInRangeTiles(hoveredTile,previousTile, 3)) return;
                        
                    // Place Selected Character on clicked tile
                    if (hoveredTile.characterOnTile == null && !hoveredTile.isBlocked && takedCharacter != null)
                    {
                        PositionCharacterOnTile(hoveredTile, takedCharacter.GetComponent<CharacterTileInfo>());
                        HidePreviousTiles();
                        takedCharacter = null;
                    }
                        
                }

            }
            else
            {
                
                if (Input.GetMouseButtonDown(1))
                {
                    if(hoveredTile.characterOnTile != null && !hoveredTile.characterOnTile.GetComponent<PlayerClass>().isEnemy)  // <== Check si y'a bien un personnage et si il est joueur
                    {
                        selectedCharacter = null;
                        selectedSkill = null;
                        hoveredTile.characterOnTile.transform.GetChild(0).gameObject.SetActive(true);
                        selectingAction = true;
                        selectedCharacter = hoveredTile.characterOnTile;
                    }
                    
                }
                
            }
            
        }
        
        // Selected Character follow mouse cursor
        
        if (takedCharacter != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(takedCharacter.transform.position).z);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);

            takedCharacter.transform.position = new Vector3(worldPos.x, -2f, worldPos.z);
        }

    }

    public void GetInRangeTiles(CharacterTileInfo character, int range, bool inSkill = false)
    {
        HidePreviousTiles();

        if (selectedSkill.attackRange != 8)
        {
            inRangeTiles = _rangefinder.GetTilesInRange(character.activeTile, range);
        }
        else
        {
            inRangeTiles = _rangefinder.GetTilesInLine(character.activeTile, 8);
        }

        foreach (var item in inRangeTiles)
        {
            if (inSkill)
            {
                
                if (item.characterOnTile != null && item.characterOnTile.GetComponent<PlayerClass>().isEnemy)
                {
                    item.TargetTile();
                }
                else
                {
                    item.SkillTile();
                }
            }
            else
            {
                item.ShowTile();
            }
            
        }
    }
    
    private bool CheckInRangeTiles(OverlayTiles currentTile, OverlayTiles previousTile, int range)
    {

        foreach (var tile in inRangeTiles)
        {
            if (tile == currentTile) return true;

        }

        return false;
    }

    private void HidePreviousTiles()
    {
        foreach (var item in inRangeTiles)
        {
            item.HideTile();
        }
    }
    
    public RaycastHit? GetFocusedOnTile()
    {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Debug.Log(mousePos);
        RaycastHit[] hits = Physics.RaycastAll(mousePos, Mathf.Infinity, _layer);

        if (hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }
        return null;
    }

    public void MoveAlongPath(List<OverlayTiles> path, CharacterTileInfo characterSelected)
      {
          var step = speed * Time.deltaTime;
     
          var yIndex = path[0].transform.position.y;
          characterSelected.transform.position = Vector2.MoveTowards(characterSelected.transform.position, path[0].transform.position, step);
          characterSelected.transform.position =
             new Vector3(characterSelected.transform.position.x, yIndex, characterSelected.transform.position.y);
          if (Vector2.Distance(characterSelected.transform.position, path[0].transform.position) < 0.0001f)
          {
              PositionCharacterOnTile(path[0], characterSelected);
              path.RemoveAt(0);
          }
     }

    public void PositionCharacterOnTile(OverlayTiles tile, CharacterTileInfo characterSelected)
    {
        print(tile.transform.position);
        characterSelected.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y+1f, tile.transform.position.z);
        characterSelected.GetComponentInChildren<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder + 1;
        characterSelected.activeTile = tile;
        tile.characterOnTile = characterSelected.gameObject;
    }

    public void SelectAction(SkillClass action)
    {
        HidePreviousTiles();
        selectedSkill = action;
        print(selectedSkill);
        GetInRangeTiles(selectedCharacter.GetComponent<CharacterTileInfo>(), selectedSkill.attackRange, true);
        selectedCharacter.transform.GetChild(0).gameObject.SetActive(false);
        selectingAction = false;
    }

    public void QuitSelectAction()
    {
        selectedCharacter.transform.GetChild(0).gameObject.SetActive(false);
        selectingAction = false;
    }
}