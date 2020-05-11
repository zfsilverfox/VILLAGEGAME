
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanResourceAreaScript : MonoBehaviour
{
 
    [SerializeField] Transform[] transformArea   ;

    [SerializeField] bool isInstanGoldArea = false ;

    [SerializeField] bool isInstanWoodsArea = false;

    List<Transform> transformAreaList = new List<Transform>();




    private void Awake()
    {

        GetComponentFunction();




    }

    //Function : GetComponentFunction
    //Method : This is the Function used For Getting The ComponentFunction 

    void GetComponentFunction() 
    {

        transformArea = GetComponentsInChildren<Transform>();



        for (int i = 0; i < transformArea.Length; i++)
        {
            transformAreaList.Add(transformArea[i]);






        }


        for (int i = 0; i < transformAreaList.Count; i++)
        {


            if(transformAreaList[i] == transform) 
            {
                transformAreaList.Remove(this.transform);

                break;

            }


        }







    }



    //Transform Array : This Transform Array is used To Get The Transform List To Array Function 

    public Transform[] GetTransformListToArrayFunction() 
    {

        return transformAreaList.ToArray();

    }

    public bool GetIsInstanGoldArea() 
    {
        return isInstanGoldArea;
    }

    public bool GetisInstanWoodsArea() 
    {
        return isInstanWoodsArea;
    }




}
