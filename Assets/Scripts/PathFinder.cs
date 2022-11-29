using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder
{
    public List<OverlayTiles> FindPath(OverlayTiles start, OverlayTiles end)
    {
        List<OverlayTiles> openList = new List<OverlayTiles>();
        List<OverlayTiles> closedList = new List<OverlayTiles>();
        
        openList.Add(start);

        while (openList.Count > 0)
        {
            OverlayTiles currentOverlayTile = openList.OrderBy(x => x.F).First();
            openList.Remove(currentOverlayTile);
            closedList.Add(currentOverlayTile);

            if (currentOverlayTile == end)
            {
                //end
                return GetFinishedList(start, end);
            }

            var neighbourTiles = MapManager.Instance.GetNeighbourTiles(currentOverlayTile);
            foreach (var neighbour in neighbourTiles)
            {
                if (neighbour.isBlocked || closedList.Contains(neighbour))
                {
                    continue;
                }

                neighbour.G = GetManhattenDistance(start, neighbour);
                neighbour.H = GetManhattenDistance(end, neighbour);

                neighbour.previous = currentOverlayTile;

                if (!openList.Contains(neighbour))
                {
                    openList.Add(neighbour);
                }
            }
        }

        return new List<OverlayTiles>();
    }

    private List<OverlayTiles> GetFinishedList(OverlayTiles start, OverlayTiles end)
    {
        List<OverlayTiles> finishedList = new List<OverlayTiles>();

        OverlayTiles currentTile = end;

        while (currentTile != start)
        {
            finishedList.Add(currentTile);
            currentTile = currentTile.previous;
        }

        finishedList.Reverse();
        return finishedList;
    }

    private int GetManhattenDistance(OverlayTiles start, OverlayTiles neighbour)
    {
        return Mathf.Abs(start.gridLocation.x - neighbour.gridLocation.x) + Mathf.Abs(start.gridLocation.z - neighbour.gridLocation.z);
    }
    
}
