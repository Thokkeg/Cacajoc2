using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTile : MonoBehaviour
{

    private void OnMouseEnter()
    {
        if (MovementManager.Instance.highlight_tiles == true)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    private void OnMouseExit()
    {
        gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    private void OnMouseDown()
    {
        if(MovementManager.Instance.playerCharMove != null)
        {
            MovementManager.Instance.tile2move = gameObject;
        }
        
    }
}
