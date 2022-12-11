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
}
