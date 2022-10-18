using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }
    public Dictionary<Vector2Int, Tile> map;
    public bool ignoreBottomTiles;

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
        map = new Dictionary<Vector2Int, Tile>();
        foreach (var tile in GameObject.FindGameObjectsWithTag("Tile"))
        {
            if (tile.GetComponent<Tile>() == null)
            {
                tile.AddComponent<Tile>();
                tile.GetComponent<Tile>().SetTile();

               
            }
            if (tile.GetComponent<Tile>() != null)
            {
                //Debug.Log(tile.name);
                map.Add(new Vector2Int(tile.GetComponent<Tile>().x, tile.GetComponent<Tile>().y), tile.gameObject.GetComponent<Tile>());

                //Debug.Log(tile.GetComponent<Tile>());
            }
        }

    }

    public List<Tile> GetSurroundingTiles(Vector2Int originTile)
    {
        var surroundingTiles = new List<Tile>();


        Vector2Int TileToCheck = new Vector2Int(originTile.x + 1, originTile.y);
        if (map.ContainsKey(TileToCheck))
        {
            if (Mathf.Abs(map[TileToCheck].transform.position.z - map[originTile].transform.position.z) <= 1)
                surroundingTiles.Add(map[TileToCheck]);
        }

        TileToCheck = new Vector2Int(originTile.x - 1, originTile.y);
        if (map.ContainsKey(TileToCheck))
          {
            if (Mathf.Abs(map[TileToCheck].transform.position.z - map[originTile].transform.position.z) <= 1)
                surroundingTiles.Add(map[TileToCheck]);
        }

        TileToCheck = new Vector2Int(originTile.x, originTile.y + 1);
        if (map.ContainsKey(TileToCheck))
        {
            if (Mathf.Abs(map[TileToCheck].transform.position.z - map[originTile].transform.position.z) <= 1)
                surroundingTiles.Add(map[TileToCheck]);
        }

        TileToCheck = new Vector2Int(originTile.x, originTile.y - 1);
        if (map.ContainsKey(TileToCheck))
        {
            if (Mathf.Abs(map[TileToCheck].transform.position.z - map[originTile].transform.position.z) <= 1)
                surroundingTiles.Add(map[TileToCheck]);
        }

        return surroundingTiles;
    }
}
