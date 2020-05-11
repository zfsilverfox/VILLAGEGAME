
using System;
using UnityEngine;

public enum ScoopEnumType 
{
    Farmer, 
    Gathering,
    Hammer,
    Axe,
   






}


[System.Serializable]

    public class EnergyType 
    {
       // public ScoopEnumType scoopEnumType;
       [Header("CollectingTiming")]
        public float farmerCollectTiming;
        public float gatheringCollectTiming;
        public float hammerCollectTiming;
    public float axeCollectTiming;
    [Header("Energy")]
    public float farmerEnergy;
    public float gatheringEnergy;
    public float hammerEnergy;
    public float axeEnergy;
        public float fighterEnergy;





    [Header("HP Statement ")]
        public float CrtHP;
        public float MaxHP;

    [Header("Spirit")]
        public float CrtSpirit;
        public float MaxSpirit;


    }

   


















