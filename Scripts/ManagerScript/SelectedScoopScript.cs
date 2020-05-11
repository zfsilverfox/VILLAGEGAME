using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;





public class SelectedScoopScript : MonoBehaviour
   

{
    public static SelectedScoopScript instance { get; set; }




    public List<ScoopScript> scoopListScript = new List<ScoopScript>();

    public LayerMask UnitLayerMask;
    public LayerMask AreaLevelBlock;
    public LayerMask UnLockLayerMask;
    public LayerMask GroundLayerMask;
    AskingCubeBoxScript askingCube;

    InstanEnemiesScirpt INSTANENEMIESSCRIPT;
    HaveLevelToUnlockThisGroundScript haveLevelToUnlockThisGroundScript;







    int COST;



    Camera cam;

    private Vector2 StartPos;

   

    private void Awake()
    {
        if (instance == null)
            instance = this;



        cam = Camera.main;


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
                            if (!UIManager.instance.GetCheckCrtLevelStatementFunction().activeInHierarchy)
                            {
                                if (!UIManager.instance.GetPausePanelObjFunction().activeInHierarchy)
                                {
                                    if (PlayerInputScript.
           instance.OnClickLeftMouseBtnDown &&
           !GameManager.instance.HasPressedTheBuildBtn &&
            !GameManager.instance.HasPressTheCreateObjectBtn
        )
                                    {
                                        ToggleSelectedHasToBeenFailed(false);
                                        SETBubbleObjectActiveFunction(false);

                                        if (!UIManager.instance.HasEnterTheBtnBoolean)
                                            scoopListScript = new List<ScoopScript>();

                                        StartPos = Input.mousePosition;
                                        MouseBtnDownSelectedFunction(Input.mousePosition);

                                    }


                                    if (PlayerInputScript.instance.OnClickLeftMouseBtn &&
                                            !GameManager.instance.HasPressedTheBuildBtn &&
                                              !GameManager.instance.HasPressTheCreateObjectBtn
                                        )
                                    {

                                        UpdateSelectedMouseBtnFunction(Input.mousePosition);



                                    }

                                    if (PlayerInputScript.instance.OnClickLeftMouseBtnUP &&
                                        !GameManager.instance.HasPressedTheBuildBtn &&
                                          !GameManager.instance.HasPressTheCreateObjectBtn
                                       )
                                    {

                                        ReleaseTheMouseBtnFunction(Input.mousePosition);



                                    }


                                    if (PlayerInputScript.instance.OnClickLeftMouseBtnDown
                                        && GameManager.instance.HasPressedTheBuildBtn)

                                    {
                                        CreateBuildingFunction();

                                    }








                                }










                            }







                        }








                    }





                }









            }




        }


    }


    //Function : MouseBtnDownSelectedFunction
   //Method : This is the Function used To Selected The Function Statement 
    void MouseBtnDownSelectedFunction(Vector2 screenPosition) 
    {

        Ray ray = cam.ScreenPointToRay(screenPosition);

        RaycastHit rayCastHit;

        if(Physics.Raycast(ray,
            out rayCastHit, 
            Mathf.Infinity, 
            UnitLayerMask)) 
        {
            scoopListScript.Clear();

            ScoopScript scoopscriptWithCollider = rayCastHit.collider.GetComponent<ScoopScript>();





            if (PlayerManagerScript.instance.scoopScriptList.Contains(scoopscriptWithCollider)) 
            {

                    if(scoopscriptWithCollider != null) 
                        {
                            scoopListScript.Add(scoopscriptWithCollider);
                            scoopscriptWithCollider.GetHasBeenSelectorObject().SetActive(true);
                            //      scoopscriptWithCollider.GETSCOOPUICRTSTATEMENT().gameObject.SetActive(true);

                            SETBubbleObjectActiveFunction(true);

                        }



            }



       







        }

else    if (Physics.Raycast(ray,out rayCastHit,Mathf.Infinity,AreaLevelBlock)) 
        {










            if (rayCastHit.collider.gameObject.CompareTag(TagsObjectScript.CantCreateBuildingObjTagsName)) 
            {



                if (!UIManager.instance.HasEnterTheBtnBoolean)
                {
              

                    if (!UIManager.instance.GetUNLockPanelObject().activeInHierarchy) 
                    {
                        if (!UIManager.instance.GetRequireLevelPanelFunction().activeInHierarchy) 
                        {

                            InstanEnemiesScirpt instanEnemiesScript = rayCastHit.collider.GetComponent<InstanEnemiesScirpt>();







                            SetInstanEnemyFunction(instanEnemiesScript);

                            if (instanEnemiesScript != null)
                            {

                                if (instanEnemiesScript.Unlocked)
                                {
                                    if (PlayerManagerScript.instance.Gold >= instanEnemiesScript.GoldenCost)
                                    {
                                        UIManager.instance.GetYesButtonFunction().interactable = true;
                                        UIManager.instance.GetNoButtonFunction().interactable = true;


                                    }
                                    else if (PlayerManagerScript.instance.Gold < instanEnemiesScript.GoldenCost)
                                    {
                                        UIManager.instance.GetYesButtonFunction().interactable = false;
                                        UIManager.instance.GetNoButtonFunction().interactable = true;

                                    }

                                    UIManager.instance.GetUNLockPanelObject().SetActive(true);

                                    SetCostFunction(instanEnemiesScript.GoldenCost);
                                }
                                else
                                {
                                    UIManager.instance.GetUNLockPanelObject().SetActive(false);
                                }

                                //  SetAskingCubeObject(rayCastHit.collider.GetComponent<AskingCubeBoxScript>());





                            }




                        }

                    }

                    

                        if (!UIManager.instance.GetRequireLevelPanelFunction().activeInHierarchy)
                        {


                            SetHaveLevelToUnlockThisGround(rayCastHit.collider.gameObject.GetComponent<HaveLevelToUnlockThisGroundScript>());

                       //     Debug.Log(haveLevelToUnlockThisGroundScript);



                            if (haveLevelToUnlockThisGroundScript != null)
                            {




                                //               Debug.Log("Has Pressed The Has Level To Unlock ");


                          //      Debug.Log("You Have Click The To Unlock Level");





                                if (haveLevelToUnlockThisGroundScript.isUnlock)
                                {

                                if (PlayerManagerScript.instance.Gold >= haveLevelToUnlockThisGroundScript.Cost)
                                {
                                    UIManager.instance.GetYesButtonFunction().interactable = true;
                                    UIManager.instance.GetNoButtonFunction().interactable = true;


                                }
                                else if (PlayerManagerScript.instance.Gold < haveLevelToUnlockThisGroundScript.Cost)
                                {
                                    UIManager.instance.GetYesButtonFunction().interactable = false;
                                    UIManager.instance.GetNoButtonFunction().interactable = true;

                                }

SetCostFunction(haveLevelToUnlockThisGroundScript.Cost);


                                UIManager.instance.GetUNLockPanelObject().SetActive(true);
                                    

                                }
                                else
                                {
                                    UIManager.instance.GetRequireLevelPanelFunction().SetActive(true);
                                    UIManager.instance.SetRequiredLevelTextFunction(haveLevelToUnlockThisGroundScript.GetTheUnlockRequipmentTextFunction());
                                UIManager.instance.SetHaveUnlockLevelTextFunction(haveLevelToUnlockThisGroundScript.GetTheHaveUnlockRequipmentTextFunction());

                                }

                            }


                    }

                }




            }




        }
      



    }

    //Function : UpdateSelectodMouseBtnFunction(Vector2 screenPosition)
    //Method : This is the Function that used 
    //For Update Selected Mouse Btn Function
    void UpdateSelectedMouseBtnFunction(Vector2 screenPosition) 
    {
        if (!UIManager.instance.GetSelectedRectTransformObject().gameObject.activeInHierarchy) 
        {
            UIManager.instance.GetSelectedRectTransformObject().gameObject.SetActive(true);
        }

        float width = screenPosition.x - StartPos.x;
        float height = screenPosition.y - StartPos.y;


        UIManager.instance.GetSelectedRectTransformObject().sizeDelta = 
            new Vector2(
                Mathf.Abs(  width),
                    Mathf.Abs(height));
        UIManager.instance.GetSelectedRectTransformObject().anchoredPosition = 
          StartPos+  new Vector2(width/2,height/2);
            

    }


    //Function : ReleaseTheMouseBtnFunction
    //Method : This is the Function that used For
    //Release The Mouse Btn Function
    void ReleaseTheMouseBtnFunction(Vector2 screenPosition) 
    {
        UIManager.instance.GetSelectedRectTransformObject().gameObject.SetActive(false);

        Vector2 minValue = UIManager.instance.GetSelectedRectTransformObject().anchoredPosition - 
            (UIManager.instance.GetSelectedRectTransformObject().sizeDelta / 2);

        Vector2 maxValue = UIManager.instance.GetSelectedRectTransformObject().anchoredPosition
            + (UIManager.instance.GetSelectedRectTransformObject().sizeDelta / 2);


        foreach (ScoopScript scoop in PlayerManagerScript.instance.scoopScriptList) 
        {
            if (scoop != null) 
            {

  Vector3 screenPos = cam.WorldToScreenPoint(scoop.transform.position);

            if (screenPos.x > minValue.x
                && screenPos.x < maxValue.x
                && screenPos.y > minValue.y
                && screenPos.y < maxValue.y)
            {

                if (PlayerManagerScript.instance.scoopScriptList.Contains(scoop)) 
                {

                    scoopListScript.Add(scoop);
                    scoop.GetHasBeenSelectorObject().SetActive(true);
                    SETBubbleObjectActiveFunction(true);
                }
                else 
                {
                    Debug.Log("DON'T ADD ");
                }



              

            }



            }
          

        }




    }

    //Function : CreateBuildingFunction


    void CreateBuildingFunction() 
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if(Physics.Raycast(ray,out hit,Mathf.Infinity,GroundLayerMask)) 
        {
            if (GROUNDSScript.instance.CheckForBuilding(hit.point)== null)
            {

                if (!hit.collider.CompareTag(TagsObjectScript.PlayerTagsName)) 
                {

                    if (! hit.collider.CompareTag(TagsObjectScript.COLLECTIVETagsName)) 
                    {
                        if (!hit.collider.CompareTag(TagsObjectScript.CantCreateBuildingObjTagsName)) 
                        {
                            Vector3 gridPosition =GROUNDSScript.instance.CalculatorGridPosition(hit.point);



                            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                            {

                          //      Debug.Log("You Can Build Building Here ");

                                GROUNDSScript.instance.ADDBuilding(
                                    GameManager.instance.GETBULDINGOBJECTFunction()[
                                        GameManager.instance.BuildingIndex],
                                            gridPosition);

                            }
                        }
                        else 
                        {
                            Debug.Log("You Can't Create Building In This Area ");
                        }

                      








                    }

               

                   




                }



               
            }




        }



    }

    //Function : SETBubbleObjectActiveFunction
    void SETBubbleObjectActiveFunction(bool active = false) 
    {
        for (int i = 0; i < scoopListScript.Count; i++)
        {
            if (scoopListScript[i].GETSCOOPUICRTSTATEMENT() != null) 
            {
                scoopListScript[i].GETSCOOPUICRTSTATEMENT().GetEmotionBubbleGameObject().gameObject.SetActive(active);
            }
          
        }

    }

    void ToggleSelectedHasToBeenFailed(bool selectedBoolean) 
    {

        foreach(ScoopScript scoop in scoopListScript) 
        {
            scoop.GetHasBeenSelectorObject().SetActive(selectedBoolean);



        }



    }

    
    public bool HasSelectedTroops() 
    {
        return scoopListScript.Count > 0;
    }

    //
    public ScoopScript[] GetScoopScriptArray() 
    {
        return scoopListScript.ToArray();
    }

    public void SetAskingCubeObject(AskingCubeBoxScript ask = null) 
    {
        askingCube = ask;
    }

    public AskingCubeBoxScript GetAskingCube() 
    {
        return askingCube;
    }

    public void SetCostFunction(int cost ) 
    {
        UIManager.instance.GetGoldenCostTextFunction().text =  "Golden Has To Cost :" +cost.ToString();
    }

   public int GetCostFunction() 
    {
        return COST;
    }


    //Function : SetInstanEnemyFunction
        //Method : This is the Function used For Setting The InstanEnemy Function 
    public void SetInstanEnemyFunction(InstanEnemiesScirpt instan = null) 
    {
        INSTANENEMIESSCRIPT = instan;
    }

    public void SetHaveLevelToUnlockThisGround(HaveLevelToUnlockThisGroundScript haveLeveltoUnlockThisLevel = null) 
    {
        this.haveLevelToUnlockThisGroundScript = haveLeveltoUnlockThisLevel;
    }


    public InstanEnemiesScirpt GetInstanEnemiesScript() 
    {
        return INSTANENEMIESSCRIPT;
    }

 








}


