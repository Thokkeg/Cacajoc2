using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TurnManager : MonoBehaviour
{
    public static TurnManager _instance;
    public static TurnManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }



    public int TurnOrderCalculation = 2;
    public List<GameObject> turnPositions;
    public List<GameObject> allCharacters;


    private void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        setTurns();
        
    }




    public void setTurns()
    {
        var tags = new string[] { "Player", "Enemy" };
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (tags.Contains(go.tag))
                allCharacters.Add(go);
        }

        foreach (GameObject go in allCharacters)
        {
            go.GetComponent<Stats>().calculatedInit = go.GetComponent<Stats>().Init +
                UnityEngine.Random.Range(-go.GetComponent<Stats>().Init, go.GetComponent<Stats>().Init);
            //Debug.Log(go.GetComponent<Stats>().calculatedInit);
        }
        //Debug.Log(allCharacters.Count);
        while (allCharacters.Count != 0)
        {
            GameObject highestInit = allCharacters[0];
            foreach (GameObject go in allCharacters)
            {
                if (go.GetComponent<Stats>().calculatedInit > highestInit.GetComponent<Stats>().calculatedInit)
                {
                    highestInit = go;
                }
            }
            //Debug.Log(allCharacters.Count);
            turnPositions.Add(highestInit);
            allCharacters.Remove(highestInit);
            //Debug.Log(allCharacters.Count);
        }
        //Debug.Log(turnPositions[0].name);
        turnPositions[0].GetComponent<MoveCharacter>().setCharacter2Move();
        Debug.Log("finish set turns");
    }
    public void NextTurn()
    {
        if (turnPositions.Count > 1)
        {
            Debug.Log("NextTurn");
            turnPositions.RemoveAt(0);
            turnPositions[0].GetComponent<MoveCharacter>().setCharacter2Move();
        }
        else
        {
            turnPositions.RemoveAt(0);
            setTurns();
        }
    }
}
