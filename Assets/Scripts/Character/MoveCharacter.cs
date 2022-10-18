using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private bool moveMode = false;
    public int speed = 1;
    public Tile tile;
    private void OnMouseDown()
    {
        Debug.Log("click "+ gameObject.name);
        MovementManager.Instance.playerCharMove = gameObject;
        MovementManager.Instance.highlight_tiles = true;
        MovementManager.Instance.highlight_tiles2move();

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
