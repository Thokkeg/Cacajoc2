using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data", menuName ="ScriptableObjects/Character", order =1)]
public class Character : ScriptableObject
{
    private string baseName;
    public Ente basicEnte;
    public Class charClass;
    public Species charSpecies;
    public float valueBalance;

    public float[] calculateBaseValues(float level)
    {
        float baseHp = (basicEnte.HP + charClass.HP + charSpecies.HP)*((level>0)?1+(level)/100f:1f);
        float baseDef = (basicEnte.Def + charClass.Def + charSpecies.Def) * ((level > 0) ? 1 + (level) / 100f : 1f);
        float baseAtt = (basicEnte.Att + charClass.Att + charSpecies.Att) * ((level > 0) ? 1 + (level) / 100f : 1f);
        float baseMov = (basicEnte.Mov + charClass.Mov + charSpecies.Mov) * ((level > 0) ? 1 + (level) / 100f : 1f);
        float baseInit = (basicEnte.Init + charClass.Init + charSpecies.Init) * ((level > 0) ? 1 + (level) / 100f : 1f);

        float[] baseValues = { baseHp, baseDef, baseAtt, baseMov, baseInit};
        return baseValues;
    }
    public string getBaseName()
    {
        return ((charSpecies.name.ToLower().Equals("default") || charSpecies.name.ToLower().Equals("especial")) ? "":charSpecies.name) + " " + ((charClass.name.ToLower().Equals("default") || charClass.name.ToLower().Equals("especial")) ? "" : charClass.name);
    }
    public float getCostValue()
    {
        float finalCost = basicEnte.Value + charClass.Value + charSpecies.Value;
        return finalCost;
    }
    public void printDefaultInfo(string extra ="")
    {
        float[] baseValues = calculateBaseValues(0);
        string toPrintText = "<color=red>Name:</color> " + getBaseName() +
            ", <color=red>HP:</color> " + baseValues[0] +
            ", <color=red>DEF:</color> " + baseValues[1] +
            ", <color=red>ATT:</color> " + baseValues[2] +
            ", <color=red>MOV:</color> " + baseValues[3] +
            ", <color=red>INIT:</color> " + baseValues[4] +
            ", <color=red>RANGE:</color> " + charClass.range +
            ", <color=red>VALUE:</color> " + getCostValue();
        if (!extra.Equals(""))
        {
            toPrintText += ", <color=red>EXTRA:</color> " + extra;
        }
        Debug.Log(toPrintText);
    }
}
