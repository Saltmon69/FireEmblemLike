using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RangeFinder
{
    public List<OverlayTiles> inRangeTiles = new List<OverlayTiles>();
    public List<OverlayTiles> GetTilesInRange(OverlayTiles startingTile, int range)
    {
        inRangeTiles.Clear();
        int stepCount = 0;
        
        inRangeTiles.Add(startingTile);

        var tileForPreviousStep = new List<OverlayTiles>();
        tileForPreviousStep.Add(startingTile);

        while (stepCount < range)
        {
            var surroundingTiles = new List<OverlayTiles>();

            foreach (var item in tileForPreviousStep)
            {
                surroundingTiles.AddRange(MapManager.Instance.GetNeighbourTiles(item));
            }
            
            inRangeTiles.AddRange(surroundingTiles);
            tileForPreviousStep = surroundingTiles.Distinct().ToList();
            stepCount++;
        }

        return inRangeTiles.Distinct().ToList();
    }

    public List<OverlayTiles> GetTilesInLine(OverlayTiles startingTile, int range)
    {
        inRangeTiles.Clear();
        int stepCount = 0;

        var tileForPreviousStep = new List<OverlayTiles>();
        tileForPreviousStep.Add(startingTile);
        var tileInLine = new List<OverlayTiles>();

        while (stepCount < range)
        {
            Vector2Int currentTileToCheck = new Vector2Int(startingTile.gridLocation.x + stepCount, startingTile.gridLocation.y);
            
            if (MapManager.Instance.map.ContainsKey(currentTileToCheck))
            {
                if(Mathf.Abs(startingTile.gridLocation.z - MapManager.Instance.map[currentTileToCheck].gridLocation.z) <= 1) 
                    tileInLine.Add(MapManager.Instance.map[currentTileToCheck]);
            }
        
            currentTileToCheck = new Vector2Int(startingTile.gridLocation.x-stepCount, startingTile.gridLocation.y);

            if (MapManager.Instance.map.ContainsKey(currentTileToCheck))
            {
                if (Mathf.Abs(startingTile.gridLocation.z - MapManager.Instance.map[currentTileToCheck].gridLocation.z) <=
                    1)
                    tileInLine.Add(MapManager.Instance.map[currentTileToCheck]);
            }
            currentTileToCheck = new Vector2Int(startingTile.gridLocation.x, startingTile.gridLocation.y+stepCount);

            if (MapManager.Instance.map.ContainsKey(currentTileToCheck))
            {
                if(Mathf.Abs(startingTile.gridLocation.z - MapManager.Instance.map[currentTileToCheck].gridLocation.z) <= 1) 
                    tileInLine.Add(MapManager.Instance.map[currentTileToCheck]);
            }
        
            currentTileToCheck = new Vector2Int(startingTile.gridLocation.x, startingTile.gridLocation.y-stepCount);

            if (MapManager.Instance.map.ContainsKey(currentTileToCheck))
            {
                if(Mathf.Abs(startingTile.gridLocation.z - MapManager.Instance.map[currentTileToCheck].gridLocation.z) <= 1) 
                    tileInLine.Add(MapManager.Instance.map[currentTileToCheck]);
            }

            stepCount++;
        }
        
        inRangeTiles.AddRange(tileInLine);
        return inRangeTiles.Distinct().ToList();
    }
}
