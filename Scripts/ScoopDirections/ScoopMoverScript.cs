using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopMoverScript : MonoBehaviour
{
   
    public static 
        Vector3[] 
        GetUnitGroupDestinationAroundsResources
        (int units,Vector3 resourcePositions)
    {

        Vector3[] destinations = new Vector3[units];


        float unitDistanceGrap = 360.0f / (float)units;


        for (int x = 0; x < units; x++)
        {
            float angle = unitDistanceGrap * x;

            Vector3 dir = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0.0f,
                Mathf.Cos(angle * Mathf.Deg2Rad));

            destinations[x] = resourcePositions + dir;
        }

        return destinations;

    }







}
