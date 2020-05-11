using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
 
    public static UIManager instance { get; set; }

    [SerializeField] RectTransform SelectedTransformObject;


    [SerializeField] Text CrtFoodHaveText,CrtFruitHaveText,CrtWoodsHaveText,CrtGoldenHaveText;



    public GameObject SelectedBtnObject, CreateTroopPanelObjects;

    public GameObject BuildBtnObjects;

    public GameObject BuildingPanelObject;



    public Button ClosePanelObjectBtn;




    public Text FarmerCost, CollecterCost, WooderCost, GoldenCost;

    [HideInInspector]
    public bool HasEnterTheBtnBoolean = false;

    [SerializeField] Text DayText;

    [SerializeField] GameObject InstanBuildingBtnObject;
    
    [SerializeField] Transform BuldingUITransform;

    [SerializeField] Scrollbar scrollBarVertical;

    [SerializeField] Text UICurrentHaveOverall, UICurrentHaveFamer, UICurrentHaveFruitCollector, UICurrentHaveAxer, UICurrentHaveHammer;

    [SerializeField] Text UIFoodsCostOverall, UIFoodsCostFarmer, UIFoodsCostFruitCollector, UIFoodsCostAxer, UIFoodsCostHammer;

    [SerializeField] GameObject WorkerPanelObjects;

    [SerializeField] GameObject DoYouWantToUnlockThisAreaPanel;

    [SerializeField] Button YesButton, NoButton;

    [SerializeField] Text UICostGoldenText;

    [SerializeField] GameObject RequiredPanelObjects ;

    [SerializeField] Text RequiredLevetText;

    [SerializeField] Text HaveUnlockLevelText;

    bool hasUnlockToFromLevel1To10 = false;

    [SerializeField] GameObject ClearLevel1To10PanelObj;

    [SerializeField] GameObject CheckCrtLvlStatementObjects ;




    [SerializeField] GameObject GameClearPanelObj;


  
    [SerializeField] Image Lvl1Image, Lvl2Image, Lvl3Image, Lvl4Image, Lvl5Image, Lvl6Image, Lvl7Image, Lvl8Image, Lvl9Image, Lvl10Image ;

    [SerializeField] Image Lvl11Image,Lvl12Image,Lvl13Image, Lvl14Image, Lvl15Image, Lvl16Image, Lvl17Image, Lvl18Image, Lvl19Image ;



    [SerializeField] Sprite HaveClearSprite, HavenClearSprite;

    [SerializeField] GameObject PauseBtnObj;


    [SerializeField] GameObject PausePanelObj;

    [SerializeField] GameObject NowLoadingPanelObj;

    [SerializeField] Image CrtNowLoadingSpriteImage;

    [SerializeField] GameObject InBuildHireModeTextObj;
    [SerializeField] Text InBuildHireModeText;


    private void Awake()
    {
        if (instance == null)
                    instance = this;

        for (int i = 0; i < GameManager.instance.GETBULDINGOBJECTFunction().Length; i++)
        {

      //      Debug.Log("Building Button Game Object Has Been Called");
            GameObject BuildingBTNGameOBJ = Instantiate(InstanBuildingBtnObject,transform.position,Quaternion.identity);


     
            BuildingBTNGameOBJ.transform.SetParent(BuldingUITransform);

            BuildUIBtnScript buildUiBtn = BuildingBTNGameOBJ.GetComponent<BuildUIBtnScript>();
            BuildObjectScript buildObjectScript = GameManager.instance.GETBULDINGOBJECTFunction()[i].GetComponent<BuildObjectScript>();

         buildUiBtn.SetBuildingNameText(buildObjectScript.BuldingNameString);

            buildUiBtn.SetCrtNumberIndex(i);

            buildUiBtn.SetCostTextFunction(buildObjectScript.Cost);



        }





    }

    private void Start()
    {
        UpdateCrtResourceTypeFunction
            (PlayerManagerScript.instance.foods,
                    PlayerManagerScript.instance.recoverFruits,
                        PlayerManagerScript.instance.Woods,
                            PlayerManagerScript.instance.Gold);


        SettingBasicInformationFunction();
    }

    //Function : ADDListenerFunction
    //Method : This is the Function that used to ADD Listener Statement
    void ADDListenerFunction() 
    {
        SelectedBtnObject.GetComponent<Button>().onClick.AddListener(ScoopSelectedBtnFunction);

        ClosePanelObjectBtn.onClick.AddListener(CloseTroopPanelObjectFunction);

    }

    //Function : SettingBasicInformationFunction
    //Method : This is the Function used For 
    //Setting Basic Information Statement

    void SettingBasicInformationFunction() 
    {
        FarmerCost.text = PlayerManagerScript.instance.farmerfoodscost.ToString();
        CollecterCost.text = PlayerManagerScript.instance.fruitCollecterCost.ToString();
        WooderCost.text = PlayerManagerScript.instance.AxerCost.ToString();
        GoldenCost.text = PlayerManagerScript.instance.HammerCost.ToString();


        DayText.text ="DAYS :"+ GameManager.instance.DayInteger.ToString();

    }

    public RectTransform GetSelectedRectTransformObject() 
    {

        if (SelectedTransformObject != null) 
        {
            return SelectedTransformObject;
        }


        return null;
    }


    private void LateUpdate()
    {
        
        if(scrollBarVertical != null) 
        {
            scrollBarVertical.size = 0.08f;
        }




    }

    //Function : UpdateCrtResourceTypeFunction
    //Method : This is the Function that used For Update CrtResource Type 
    public void UpdateCrtResourceTypeFunction
        (int CrtFoodintegerAmount,
                int CrtFruitsintegerAmount,
                    int CrtWoodsintegerAmount,
                        int CrtGoldenIntergerAmount) 
    {
        CrtFoodHaveText.text = "FOODS :"+CrtFoodintegerAmount.ToString() ;
        CrtFruitHaveText.text = "FRUITS :" +CrtFruitsintegerAmount.ToString();
        CrtWoodsHaveText.text = "WOODS :" + CrtWoodsintegerAmount.ToString();
        CrtGoldenHaveText.text = "GOLDEN :" + CrtGoldenIntergerAmount.ToString();

    }


    //Function: ScoopSelectedBtnFunction
    //Method : This is the Function that used 
    //For Selecred The Scoop Selected Btn Function

   void ScoopSelectedBtnFunction() 
    {
        SelectedBtnObject.SetActive(false);

        BuildBtnObjects.SetActive(false);

        CreateTroopPanelObjects.SetActive(true);

        InBuildHireModeTextObj.SetActive(true);
        InBuildHireModeText.text = "In Hire Mode";



        GameManager.instance.HasPressTheCreateObjectBtn = true;

    }



