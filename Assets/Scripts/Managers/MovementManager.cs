using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public static MovementManager _instance;
    public static MovementManager Instance { get { return _instance; } }

    public bool highlight_tiles = false;
    public GameObject playerCharMove;
    public GameObject tile2move;

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
    }
    void moveCharacter()
    {
        playerCharMove.transform.position = tile2move.transform.position;
        playerCharMove = null;
        tile2move = null;
        highlight_tiles = false;
    }


    void Update()
    {
        
    }
}
