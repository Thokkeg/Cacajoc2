using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    public int positionX;
    public int positionY;
    public GameObject character;

    void Start()
    {
        GameObject MyCharacter = Instantiate(character, GameObject.Find("x:" + positionX + " " + "y:" + positionY).transform.position, Quaternion.identity);
        MyCharacter.GetComponent<MoveCharacter>().tile = GameObject.Find("x:" + positionX + " " + "y:" + positionY).GetComponent<Tile>();
        MyCharacter.transform.parent = GameObject.Find("Characters").transform;

    }

    void Update()
    {

    }
}