using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { private set; get; }

    [HideInInspector]
    public bool HasPressedTheBuildBtn = false;

    [HideInInspector]
    public bool HasPressTheCreateObjectBtn = false;


    [HideInInspector]
    public int DayInteger = 1;


    public int BuildingIndex = 0;



    [SerializeField] GameObject[] BuildingObjects;
    [SerializeField] GameObject GoldenObj;
    [SerializeField] GameObject WoodsObj;



    [SerializeField] Transform BuildingParentObject;

    public List<BuildObjectScript> buildObjectListScript = new List<BuildObjectScript>();



    [SerializeField] GameObject SoilderGameObjects;

    [SerializeField] Transform SetSoilderGameObjectTransform;



    public GameObject GetSoilderEnemyObject() 
    {
        return SoilderGameObjects;
    }



    public List<AISOILDERCtrlScript> lvl1UnlockEnemiesCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl2UnlockEnemiesCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl3UnlockEnemiesCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl4UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl5UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl6UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl7UnlockEnemyCount = new List<AISOILDERCtrlScript>();




    public List<AISOILDERCtrlScript> lvl9UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl10UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl11UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl12UnlockEnemyCount = new List<AISOILDERCtrlScript>();



    public List<AISOILDERCtrlScript> lvl14UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl15UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl16UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl17UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    public List<AISOILDERCtrlScript> lvl18UnlockEnemyCount = new List<AISOILDERCtrlScript>();

    


    List<AISOILDERCtrlScript> InstanSoilderAreaScript = new List<AISOILDERCtrlScript>();

    public List<ResourceCollectiveScript> GoldResourceCollectiveScript = new List<ResourceCollectiveScript>();

    public List<ResourceCollectiveScript> WoodsResourceCollectiveScript = new List<ResourceCollectiveScript>();

    [System.Serializable]
    public class UNLOCKStatementClass 
    {
        public bool hasUnLockLevel1 = false;
        public bool hasUnLockLevel2 = false;
        public bool hasUnLockLevel3 = false;
        public bool hasUnLockLevel4 = false;
        public bool hasUnLockLevel5 = false;
        public bool hasUnLockLevel6 = false;
        public bool hasUnLockLevel7 = false;
        public bool hasUnLockLevel8 = false;
        public bool hasUnLockLevel9 = false;
        public bool hasUnLockLevel10 = false;
        public bool hasUnLockLevel11 = false;
        public bool hasUnLockLevel12 = false;
        public bool hasUnLockLevel13 = false;
        public bool hasUnLockLevel14 = false;
        public bool hasUnLockLevel15 = false;
        public bool hasUnLockLevel16 = false;
        public bool hasUnLockLevel17 = false;
        public bool hasUnLockLevel18 = false;
        public bool hasUnLockLevel19 = false;
      

    }

    public
    UNLOCKStatementClass unLockStatement;

    [SerializeField] Transform SpawnResourceTransformArea;

    bool isGameClear = false;
    public bool ISGAMECLEAR 
    {
        get { return isGameClear; }
    }





    private void Awake()
    {

        if (instance == null)
                instance = this;


    }

    private void Start()
    {
        BuildObjectScript[] buildObjectCrtScript = FindObjectsOfType<BuildObjectScript>();

        if(buildObjectCrtScript.Length > 0) 
        {
            for (int i = 0; i < buildObjectCrtScript.Length; i++)
            {
                buildObjectListScript.Add(buildObjectCrtScript[i]);

                Vector3 gridPosition = GROUNDSScript.instance.CalculatorGridPosition(buildObjectListScript[i].transform.position, buildObjectListScript[i].GetYPos());
                for (int j = 0; j < buildObjectListScript.Count; j++)
                {
                    GROUNDSScript.
                                         instance.
                                             GetBuildObjectScript()
                                             [(int)buildObjectListScript[j].transform.position.x,
                                             (int)buildObjectListScript[j].transform.position.z]
                                              = buildObjectCrtScript[j];
                }



            }




 







        }
        else 
        {

            Debug.Log("You Don't have Building Objects In The Scene ");
        }

        isGameClear = false;



        InstanResourseAreaFunction();


        InstantiateSoilderFunction();


    }

    //Function : GetBuildingObjectFunction
    //Method : This is the Function used 
    //For Getting The Building Object 
    public GameObject[] GETBULDINGOBJECTFunction() 
    {
        if (BuildingObjects != null) 
        {
            return BuildingObjects;
        }




        return null;
    }

    //Function : GetBuildingParentTransform
    //Method : This is the Function that used For Getting The Building Parent 
    public Transform GetBuildingParentTransform() 
    {
        if(BuildingParentObject != null)
        return BuildingParentObject;



        return null;
    }

    //Function : GetSoilderTroopParentTransform
    //Method : This is the Function used For Getting  
    //the Soilder Troop Parent Transform
    public Transform GetSoilderTroopParentTransform() 
    {
        return SetSoilderGameObjectTransform;
    }

    //GameObject : GetGoldGameObject
        //Method : This is the GameObject used For
        //Getting The Golden Game Objects
    public GameObject GetGoldGameObject() 
    {
        return GoldenObj;
    }



    //Function : InstanResourseAreaFunction 
  //Method : This is the Function used For Instan Resourse Area Function 
    public void InstanResourseAreaFunction() 
    {

        #region  InstanGoldObjectRegions 


        InstanResourceAreaScript[] instanResourceAreaScript = FindObjectsOfType<InstanResourceAreaScript>();

        BuildObjectScript buildObjectScript = GoldenObj.GetComponent<BuildObjectScript>();



        for (int i = 0; i < instanResourceAreaScript.Length; i++)
        {  
            Transform[] trans = instanResourceAreaScript[i].GetTransformListToArrayFunction();

            if (instanResourceAreaScript[i].GetIsInstanGoldArea()) 
            {

              

                for (int j = GoldResourceCollectiveScript.Count; j < trans.Length; j++)
                {

                    GameObject InstanGoldObject = Instantiate(GoldenObj, new Vector3(trans[j].position.x, buildObjectScript.GetYPos(), trans[j].position.z), Quaternion.identity);

                    InstanGoldObject.transform.SetParent(SpawnResourceTransformArea);




                    ResourceCollectiveScript INSTANGOLDOBJAREA = InstanGoldObject.GetComponent<ResourceCollectiveScript>();


                    GoldResourceCollectiveScript.Add(INSTANGOLDOBJAREA);






                }


            }


            if (instanResourceAreaScript[i].GetisInstanWoodsArea()) 
            {
                for (int j = 0; j < trans.Length; j++)
                {
                    GameObject InstanWoodsObj = Instantiate(WoodsObj, new Vector3(trans[j].position.x, buildObjectScript.GetYPos(), trans[j].position.z), instanResourceAreaScript[i].transform.rotation);

                    InstanWoodsObj.transform.SetParent(SpawnResourceTransformArea);




                    ResourceCollectiveScript InstanWoodsArea = InstanWoodsObj.GetComponent<ResourceCollectiveScript>();


                 WoodsResourceCollectiveScript.Add(InstanWoodsArea);





                }





            }








        }

        #endregion












    }


    //Function : InstantiateSoilderFunction
        //Method : This is the Function used 
        //For Instantiate Soilder Function 
    public
 void InstantiateSoilderFunction() 
    {
        InstanSoilderAreaScript instantiateSoilderScript = FindObjectOfType<InstanSoilderAreaScript>();






        for (int i = 0; i < instantiateSoilderScript.GetTransformListToArrayFunction().Length; i++)
        {
            Transform[] instanBoss = instantiateSoilderScript.GetTransformListToArrayFunction();

            if(InstanSoilderAreaScript.Count < instanBoss.Length) 
            {

                for (int j =InstanSoilderAreaScript.Count; j < instanBoss.Length; j++)
                {

             GameObject instanSoilder =        Instantiate(SoilderGameObjects,instanBoss[j].position,Quaternion.identity);
                    AISOILDERCtrlScript aisoilderScript = instanSoilder.GetComponent<AISOILDERCtrlScript>();


                    InstanSoilderAreaScript.Add(aisoilderScript);



                }



            }

        }

    }

    //List Function : GetInstanSoilderCtrlListFunction
    //Method : This is the Function that used For 
    //Get Instan Soilder Ctrl List Function
    public List<AISOILDERCtrlScript> GetInstanSoilderCtrlListFunction() 
    {
        return InstanSoilderAreaScript;
    }

}
