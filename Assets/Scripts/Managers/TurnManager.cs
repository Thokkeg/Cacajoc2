using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TurnManager : MonoBehaviour
{
    public int TurnOrderCalculation = 2;
    private List<GameObject> turnPositions;
    public List<GameObject> allCharacters;

    public void setTurns()
    {
        var tags = new string[] { "targetTag", "targetTag1" };
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (tags.Contains(go.tag))
                allCharacters.Add(go);
        }

        foreach (GameObject go in allCharacters)
        {
            go.GetComponent<Stats>().calculatedInit = go.GetComponent<Stats>().Init + 
                UnityEngine.Random.Range(-go.GetComponent<Stats>().Init, go.GetComponent<Stats>().Init);
            Debug.Log(go.GetComponent<Stats>().calculatedInit);
        }
        while (allCharacters.Count != 0)
        {
            GameObject highestInit = allCharacters[0];
            foreach (GameObject go in allCharacters)
            {
                if(go.GetComponent<Stats>().calculatedInit > highestInit.GetComponent<Stats>().calculatedInit)
                {
                    highestInit = go;
                }
            }
            turnPositions.Add(highestInit);
            allCharacters.Remove(highestInit);
        }

    }
}