public  void CloseTroopPanelObjectFunction() 
    {
       
        SelectedBtnObject.SetActive(true);

        BuildBtnObjects.SetActive(true);

        CreateTroopPanelObjects.SetActive(false);

        InBuildHireModeTextObj.SetActive(false);

        GameManager.instance.HasPressTheCreateObjectBtn = false;

    }



    public void CREATETroop(int createtroopindex) 
    {
        PlayerManagerScript.instance.ScoopIndex = createtroopindex;

        PlayerManagerScript.instance.CreateInstantiateObject();



    }

  

    //Function : DAYPassedBtnFunction
    //Method : This is the Function that used For Day Passed Btn Function 
    public void DayPassedBtnFunction() 
    {
        if(GameManager.instance!= null) 
        {
            GameManager.instance.DayInteger++;


            DayText.text = "DAYS :" + GameManager.instance.DayInteger.ToString();


        }

        GameManager.instance.InstantiateSoilderFunction();




        PlayerManagerScript.instance.UpdateCurrentTheCostAndCountHavePassedFunction();



        PlayerManagerScript.instance.foods -= (3 *PlayerManagerScript.instance.scoopScriptList.Count);

        if(PlayerManagerScript.instance.foods <= 3 * PlayerManagerScript.instance.scoopScriptList.Count) 
        {
            int count = Random.Range(0, PlayerManagerScript.instance.scoopScriptList.Count);
            ScoopScript containScript = PlayerManagerScript.instance.scoopScriptList[count];

            if (PlayerManagerScript.instance.scoopScriptList.Contains(containScript)) 
            {
                switch (containScript.scoopEnumType)
                {
                    case ScoopEnumType.Farmer:
                        PlayerManagerScript.instance.GETFARMERINTEGER--;

                        break;
                    case ScoopEnumType.Gathering:
                        
                        PlayerManagerScript.instance.GETFRUITCOLLECTOR--;

                        break;

                    case ScoopEnumType.Axe:
                        
                        PlayerManagerScript.instance.GETAXERInterger--;

                        break;
                    case ScoopEnumType.Hammer:
                        PlayerManagerScript.instance.GETHAMMERINTEGER--;

                        break;



                }

                Destroy(containScript.gameObject);
                PlayerManagerScript.instance.scoopScriptList.Remove(containScript);

            }


        }


        if (PlayerManagerScript.instance.foods <= 0) 
        {
            PlayerManagerScript.instance.foods = 0;
        }

     //   CameraCtrl.instance.transform.position= CameraCtrl.instance.GETDefaultPositionFunction().position;


        for (int i = 0; i < PlayerManagerScript.instance.scoopScriptList.Count; i++)
        {
            PlayerManagerScript.instance.scoopScriptList[i].SettingStatement(SCOOPENUMCrtStatement.IDLE);

            PlayerManagerScript.instance.scoopScriptList[i].GetAnimatorFunction().SetBool
                (PlayerManagerScript.instance.scoopScriptList[i].GetTiringStringFunction()
                ,false);
            
            PlayerManagerScript.instance.scoopScriptList[i].GetAnimatorFunction().SetBool
                (PlayerManagerScript.instance.scoopScriptList[i].GetisTalkingStringFunction(), false);

            PlayerManagerScript.instance.scoopScriptList[i].GetAnimatorFunction().SetBool
               (PlayerManagerScript.instance.scoopScriptList[i].GetEquipWeaponStringFunction(), false);



            PlayerManagerScript.instance.scoopScriptList[i].SetTalkingBooleanStatement(false);
            PlayerManagerScript.instance.scoopScriptList[i].movingToTalkingCrtStatement = 0.0f;
            PlayerManagerScript.instance.scoopScriptList[i].movingToTalkingMaxStatement =15;

            PlayerManagerScript.instance.scoopScriptList[i].SetEnemySoilderFunctionToNULLFunction();



            UpdateCrtResourceTypeFunction
                (PlayerManagerScript.instance.foods,PlayerManagerScript.instance.recoverFruits,
                PlayerManagerScript.instance.Woods,PlayerManagerScript.instance.Gold);


            if (PlayerManagerScript.instance.recoverFruits > 0) 
            {
                BuildObjectScript[] buildObjectScript = FindObjectsOfType<BuildObjectScript>(); 







                if (PlayerManagerScript.instance.scoopScriptList[i].energyType.CrtSpirit <
                   PlayerManagerScript.instance.scoopScriptList[i].energyType.MaxSpirit)
                {
                    PlayerManagerScript.instance.scoopScriptList[i].energyType.CrtSpirit +=
                            (PlayerManagerScript.instance.recoverFruits * 0.25f)
                            + 2
                            ;



                    if(buildObjectScript != null) 
                    {

                            for (int j = 0; j < buildObjectScript.Length; j++)
                            {
                                if (buildObjectScript[j].CanHaveEnergyBar) 
                                {

                              Debug.Log("has Been Instan Before ");
                                PlayerManagerScript.instance.recoverFruits -= 10/ (int)buildObjectScript[j].buildingEnergyClass.ReduceRestNeededFruits;
                                break;
                                }
                                else 
                                {
                                        PlayerManagerScript.instance.recoverFruits -= 10;
                                    break;
                                }

                            }

                    }

                    

                    if(PlayerManagerScript.instance.recoverFruits <= 0)
                    {
                        PlayerManagerScript.instance.recoverFruits = 0;
                    }



                }
             
                
                
                
                if(PlayerManagerScript.instance.scoopScriptList[i].energyType.CrtSpirit >=
                    PlayerManagerScript.instance.scoopScriptList[i].energyType.MaxSpirit) 
                {
                    PlayerManagerScript.instance.scoopScriptList[i].energyType.CrtSpirit =
                        PlayerManagerScript.instance.scoopScriptList[i].energyType.MaxSpirit;

                }




            }
            else if(PlayerManagerScript.instance. recoverFruits <= 0) 
            {
                if (PlayerManagerScript.instance.scoopScriptList[i].energyType.CrtSpirit <
              PlayerManagerScript.instance.scoopScriptList[i].energyType.MaxSpirit)
                {
                    PlayerManagerScript.instance.scoopScriptList[i].energyType.CrtSpirit +=
                           1
                            ;
              


                }
                else if (PlayerManagerScript.instance.scoopScriptList[i].energyType.CrtSpirit >=
                    PlayerManagerScript.instance.scoopScriptList[i].energyType.MaxSpirit)
                {
                    PlayerManagerScript.instance.scoopScriptList[i].energyType.CrtSpirit =
                        PlayerManagerScript.instance.scoopScriptList[i].energyType.MaxSpirit;

                }




            }

        }

        AskingCubeBoxScript[] askingCubeBoxScript = FindObjectsOfType<AskingCubeBoxScript>();

        for (int i = 0; i < askingCubeBoxScript.Length; i++)
        {
            Destroy(askingCubeBoxScript[i].gameObject);
        }

        InstanEnemiesScirpt[] InstanEnemyScript = FindObjectsOfType<InstanEnemiesScirpt>();

        for (int i = 0; i < InstanEnemyScript.Length; i++)
        {
            if(InstanEnemyScript[i].Unlocked)
                    InstanEnemyScript[i].Unlocked = false;

            InstanEnemyScript[i].InstanEnemyFunction();


        }

        HaveLevelToUnlockThisGroundScript[] haveLevelToUnLock = FindObjectsOfType<HaveLevelToUnlockThisGroundScript>();


        for (int i = 0; i < haveLevelToUnLock.Length; i++)
        {

            haveLevelToUnLock[i].UpdateTheUnlockStatementFunction();




        }




        PlayerManagerScript.instance.UpdateCurrentTheCostAndCountHavePassedFunction();

        GameManager.instance.InstanResourseAreaFunction();

    }


    //Function : FireBtnFunction 
    //Method : This is the Function that used For 
    //Fire Btn Function 
    public void FireBtnFunction() 
    {
        if(PlayerManagerScript.instance != null)
        {

            if(PlayerManagerScript.instance.scoopScriptList.Count > 0) 
            {


                for (int i = 0; i < SelectedScoopScript.instance.scoopListScript.Count; i++)
                {

                    if (SelectedScoopScript.instance.scoopListScript.Count>0) 
                    {

                      if (PlayerManagerScript.
                                            instance.
                                            scoopScriptList.
                                            Contains(SelectedScoopScript.instance.scoopListScript[i])) 
                                        {    
                                            Destroy(SelectedScoopScript.instance.scoopListScript[i].gameObject);

                                            //PlayerManagerScript.
                                            //            instance.
                                            //            scoopScriptList = null;

                                            PlayerManagerScript.instance.scoopScriptList.Remove(SelectedScoopScript.instance.scoopListScript[i]);
                                            SelectedScoopScript.instance.scoopListScript.Clear();
                                          
                       
                                        }



                    }


                  


                    


                }


               



            }



        }

        PlayerManagerScript.instance.UpdateCurrentTheCostAndCountHavePassedFunction();





    }

    //Function : EnterBtnFunction
    //Method : This Function is mainly used For Checking The 
    //Mouse Click Has Enter The BtnFunction 
    public void EnterBtnFunction() 
    {
   //     Debug.Log("Has Enter The Btn ");
        HasEnterTheBtnBoolean = true;
    }

    //Function : ExitBtnFunction
    //Method : This is the Function that used 
    //For Exit Btn Function
    public void ExitBtnFunction() 
    {
    //    Debug.Log("Has Exit The Btn");
        HasEnterTheBtnBoolean = false;
    }

    //Function : OpenBuildBtnFunction
    //Method : This is the Function that used 
    //For Open The Build Button Function 
    public void OpenBuildBtnFunction() 
    {
        SelectedBtnObject.SetActive(false);
        BuildBtnObjects.SetActive(false);
        BuildingPanelObject.SetActive(true);
        GameManager.instance.HasPressedTheBuildBtn = true;

        for (int i = 0; i < SelectedScoopScript.instance.scoopListScript.Count; i++)
        {
            SelectedScoopScript.instance.scoopListScript[i].HasBeenSelectorObject.SetActive(false);
        }


        InBuildHireModeTextObj.SetActive(true);
        InBuildHireModeText.text = "Build Mode";


        SelectedScoopScript.instance.scoopListScript.Clear();



    }


    //Function : CloseBuildPanelBtnFunction
    //Method : This is the Function that used 
    //For Close Build Panel Btn Function 


    public void CloseBuildPanelBtnFunction() 
    {
        SelectedBtnObject.SetActive(true);
        BuildBtnObjects.SetActive(true);
        BuildingPanelObject.SetActive(false);

        InBuildHireModeTextObj.SetActive(false);
        GameManager.instance.HasPressedTheBuildBtn = false;
    }

    //Function : SetDefaultPositionFunction
    //Method : 
    public void SetDefaultPositionFunction() 
    {

        CameraCtrl.instance.SetStartPositionFunction();



    }

    //Function : ClickWorkerPanelButtonFunction
    //Method : This is the Level used to clicking The 
    //Worker Panel 
    public void ClickWorkerPanelButtonFunction()
    {
        for (int i = 0; i < SelectedScoopScript.instance.scoopListScript.Count; i++)
        {
            SelectedScoopScript.instance.scoopListScript[i].GetHasBeenSelectorObject().SetActive(false);




        }


        SelectedScoopScript.instance.scoopListScript = new List<ScoopScript>();


        WorkerPanelObjects.SetActive(!WorkerPanelObjects.activeInHierarchy);




    }


    //Function : UnlockThisAreaObjectFunction
    //Method : This is the Function used To Unlock THis Area 
    public void UnlockThisAreaObjectFunction() 
    {

     

        if (SelectedScoopScript.instance.GetInstanEnemiesScript().GetAskingCubeBoxFunction() != null)
        {
            Destroy(
                  SelectedScoopScript.instance.GetInstanEnemiesScript().GetAskingCubeBoxFunction().gameObject);
        }



        UNLOCKStatementFunction();


        Destroy(SelectedScoopScript.instance.GetInstanEnemiesScript().gameObject);


        HaveLevelToUnlockThisGroundScript[] haveLevelToUnLock = FindObjectsOfType<HaveLevelToUnlockThisGroundScript>();


        for (int i = 0; i < haveLevelToUnLock.Length; i++)
        {

            haveLevelToUnLock[i].UpdateTheUnlockStatementFunction();




        }







        StartCoroutine(SetBackToTheNullIEmerator());

        

  

    





        PlayerManagerScript.instance.Gold -= SelectedScoopScript.instance.GetCostFunction();


        UpdateCrtResourceTypeFunction(PlayerManagerScript.instance.foods,PlayerManagerScript.instance.fruitCollecterCost,PlayerManagerScript.instance.Woods,PlayerManagerScript.instance.Gold);


        if (DoYouWantToUnlockThisAreaPanel.activeInHierarchy)
        {
            DoYouWantToUnlockThisAreaPanel.SetActive(false);
        }



    }

    //Function : CloseTheRequiredPanelFunction
    //Method : This is the Functionthat used 
    //For Close The Required Panel Object Function 
    public void CloseTheRequiredPanelFunction() 
    {





        RequiredPanelObjects.SetActive(!RequiredPanelObjects.activeInHierarchy);





    }

    //

    public void OpenCheckCrtLvlStatementFunction() 
    {
        CheckCrtLvlStatementObjects.SetActive(true);

        UpdateCrtLevelHasBeenClearOrNotStatementFunction();
    }

    //Function :UpdateCrtLevelHasBeenClearOrNotStatementFunction

    void UpdateCrtLevelHasBeenClearOrNotStatementFunction() 
    {
        Lvl1Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel1 ? HaveClearSprite:HavenClearSprite;
        Lvl2Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel2 ? HaveClearSprite : HavenClearSprite;
        Lvl3Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel3 ? HaveClearSprite : HavenClearSprite;
        Lvl4Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel4 ? HaveClearSprite : HavenClearSprite;
        Lvl5Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel5 ? HaveClearSprite : HavenClearSprite;
        Lvl6Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel6 ? HaveClearSprite : HavenClearSprite;
        Lvl7Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel7 ? HaveClearSprite : HavenClearSprite;
        Lvl8Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel8 ? HaveClearSprite : HavenClearSprite;
        Lvl9Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel9 ? HaveClearSprite : HavenClearSprite;
        Lvl10Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel10 ? HaveClearSprite : HavenClearSprite;
        Lvl11Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel11 ? HaveClearSprite : HavenClearSprite;
        Lvl12Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel12 ? HaveClearSprite : HavenClearSprite;
        Lvl13Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel13 ? HaveClearSprite : HavenClearSprite;
        Lvl14Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel14 ? HaveClearSprite : HavenClearSprite;
        Lvl15Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel15 ? HaveClearSprite : HavenClearSprite;
        Lvl16Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel16 ? HaveClearSprite : HavenClearSprite;
        Lvl17Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel17 ? HaveClearSprite : HavenClearSprite;
        Lvl18Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel18 ? HaveClearSprite : HavenClearSprite;
        Lvl19Image.sprite = GameManager.instance.unLockStatement.hasUnLockLevel19 ? HaveClearSprite : HavenClearSprite;







    }

    //Function : CloseCheckCrtLevelStatementFunction
        
    public void CloseCheckCrtLevelStatementFunction() 
    {

        CheckCrtLvlStatementObjects.SetActive(false);

    }

    //Function : OpenPausePanelFunction
        //Method : This is the Function that used 
        //For Open The Pause Panel Function 
    public void OpenPausePanelFunction() 
    {
        PauseBtnObj.SetActive(false);
        PausePanelObj.SetActive(true);
        Time.timeScale = 0.0f;



    }


    public void ContinueBtnFunction() 
    {
        PauseBtnObj.SetActive(true);
        PausePanelObj.SetActive(false);
        Time.timeScale = 1.0f;


    }



    public void RestartBtnFunction() 
    {

        PausePanelObj.SetActive(false);
        NowLoadingPanelObj.SetActive(true);
        Time.timeScale = 1.0f;

        //SCENEMANAGERScript.instance.RestartSceneFunction();

        StartCoroutine(SCENEMANAGERScript.instance.RestartIEnumerator());




    }



    public void QuitGameBtnFunction() 
    {
        if(PausePanelObj.activeInHierarchy)
        PausePanelObj.SetActive(false);
        if (GameClearPanelObj.activeInHierarchy) 
        {
            GameClearPanelObj.SetActive(false);
        }



        NowLoadingPanelObj.SetActive(true);
        Time.timeScale = 1.0f;
        StartCoroutine(SCENEMANAGERScript.instance.QuitIEnumerator());



    }





    public void GameClearButWantToContinueFunction() 
    {
        GameClearPanelObj.SetActive(false);
    }






    //Function : UNLOCKStatementFunction
    //Method : This is the Function that used 
    //For Unlock The Statement Function 
    void UNLOCKStatementFunction() 
    {
        //  UNLOCKStatementFunction();

        if(SelectedScoopScript.instance.GetInstanEnemiesScript().isStage1)
      GameManager.instance.unLockStatement.hasUnLockLevel1 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage1;
        
        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage2)
        GameManager.instance.unLockStatement.hasUnLockLevel2 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage2;
        
        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage3)
        GameManager.instance.unLockStatement.hasUnLockLevel3 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage3;
        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage4)
        GameManager.instance.unLockStatement.hasUnLockLevel4 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage4;

        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage5)
            GameManager.instance.unLockStatement.hasUnLockLevel5 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage5;


        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage6)
            GameManager.instance.unLockStatement.hasUnLockLevel6 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage6;
        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage7)
            GameManager.instance.unLockStatement.hasUnLockLevel7 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage7;
        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage8)
            GameManager.instance.unLockStatement.hasUnLockLevel8 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage8;
        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage9)
            GameManager.instance.unLockStatement.hasUnLockLevel9 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage9;
        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage10)
            GameManager.instance.unLockStatement.hasUnLockLevel10= SelectedScoopScript.instance.GetInstanEnemiesScript().isStage10;

        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage11)
            GameManager.instance.unLockStatement.hasUnLockLevel11 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage11;

        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage12)
            GameManager.instance.unLockStatement.hasUnLockLevel12 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage12;

        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage13)
            GameManager.instance.unLockStatement.hasUnLockLevel13 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage13;

        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage14)
            GameManager.instance.unLockStatement.hasUnLockLevel14= SelectedScoopScript.instance.GetInstanEnemiesScript().isStage14;

        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage15)
            GameManager.instance.unLockStatement.hasUnLockLevel15 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage15;


        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage16)
            GameManager.instance.unLockStatement.hasUnLockLevel16 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage16;

        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage17)
            GameManager.instance.unLockStatement.hasUnLockLevel17 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage17;


        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage18)
            GameManager.instance.unLockStatement.hasUnLockLevel18 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage18;

        if (SelectedScoopScript.instance.GetInstanEnemiesScript().isStage19)
            GameManager.instance.unLockStatement.hasUnLockLevel19 = SelectedScoopScript.instance.GetInstanEnemiesScript().isStage19;


        CheckGameClearFunction();








    }

    //Function : CheckGameClearFunction
        //Method : This is the Function used For Check Game Clear Function 
    void CheckGameClearFunction() 
    {
        bool CheckFromLvl1ToLvl10Boolean = (GameManager.instance.unLockStatement.hasUnLockLevel1 &&
                GameManager.instance.unLockStatement.hasUnLockLevel2 &&
                    GameManager.instance.unLockStatement.hasUnLockLevel3 &&
                        GameManager.instance.unLockStatement.hasUnLockLevel4 &&
                            GameManager.instance.unLockStatement.hasUnLockLevel5 &&
                                GameManager.instance.unLockStatement.hasUnLockLevel6 &&
                                    GameManager.instance.unLockStatement.hasUnLockLevel7 &&
                                    GameManager.instance.unLockStatement.hasUnLockLevel8 &&
                                       GameManager.instance.unLockStatement.hasUnLockLevel9 &&
                                            GameManager.instance.unLockStatement.hasUnLockLevel10);




        bool CheckFromLvl11ToLvl19Boolean = 
            (GameManager.instance.unLockStatement.hasUnLockLevel11&&
                GameManager.instance.unLockStatement.hasUnLockLevel12&&
                    GameManager.instance.unLockStatement.hasUnLockLevel13 &&
                        GameManager.instance.unLockStatement.hasUnLockLevel14&& 
                            GameManager.instance.unLockStatement.hasUnLockLevel15 && 
                                GameManager.instance.unLockStatement.hasUnLockLevel16 && 
                                    GameManager.instance.unLockStatement.hasUnLockLevel17&& 
                                        GameManager.instance.unLockStatement.hasUnLockLevel18 && 
                                            GameManager.instance.unLockStatement.hasUnLockLevel19



            );




 



        if (CheckFromLvl1ToLvl10Boolean && !CheckFromLvl11ToLvl19Boolean
            ) 
        {
            if (!hasUnlockToFromLevel1To10)
            {
                Debug.Log("You Have Level1 To Level 10 ");

                PlayerManagerScript.instance.Gold += 15;
                hasUnlockToFromLevel1To10 = true;

                ClearLevel1To10PanelObj.SetActive(true);

            }

        }
        else if(CheckFromLvl1ToLvl10Boolean && CheckFromLvl11ToLvl19Boolean)
        {
            GameClearPanelObj.SetActive(true);


        }





    }

    //Function :DontWantToUnlockThisAreaObjectFunction
    //Method : This is the Function used For
        

    public void DontWantToUnlockThisAreaObjectFunction() 
    {
        if (DoYouWantToUnlockThisAreaPanel.activeInHierarchy) 
        {
            DoYouWantToUnlockThisAreaPanel.SetActive(false);
        }

        SelectedScoopScript.instance.SetAskingCubeObject(null);



    }



    public void CongratulationTextToFalseFunction() 
    {
        ClearLevel1To10PanelObj.SetActive(false);


    }

    //Function : UpdateTheCurrentNumberHaveFunction
    //Method : This is the Function used For Update The
    //Current Number Have Function 
     public void UpdateTheCurrentNumberHaveFunction
        (int farmer,int fruitCollecter,int axer,int hammer) 
    {
        UICurrentHaveFamer.text = farmer.ToString();
        UICurrentHaveFruitCollector.text = fruitCollecter.ToString();
        UICurrentHaveAxer.text = axer.ToString();
        UICurrentHaveHammer.text = hammer.ToString();
        UICurrentHaveOverall.text = (farmer + fruitCollecter + axer + hammer).ToString();
    }


    //Function : UpdateTheCostNumHaveFunction
    //Method : This is the Function used For Update The
    //Cost Function 
    public void UpdateTheCostNumHaveFunction
        (int farmerFoodsCost,
            int fruitCollecterFoodsCost,
                int axerFoodsCost,
                    int hammerFoodsCost) 
    {
        UIFoodsCostFarmer.text = farmerFoodsCost.ToString();
        UIFoodsCostFruitCollector.text = fruitCollecterFoodsCost.ToString();
        UIFoodsCostAxer.text = axerFoodsCost.ToString();
        UIFoodsCostHammer.text = hammerFoodsCost.ToString();
        UIFoodsCostOverall.text = (farmerFoodsCost + fruitCollecterFoodsCost+ axerFoodsCost+ hammerFoodsCost).ToString();



    }


    //Function : GetUNLockPanelObject
    //Method : This is the GameObjects which is used For Getting 
    //  The UNLock Panel Object 

    public GameObject GetUNLockPanelObject() 
    {
       



        return DoYouWantToUnlockThisAreaPanel;
    }


    //Function : GetWorkerPanelObjFunction
    //Method : This is the Function that used 
    //For Getting The Worker Panel 
    public GameObject GetWorkerPanelObjFunction() 
    {
        return WorkerPanelObjects;
    }

    //Function : GetRequiredPanelObject 
    //Method : This is the Function using For Getting The GameObject
    public GameObject GetRequireLevelPanelFunction() 
    {

     //   Debug.Log("This Object Has Been Called Before ");

        return RequiredPanelObjects;

    }

    //Function : GetClearLvl1To10PanelObject 
    //Method :
    public GameObject GetClearLvl1To10PanelObject() 
    {
        return ClearLevel1To10PanelObj;
    }

    public GameObject GetCheckCrtLevelStatementFunction() 
    {
        return CheckCrtLvlStatementObjects;
    }

    public GameObject GetGameClearPanelObject() 
    {
        return GameClearPanelObj;
    }

    //Function : GetPausePanelObjFunction
        //Method : This is the Function that used 
        //For Getting The Pause Panel 
    public GameObject GetPausePanelObjFunction() 
    {
        return PausePanelObj;
    }





    //Button : GetYesButtonFunction
        //Method : This is the Function used For 
        //Getting the Yes Button 
    public Button GetYesButtonFunction() 
    {
        return YesButton;
    }


    //Button : GetNoButtonFunction 
      //Method : This is the Function that used For Getting  
      //The No Button 
    public Button GetNoButtonFunction() 
    {
        return NoButton;
    }


    //Function : SetGoldenCostFunction 
    //Method : This is the Function that used 
    //For Setting To Setting The Golden Cost 
    public void SetGoldenCostFunction(int goldenCost) 
    {
        GoldenCost.text ="Golden To Unlock"+ goldenCost.ToString();


    }


    //Text : GetGoldenCostTextFunction
        //Method : This is the Function used 
            //For Getting the Golden Cost Text Function 
    public Text GetGoldenCostTextFunction() 
    {
        return UICostGoldenText;
    }

    //Text : GetRequiredLevelTextFunction
        //Method : This is the Function that used 
            //For Getting The Required Level Text 
    public Text GetRequiredLevelTextFunction() 
    {
        return RequiredLevetText;
    }

    //Text : GetHaveUnlockLevelTextFunction
    //Method : This is the Function used For Getting The 
        //Have Unlock Level Text Function 
    public Text GetHaveUnlockLevelTextFunction() 
    {
        return HaveUnlockLevelText;
    }

    //Function : SetRequiredLevelTextFunction
    //Method : This is the Function used For 
    //Setting The Required 
    public void SetRequiredLevelTextFunction(string requireText = "") 
    {
        RequiredLevetText.text = requireText;
    }

    public void SetHaveUnlockLevelTextFunction(string unlocklevel = "") 
    {
        HaveUnlockLevelText.text = unlocklevel;
    }

    public void SetNowLoadingCrtValue(float value = 0.0f) 
    {

        CrtNowLoadingSpriteImage.fillAmount = value;
    }



    IEnumerator SetBackToTheNullIEmerator() 
    {
        yield return new WaitForSeconds(0.5f);

        SelectedScoopScript.instance.SetInstanEnemyFunction();

    }

}
