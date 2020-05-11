using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObjectScript : MonoBehaviour
{

    public int BuildingIndex;
    public int Cost;
    public string BuldingNameString;
    [SerializeField] float YPos;

    public bool HasToChangeQuatenion = false;


    public bool CanHaveEnergyBar;

    public BuildingEnergyClass buildingEnergyClass;


    public float GetYPos() 
    {
        return YPos;
    }



}

[System.Serializable]
public class BuildingEnergyClass 
{

    public float ReduceRestNeededFruits = 0.25f;






}




