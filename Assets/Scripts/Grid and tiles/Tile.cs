using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public bool isBlocked = false;
    public Tile cameFromTile;
    public Color originalColor;

    //public PathNode(Grid<PathNode> grid, int x, int y)
    //{
    //    this.grid = grid;
    //    this.x = x;
    //    this.y = y;
    //    isWalkable = true;
    //}

    private void Start()
    {
        x = Mathf.RoundToInt(gameObject.transform.localPosition.x);
        y = Mathf.RoundToInt(gameObject.transform.localPosition.y);
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    public void SetTile()
    {
        x = Mathf.RoundToInt(gameObject.transform.localPosition.x);
        y = Mathf.RoundToInt(gameObject.transform.localPosition.y);
    }
    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void ResetCosts()
    {
        hCost = 0;
        gCost = 0;
        fCost = 0;
    }

        public void SetIsWalkable(bool isWalkable)
    {
        this.isBlocked = isBlocked;
    }

    public void highlight()
    {
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.grey;
    }
}