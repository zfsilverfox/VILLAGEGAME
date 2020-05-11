using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopCommanderManager : MonoBehaviour
{

    public GameObject MovingPositionObject;



    SelectedScoopScript selectScoopScript;

    public LayerMask MixedLayerMask;

    public LayerMask ResourceCollectiveLayerMask;

    Camera cam;


    private void Awake()
    {
        GetComponentFunction();


    }

    //Function : GetComponentFunction
    //Method : This is the Function that used 
    //For Getting The Component 
    void GetComponentFunction() 
    {

        cam = Camera.main;


        selectScoopScript = GetComponent<SelectedScoopScript>();


    }



    private void Update()
    {
        if (!UIManager.instance.GetGameClearPanelObject().activeInHierarchy)
        {
            if (!UIManager.instance.GetUNLockPanelObject().activeInHierarchy)
            {

                if (!UIManager.instance.GetWorkerPanelObjFunction().activeInHierarchy)
                {
                    if (!UIManager.instance.GetRequireLevelPanelFunction().activeInHierarchy)
                    {
                        if (!UIManager.instance.GetClearLvl1To10PanelObject().activeInHierarchy)
                        {
                            if (!UIManager.instance.GetPausePanelObjFunction().activeInHierarchy)
                            {

                                if (!GameManager.instance.HasPressedTheBuildBtn)
                                {
                                    if (PlayerInputScript.instance.OnClickRightBtnDown)
                                    {

                                        PlayerDoMovingFunction(Input.mousePosition);





                                    }

                                }

                                else
                                {
                                    if (PlayerInputScript.instance.OnClickRightBtnDown)
                                    {

                                        //  PlayerDoMovingFunction(Input.mousePosition);
                                        //   Debug.Log("This is used For Delete The Building Statement");
                                        RemoveBuildingFunction(Input.mousePosition);


                                    }



                                }



                            }












                        }
                    }
                }
            }








        }







    }

    //Function : PlayerDoMovingFunction
    //Method : This is the Function that used 
    //For Do Moving Statement
    void PlayerDoMovingFunction(Vector2 MovingPosition) 
    {
        Ray ray = Camera.main.ScreenPointToRay(MovingPosition);

        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,Mathf.Infinity,MixedLayerMask))
        {

            if (selectScoopScript.HasSelectedTroops()) 
            {
               if (hit.collider.CompareTag(TagsObjectScript.GROUNDSTagsName)) 
                        {

                 


                    MovingToTheDestination(selectScoopScript.GetScoopScriptArray(),hit.point);



                        }
               else if (hit.collider.CompareTag(TagsObjectScript.COLLECTIVETagsName)) 
                {

        
                            MovingToTheResourceDestination
                                (selectScoopScript.GetScoopScriptArray(),
                                hit.point,
                                SCOOPENUMCrtStatement.MovToFarming,
                                hit.collider.GetComponent<ResourceCollectiveScript>());


                }
               else if (hit.collider.CompareTag(TagsObjectScript.ENEMIESSOILDERTagsName)) 
                {

                //    Debug.Log("ENEMY HAS BEEN HITTEN");


                    MovingToTheSoilderFunction(selectScoopScript.GetScoopScriptArray(),
                                                    hit.collider.gameObject.GetComponent<AISOILDERCtrlScript>() ,
                                                        hit.point);
                 //   MovToTalkingStatementFunction(selectScoopScript.GetScoopScriptArray(), hit.point);
                }




            }

        }

    }

    //Function : RemoveBuildingFunction 

    void RemoveBuildingFunction(Vector2 position) 
    {
        Ray ray = cam.ScreenPointToRay(position);

        RaycastHit hit;


        if(Physics.Raycast(ray,out hit,Mathf.Infinity, ResourceCollectiveLayerMask)) 
        {
            Vector3 gridPosition = GROUNDSScript.instance.CalculatorGridPosition(hit.point);
            if (GROUNDSScript.instance.CheckForBuilding(hit.point)!= null)
            {

                GROUNDSScript.instance.RemoveBuilding(hit.collider.gameObject, gridPosition);




                Debug.Log("Remove The Building From The Right Mouse Button");
            }


        }




    }




    //Function : MovingToTheDestination
    //Method : This is the Function used For Setting Moving To 
    //The Destination Function 
    void MovingToTheDestination(ScoopScript[] SC,Vector3 targetPos) 
    {

        for (int i = 0; i < SC.Length; i++)
        {
            SC[i].MovToPositionFunction(targetPos);
        }





    }


    void MovingToTheResourceDestination(ScoopScript[]SC,Vector3 targetPos,SCOOPENUMCrtStatement PlayerCrtenumStatement
        ,ResourceCollectiveScript rs = null) 
    {
   Vector3[] Behindpos = ScoopMoverScript.GetUnitGroupDestinationAroundsResources(SC.Length, targetPos);
      
        for (int i = 0; i < SC.Length; i++)
        {
         
            if (SC[i].energyType.CrtSpirit > 0) 
            {
                for(int j = 0; j < Behindpos.Length; j++) 
                {
     
                    SC[i].MovToResourceFunction(Behindpos[j], PlayerCrtenumStatement,rs);
                
                }



               

            }

        }

    }


    void MovingToTheSoilderFunction(ScoopScript[] SC,AISOILDERCtrlScript aiCtrlScript,Vector3 targetPos) 
    {
        for (int i = 0; i < SC.Length; i++)
        {

            if (SC[i].energyType.CrtSpirit > 0)
            {


                SC[i].MovToEnemySoilderFunction(targetPos,aiCtrlScript);

              





            }

        }
    }

}
