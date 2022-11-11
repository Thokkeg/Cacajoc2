using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class EnemyEncounterGenerator : MonoBehaviour
{
    private List<Character> allCharacters;
    public string defaultPathCharacters = "Characters";
    public Species[] speciesAvailable;
    public float defaultEncounterValue;
    private float lowestValue =0;
    void Start()
    {
        allCharacters = new List<Character>();

        generateList();
        
        //allCharacters = Resources.LoadAll(path, typeof(Character)).Cast<Character>().ToArray();
        
        //Debug.Log(allCharacters.Length);
        //foreach (Character s in allCharacters)
        //{
        //  Debug.Log(s.name);
        //}
        generateEncounter();
    }
    private void generateList()
    {
        foreach(Species s in speciesAvailable)
        {
            string thisPath = defaultPathCharacters + "/" + s.name;
            Character[] listCharacter = Resources.LoadAll(thisPath, typeof(Character)).Cast<Character>().ToArray();
            foreach(Character c in listCharacter)
            {
                //c.printDefaultInfo();
                allCharacters.Add(c);
                float charCost = c.getCostValue();
                if (lowestValue == 0)
                {
                    lowestValue = charCost;
                }
                else 
                {
                    if(lowestValue > charCost)
                    {
                        lowestValue = charCost;
                    }
                }
            }
        }
        Debug.Log(lowestValue);
    }
    private void generateEncounter()
    {
        List<Character> encounter = new List<Character>();
        float valueEncounter = defaultEncounterValue;
        float loop = 0;
        do
        {
            Character enemy = allCharacters[Random.Range(0, allCharacters.Count)];
            //enemy.printDefaultInfo();
            loop++;
            if (enemy.getCostValue() <= valueEncounter)
            {
                encounter.Add(enemy);
                valueEncounter -= enemy.getCostValue();
                enemy.printDefaultInfo(loop.ToString());
            }
        } while (valueEncounter>=lowestValue);
        printList(encounter);
    }
    private void printList(List<Character> list)
    {
        foreach (Character c in list)
        {
            c.printDefaultInfo();
        }
    }
}
