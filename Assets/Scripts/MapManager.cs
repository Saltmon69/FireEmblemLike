using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;
    
    public static MapManager Instance { get { return _instance;  } }

    public OverlayTiles overlayTilePrefab;
    public GameObject overlayContainer;
    public Dictionary<Vector2Int, OverlayTiles> map;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        var tileMap = gameObject.GetComponentInChildren<Tilemap>();
        map = new Dictionary<Vector2Int, OverlayTiles>();
        BoundsInt bound = tileMap.cellBounds;

        for (int z = bound.min.z; z < bound.max.z; z++)
        {
            for (int y = bound.min.y; y < bound.max.y; y++)
            {
                for (int x = bound.min.x; x < bound.max.x; x++)
                {
                    
                    var tileLocation = new Vector3Int(x, y, z);
                    var tileKey = new Vector2Int(x, y);
                    if (tileMap.HasTile(tileLocation) && !map.ContainsKey(tileKey))
                    {
                        var overlayTile = Instantiate(overlayTilePrefab, overlayContainer.transform);
                        var cellWorldPos = tileMap.GetCellCenterWorld(tileLocation);

                        overlayTile.transform.position = new Vector3(cellWorldPos.x, cellWorldPos.y, cellWorldPos.z);
                        overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tileMap.GetComponent<TilemapRenderer>().sortingOrder+1;
                        overlayTile.gridLocation = tileLocation;
                        map.Add(tileKey, overlayTile);
                    }
                    
                }
            }
        }
        
    }
    
    public List<OverlayTiles> GetNeighbourTiles(OverlayTiles currentOverlayTile)
    {
        var map = MapManager.Instance.map;
        List<OverlayTiles> neighbours = new List<OverlayTiles>();
        Vector2Int locationToCheck = new Vector2Int(currentOverlayTile.gridLocation.x, currentOverlayTile.gridLocation.y+1);

        if (map.ContainsKey(locationToCheck))
        {
            if(Mathf.Abs(currentOverlayTile.gridLocation.z - map[locationToCheck].gridLocation.z) <= 1) 
                neighbours.Add(map[locationToCheck]);
        }
        
        locationToCheck = new Vector2Int(currentOverlayTile.gridLocation.x, currentOverlayTile.gridLocation.y-1);

        if (map.ContainsKey(locationToCheck))
        {
            if(Mathf.Abs(currentOverlayTile.gridLocation.z - map[locationToCheck].gridLocation.z) <= 1) 
                neighbours.Add(map[locationToCheck]);
        }
        
        locationToCheck = new Vector2Int(currentOverlayTile.gridLocation.x+1, currentOverlayTile.gridLocation.y);

        if (map.ContainsKey(locationToCheck))
        {
            if(Mathf.Abs(currentOverlayTile.gridLocation.z - map[locationToCheck].gridLocation.z) <= 1) 
                neighbours.Add(map[locationToCheck]);
        }
        
        locationToCheck = new Vector2Int(currentOverlayTile.gridLocation.x-1, currentOverlayTile.gridLocation.y);

        if (map.ContainsKey(locationToCheck))
        {
            if(Mathf.Abs(currentOverlayTile.gridLocation.z - map[locationToCheck].gridLocation.z) <= 1) 
                neighbours.Add(map[locationToCheck]);
        }

        return neighbours;
    }
}
