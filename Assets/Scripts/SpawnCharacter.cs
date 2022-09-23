using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    public int positionX;
    public int positionY;
    public GameObject character;

    void Start()
    {
        Instantiate(character, GameObject.Find("x:" + positionX + " " + "y:" + positionY).transform.position, Quaternion.identity);

    }

    void Update()
    {
        
    }
}