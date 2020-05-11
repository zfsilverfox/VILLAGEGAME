using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanSoilderAreaScript : MonoBehaviour
{

    


    List<Transform> SoilderListTransformArea = new List<Transform>();

    private void Awake()
    {

        GetComponentFunction();



    }

    //Function : GetComponentFunction
    //Method : This is the Function
    //used For Getting The Component 
    void GetComponentFunction() 
    {
        Transform[] SoilderInstanTransformArea = GetComponentsInChildren<Transform>();

        for (int i = 0; i < SoilderInstanTransformArea.Length; i++)
        {
            SoilderListTransformArea.Add(SoilderInstanTransformArea[i]);
        }


        for (int i = 0; i < SoilderListTransformArea.Count; i++)
        {
            if(SoilderListTransformArea[i] == this.transform) 
            {

                SoilderListTransformArea.Remove(this.transform);
            }





        }


    }



    //Transform Array : GetTransformListToArrayFunction
        //Method : This is the Function that used For Getting The Transform List 
            //To Array Function 
    public Transform[] GetTransformListToArrayFunction() 
    {
        return SoilderListTransformArea.ToArray();
    }






}
