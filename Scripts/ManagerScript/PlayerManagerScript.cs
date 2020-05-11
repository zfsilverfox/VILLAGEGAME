using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{
    public static PlayerManagerScript instance { set; get; }




    public GameObject[] ScoopGameObjects;

    public Transform TempInstanPosition;

    public List<ScoopScript> scoopScriptList = new List<ScoopScript>();



    public int foods = 100;
    public int recoverFruits = 40;
    public int Gold = 60;
    public int Woods = 50;



    public int ScoopIndex = 0;


    int farmerInteger ;
    public int GETFARMERINTEGER 
    {
        get { return farmerInteger; }
        set { farmerInteger = value; }
    }


    int fruitCollectorInteger;
    public int GETFRUITCOLLECTOR 
    {
        get { return fruitCollectorInteger; }
        set { fruitCollectorInteger = value; }
    }

    int axerInteger;
    public int GETAXERInterger 
    {
        get { return axerInteger; }
        set { axerInteger = value; }
    }

    int hammerInteger;
    public int GETHAMMERINTEGER
    {
        get { return hammerInteger; }
        set { hammerInteger = value; }
    }

    public readonly int farmerfoodscost = 15;
    public readonly int fruitCollecterCost = 25;
    public readonly int AxerCost = 30;
    public readonly int HammerCost = 40;

    [SerializeField] Transform InstanTroopTransformSettings;



    private void Awake()
    {

        if (instance == null)
            instance = this;

    }




    private void Start()
    {

        CreateInstantiateObject();



    }

    //Function : CreateInstantiateObject
    //Method : This is the Function used To Create Instantiate Object 
 public   void CreateInstantiateObject()
    {

        if(scoopScriptList.Count <= 20) 
        {
            switch (ScoopIndex)
            {
                //0 Farmer 
                case 0:
                    if (farmerfoodscost > foods)
                        return;

                    break;
                //1 Fruits Collecter 
                case 1:
                    if (fruitCollecterCost > foods)
                        return;
                    break;
                //2 : Axer

                case 2:
                    if (AxerCost > foods)
                        return;

                    break;
                case 3:
                    if (HammerCost > foods)
                        return;

                    break;




            }






            GameObject InstanTroopsObject = Instantiate(ScoopGameObjects[ScoopIndex], TempInstanPosition.position, Quaternion.identity);
            InstanTroopsObject.transform.SetParent(InstanTroopTransformSettings);
            ScoopScript scoopScript = InstanTroopsObject.GetComponent<ScoopScript>();

            scoopScriptList.Add(scoopScript);



            switch (ScoopIndex)
            {
                //0 Farmer 
                case 0:
                    foods -= farmerfoodscost;
                    farmerInteger++;
               

                    break;
                //1 Fruits Collecter 
                case 1:
                    foods -= fruitCollecterCost;
                    fruitCollectorInteger++;


                    break;
                //2 : Axer

                case 2:
                    foods -= AxerCost;
                    axerInteger++;

                    break;
                case 3:
                    foods -= HammerCost;

                    hammerInteger++;


                    break;




            }






        }
        else if(scoopScriptList.Count >= 21) 
        {
            Debug.Log("You Can't Create More Troop");
        }




        UpdateCurrentTheCostAndCountHavePassedFunction();

        UIManager.instance.UpdateCrtResourceTypeFunction(foods, recoverFruits, Woods,Gold); ;



    }

    //Function : UpdateCurrentTheCostAndCountHavePassedFunction

        //Method : This is the Function that used 
            //For Update The Current The Cost And Count Statement 
    public void UpdateCurrentTheCostAndCountHavePassedFunction() 
    {

        UIManager.instance.UpdateTheCurrentNumberHaveFunction
       (farmerInteger ,
        fruitCollectorInteger,
            axerInteger,
            hammerInteger );










        UIManager.instance.UpdateTheCostNumHaveFunction
             (farmerInteger * 3,
                  fruitCollectorInteger * 3,
                    axerInteger * 3,
                     hammerInteger * 3);



    }

}
