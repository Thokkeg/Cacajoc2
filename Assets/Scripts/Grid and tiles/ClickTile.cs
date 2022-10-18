using UnityEngine;

public class ClickTile : MonoBehaviour
{
    private Color prevColor;
    [HideInInspector] // Hides var below
    public bool CharCanMoveToTile;
    
    private void OnMouseEnter()
    {
        if (MovementManager.Instance.highlight_tiles == true)
        {
            prevColor = gameObject.transform.GetComponent<SpriteRenderer>().color;
            gameObject.transform.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    private void OnMouseExit()
    {
        if (MovementManager.Instance.highlight_tiles == true || gameObject.GetComponent<Tile>().isBlocked == true)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().color = prevColor;
        } else
        {
            gameObject.transform.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<Tile>().originalColor;
        }
    }

    private void OnMouseDown()
    {
        if (MovementManager.Instance.playerCharMove != null)
        {
            MovementManager.Instance.tile2move = gameObject;
            MovementManager.Instance.moveCharacter();
        }

    }

    

    public void stop_highlight()
    {
        gameObject.transform.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<Tile>().originalColor;
    }
}
