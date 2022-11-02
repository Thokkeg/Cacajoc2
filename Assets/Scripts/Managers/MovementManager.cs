using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MovementManager : MonoBehaviour
{
    public static MovementManager _instance;
    public static MovementManager Instance { get { return _instance; } }

    public bool highlight_tiles = false;
    public GameObject playerCharMove;
    public GameObject tile2move;
    public GameObject[] tiles;
    public float speed = 3;

    private PathFinding pathFinder;
    private RangeFinder rangeFinder;
    private List<Tile> path;
    private List<Tile> inRangeTiles;
    private float distanceX;
    private float distanceY;
    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        tiles = GameObject.FindGameObjectsWithTag("Tile");
    }

    private void Start()
    {
        pathFinder = new PathFinding();
        rangeFinder = new RangeFinder();
        path = new List<Tile>();
    }

    // Clickar el click dret deselecciona el personatge escollit
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            playerCharMove = null;
            tile2move = null;
            highlight_tiles = false;
            foreach (GameObject tile in tiles)
            {
                tile.GetComponent<ClickTile>().stop_highlight();
                tile.GetComponent<ClickTile>().CharCanMoveToTile = false;
            }
        }
    }

    // Fixet update per moure el personatge cada frame
    void FixedUpdate()
    {
        if (path.Count > 0)
        {
            characterStep();
        }
    }

    // Funcio que crida a iluminar les tiles en las que et pots moure
    public void highlight_tiles2move()
    {
        GetInRangeTiles();

    }

    // Si amb un personatge escollit clickes una tile en la que et pots moure fa la funcio de que es mogui,
    // si no es pot el joc ho ha de avisar
    public void moveCharacter()
    {
        if (tile2move.GetComponent<ClickTile>().CharCanMoveToTile == true)
        {

            path = pathFinder.FindPath(
                playerCharMove.GetComponent<MoveCharacter>().tile.GetComponent<Tile>(), 
                tile2move.GetComponent<Tile>(), inRangeTiles);

            
            tile2move = null;
            highlight_tiles = false;
            foreach (GameObject tile in tiles)
            {
                tile.GetComponent<ClickTile>().stop_highlight();
                tile.GetComponent<ClickTile>().CharCanMoveToTile = false;
                tile.GetComponent<Tile>().ResetCosts();
            }
        }
        else
        {
            Debug.Log("The tile is too far");
            tile2move = null;
        }
    }

    //Cada pas del moviment de un character
    public void characterStep()
    {
        var step = speed * Time.deltaTime;
        playerCharMove.transform.position = Vector2.MoveTowards(playerCharMove.transform.position, path[0].transform.position, step);
        //float zIndex = path[0].transform.position.z;
        playerCharMove.transform.position = new Vector3(playerCharMove.transform.position.x, playerCharMove.transform.position.y, -2);
        if (Vector2.Distance(playerCharMove.transform.position, path[0].transform.position) <= 0)
        {
            PositionCharacterOnLine(path[0]);
            path.RemoveAt(0);

            if (path.Count <= 0)
            {
                //playerCharMove.transform.position = new Vector2(Mathf.RoundToInt(playerCharMove.transform.position.x), Mathf.RoundToInt(playerCharMove.transform.position.y));

                playerCharMove = null;
            }
            
        }
    }
    private void PositionCharacterOnLine(Tile tile)
    {
        playerCharMove.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, -2);
        playerCharMove.GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
        playerCharMove.GetComponent<MoveCharacter>().tile = tile;
    }

    //Agada totes les tiles en el rang del personatge escollit
    private void GetInRangeTiles()
    {
        inRangeTiles = rangeFinder.GetTilesInRange(new Vector2Int(playerCharMove.GetComponent<MoveCharacter>().tile.x, 
            playerCharMove.GetComponent<MoveCharacter>().tile.y),
            playerCharMove.GetComponent<MoveCharacter>().speed);

        foreach (var item in inRangeTiles)
        {
            var path = pathFinder.FindPath(playerCharMove.GetComponent<MoveCharacter>().tile, item,inRangeTiles);
            
            if (item.gCost <= playerCharMove.GetComponent<MoveCharacter>().speed && item.isBlocked == false && item.gCost != 0)
            {
                item.highlight();
                item.GetComponent<ClickTile>().CharCanMoveToTile = true;
            }
        }
    }
    
}
