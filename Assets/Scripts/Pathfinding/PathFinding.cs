using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinding
{
    private Dictionary<Vector2Int, Tile> searchableTiles;
    public List<Tile> FindPath(Tile start, Tile end, List<Tile> inRangeTiles)
    {
        searchableTiles = new Dictionary<Vector2Int, Tile>();

        List<Tile> openList = new List<Tile>();
        List<Tile> closedList = new List<Tile>();

        if (inRangeTiles.Count > 0)
        {
            foreach (var item in inRangeTiles)
            {
                searchableTiles.Add(new Vector2Int(item.x,item.y), MapManager.Instance.map[new Vector2Int(item.x, item.y)]);
            }
        }
        else
        {
            searchableTiles = MapManager.Instance.map;
        }

        openList.Add(start);

        while (openList.Count > 0)
        {
            Tile currentTile = openList.OrderBy(x => x.fCost).First();

            openList.Remove(currentTile);
            closedList.Add(currentTile);

            if (currentTile == end)
            {
                return GetFinishedList(start, end);
            }

            foreach (var tile in GetNeightbourOverlayTiles(currentTile))
            {
                if (tile.isBlocked|| closedList.Contains(tile) || Mathf.Abs(currentTile.transform.position.z - tile.transform.position.z) > 1)
                {
                    continue;
                }

                tile.gCost = GetManhattenDistance(start, tile);
                tile.hCost = GetManhattenDistance(end, tile);
                tile.CalculateFCost();

                tile.cameFromTile = currentTile;


                if (!openList.Contains(tile))
                {
                    openList.Add(tile);
                }
            }
        }

        return new List<Tile>();
    }

    private List<Tile> GetFinishedList(Tile start, Tile end)
    {
        List<Tile> finishedList = new List<Tile>();
        Tile currentTile = end;

        while (currentTile != start)
        {
            finishedList.Add(currentTile);
            currentTile = currentTile.cameFromTile;
        }

        finishedList.Reverse();

        return finishedList;
    }

    public int GetManhattenDistance(Tile start, Tile tile)
    {
        return Mathf.Abs(start.x - tile.x) + Mathf.Abs(start.y - tile.y);
    }

    private List<Tile> GetNeightbourOverlayTiles(Tile currentOverlayTile)
    {
        var map = MapManager.Instance.map;

        List<Tile> neighbours = new List<Tile>();

        //right
        Vector2Int locationToCheck = new Vector2Int(
            currentOverlayTile.x + 1,
            currentOverlayTile.y
        );

        if (searchableTiles.ContainsKey(locationToCheck))
        {
            neighbours.Add(searchableTiles[locationToCheck]);
        }

        //left
        locationToCheck = new Vector2Int(
            currentOverlayTile.x - 1,
            currentOverlayTile.y
        );

        if (searchableTiles.ContainsKey(locationToCheck))
        {
            neighbours.Add(searchableTiles[locationToCheck]);
        }

        //top
        locationToCheck = new Vector2Int(
            currentOverlayTile.x,
            currentOverlayTile.y + 1
        );

        if (searchableTiles.ContainsKey(locationToCheck))
        {
            neighbours.Add(searchableTiles[locationToCheck]);
        }

        //bottom
        locationToCheck = new Vector2Int(
            currentOverlayTile.x,
            currentOverlayTile.y - 1
        );

        if (searchableTiles.ContainsKey(locationToCheck))
        {
            neighbours.Add(searchableTiles[locationToCheck]);
        }

        return neighbours;
    }


}
