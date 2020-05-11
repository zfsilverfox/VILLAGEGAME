using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GROUNDSScript : MonoBehaviour
{
    public static GROUNDSScript instance { get; private set; }




  public  BuildObjectScript[,] buildObjectScript = new BuildObjectScript[100,100];


    private void Awake()
    {
        if (instance == null)
            instance = this;


    }


    public void ADDBuilding(GameObject buildingsObj, Vector3 position)
    {
        //BuildObjectScript buildtoadd = Instantiate(buildings, position, Quaternion.identity);
        //buildObjectScript[(int)position.x, (int)position.z] = buildtoadd;



        GameObject InstanBuildingObj =
                            Instantiate(buildingsObj, position, Quaternion.identity);


        InstanBuildingObj.transform.SetParent(GameManager.instance.GetBuildingParentTransform());



        BuildObjectScript buildToAdd = InstanBuildingObj.GetComponent<BuildObjectScript>();

        if(PlayerManagerScript.instance.Woods  >= buildToAdd.Cost) 
        {

            buildToAdd.transform.position = new Vector3(position.x, buildToAdd.GetYPos(), position.z);


            GameManager.instance.buildObjectListScript.Add(buildToAdd);




            buildObjectScript[(int)position.x, (int)position.z] = buildToAdd;


            PlayerManagerScript.instance.Woods -= buildToAdd.Cost;


        }
        else if(PlayerManagerScript.instance.Woods 
            < buildToAdd.Cost) 
        {
            Destroy(InstanBuildingObj);
        }


        UIManager.instance.UpdateCrtResourceTypeFunction
            (PlayerManagerScript.instance.foods,
                PlayerManagerScript.instance.fruitCollecterCost,
                    PlayerManagerScript.instance.Woods,
                        PlayerManagerScript.instance.Gold);




    }

    //Function : RemoveBuilding
    //Method : This is the Function used For Remove The Building 

    public void RemoveBuilding(GameObject buildObj,Vector3 position) 
    {
        BuildObjectScript BUILDObjScrict = buildObj.GetComponent<BuildObjectScript>();



  PlayerManagerScript.instance.Woods += (BUILDObjScrict .Cost/4);


        if (GameManager.instance.buildObjectListScript.Contains(BUILDObjScrict)) 
        {
            GameManager.instance.buildObjectListScript.Remove(BUILDObjScrict);

        }


      


        UIManager.instance.UpdateCrtResourceTypeFunction
              (PlayerManagerScript.instance.foods,
                  PlayerManagerScript.instance.fruitCollecterCost,
                      PlayerManagerScript.instance.Woods,
                          PlayerManagerScript.instance.Gold);








        Destroy(buildObj,0.1f);

        buildObjectScript[(int)position.x, (int)position.z] = null;

    }

  



    public BuildObjectScript CheckForBuilding(Vector3 position)
    {

        
            return buildObjectScript[(int)position.x, (int)position.z];
        


      

    }




    public Vector3 CalculatorGridPosition(Vector3 position,float YPos = 0.0f)
    {
        return new Vector3(Mathf.Round(position.x), YPos, Mathf.Round(position.z));
    }


    public BuildObjectScript[,] GetBuildObjectScript() 
    {

     
        
            return buildObjectScript;
       



    }












}
