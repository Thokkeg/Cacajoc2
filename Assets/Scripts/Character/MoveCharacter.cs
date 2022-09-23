using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private bool moveMode = false;

    private void OnMouseDown()
    {

        MovementManager.Instance.playerCharMove = gameObject;
        MovementManager.Instance.highlight_tiles = true;


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
