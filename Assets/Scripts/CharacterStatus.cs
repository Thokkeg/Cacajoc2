using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public Character character;
    private float actualHP;
    private float actualDef;
    private float actualAtt;
    private float actualMov;
    private float actualInit;
    private int actualRange;
    public float level = 0;
    void Start()
    {
        float[] baseValues = character.calculateBaseValues(level);
        actualHP = baseValues[0];
        actualDef = baseValues[1];
        actualAtt = baseValues[2];
        actualMov = baseValues[3];
        actualInit = baseValues[4];
        actualRange = character.charClass.range;
        printInfo();
    }

    void Update()
    {
               
    }
    void printInfo()
    {
        Debug.Log(
            "<color=red>Name:</color> " + character.getBaseName() +
            ", <color=red>HP:</color> " + actualHP +
            ", <color=red>DEF:</color> " + actualDef +
            ", <color=red>ATT:</color> " + actualAtt +
            ", <color=red>MOV:</color> " + actualMov +
            ", <color=red>INIT:</color> " + actualInit +
            ", <color=red>RANGE:</color> " + actualRange
            );
    }
}
