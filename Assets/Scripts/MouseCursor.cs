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
    private CharacterTileInfo character;
    private GameObject selectedCharacter;

    private List<OverlayTiles> inRangeTiles = new List<OverlayTiles>();

    private PathFinder _pathfinder;
    private RangeFinder _rangefinder;

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
            OverlayTiles overlayTile = focusedTileHit.Value.collider.gameObject.GetComponent<OverlayTiles>();
            transform.position = overlayTile.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = overlayTile.gameObject.GetComponent<SpriteRenderer>().sortingOrder+1;
            
            if (Input.GetMouseButtonDown(0))
            {
                overlayTile.ShowTile();

                if (character == null)
                {
                    character = Instantiate(characterPrefab).GetComponent<CharacterTileInfo>();
                    PositionCharacterOnTile(overlayTile, character);
                    GetInRangeTiles();
                }
                else
                {
                    
                    if (character.activeTile == overlayTile)
                    {
                        print("character clicked");
                        selectedCharacter = overlayTile.characterOnTile;
                        overlayTile.characterOnTile = null;
                        character.activeTile = null;
                        
                    }
                    else
                    {
                        if (overlayTile.characterOnTile == null && !overlayTile.isBlocked && selectedCharacter != null)
                        {
                            PositionCharacterOnTile(overlayTile, selectedCharacter.GetComponent<CharacterTileInfo>());
                            selectedCharacter = null;
                        }
                    }
                    
                }
                
            }
        }

        if (selectedCharacter != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(selectedCharacter.transform.position).z);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);

            selectedCharacter.transform.position = new Vector3(worldPos.x, -2f, worldPos.z);
        }

    }

    private void GetInRangeTiles()
    {
        foreach (var item in inRangeTiles)
        {
            item.HideTile();
        }

        inRangeTiles = _rangefinder.GetTilesInRange(character.activeTile, 3);

        foreach (var item in inRangeTiles)
        {
            item.ShowTile();
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

     private void MoveAlongPath(List<OverlayTiles> path, CharacterTileInfo characterSelected)
     {
         var step = speed * Time.deltaTime;
    
         var yIndex = path[0].transform.position.y;
         character.transform.position = Vector2.MoveTowards(character.transform.position, path[0].transform.position, step);
         character.transform.position =
            new Vector3(character.transform.position.x, yIndex, character.transform.position.y);
         if (Vector2.Distance(character.transform.position, path[0].transform.position) < 0.0001f)
         {
             PositionCharacterOnTile(path[0], characterSelected);
             path.RemoveAt(0);
         }
     }

    private void PositionCharacterOnTile(OverlayTiles tile, CharacterTileInfo characterSelected)
    {
        print(tile.transform.position);
        characterSelected.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y+0.5f, tile.transform.position.z);
        characterSelected.GetComponentInChildren<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder + 1;
        characterSelected.activeTile = tile;
        tile.characterOnTile = characterSelected.gameObject;
    }
}