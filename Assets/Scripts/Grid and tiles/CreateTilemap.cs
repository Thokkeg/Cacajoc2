using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTilemap : MonoBehaviour
{
    [SerializeField]
    public Sprite referenceTile;
    [SerializeField]
    private int rows = 16;
    [SerializeField]
    private int cols = 16;
    [SerializeField]
    public float tilesize;
    int ver, hor;

    void Start()
    {

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GenerateGrid(i, j);
            }
        }
    }

    private void GenerateGrid(int x, int y)
    {
        GameObject g = new GameObject("x:" + x +" "+ "y:" + y);
        g.transform.position = transform.position + (new Vector3(x * tilesize, y * tilesize));
        var s = g.AddComponent<SpriteRenderer>();
        g.transform.SetParent(GameObject.Find("Grid").transform, false);
        g.AddComponent<ClickTile>();
        g.AddComponent<BoxCollider2D>();
        g.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
        s.sprite = referenceTile;
        s.transform.localScale = new Vector2(tilesize, tilesize);
        var ran = Random.Range(0.3f, -0.3f);
    }
}
