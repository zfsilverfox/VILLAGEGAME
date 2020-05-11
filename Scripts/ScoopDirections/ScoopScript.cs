using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum SCOOPENUMCrtStatement 
{
    IDLE,
    MovingToDestination,

    MovToFarming,
    MovToTalking,
    MovToFighting,
    Talking,
    Farming,
    Fighting,
    DEAD,

}








[RequireComponent(typeof(NavMeshAgent))]
public class ScoopScript : MonoBehaviour
{
    NavMeshAgent navMeshAgents;

    private static string AnimMovingBooleanString = "isWalkings";
    private static string AnimFarmingBooleanString = "isFarming";
    private static string AnimGatheringBooleanString = "isGathering";
    private static string AnimisAxeingBooleanString = "isAxeing";
    private static string AnimisHammeringBooleanString = "isHammering";
    private static string AnimisTiringBooleanString = "isTiring";
    private static string AnimEQUIPWEAPONBooleanString = "EQUIPWEAPON";
    private static string AnimDODanceBoolean = "DODanceBoolean";
    private static string AnimisTalkingBooleanString = "isTalking";
    private static string AnimAttackTriggerString = "AttackTrigger";
    private static string AnimGetTriggerString = "GetHItTrigger";
    private static string AnimDEATHString = "DEATH";



    Animator anim;

    public ScoopEnumType scoopEnumType;

    public EnergyType energyType;

    public GameObject HasBeenSelectorObject;
    [SerializeField] GameObject WeaponObj;





    public SCOOPENUMCrtStatement scoopEnum;
    [HideInInspector]
  public  bool isDead = false;

    public GameObject FarmingObject;

    public GameObject AxeObject;

    public GameObject HammerObject;


    CapsuleCollider capCollider;

    Rigidbody rgbd;


    ResourceCollectiveScript resourceCollectiveScript;

    //Function : GetResourceCollectiveScriptFunction :
    //Method : This is the Function used For 
    //Getting The ResourceCollectiveScript 
    public ResourceCollectiveScript GetResourceCollectiveScriptFunction() 
    {


        return resourceCollectiveScript;

    }





    float CollectCrtTiming;
    float CollectDelayTiming = 10f;

    float wasteEnergy = 0.5f;
    float attackCrtTimer;
    float attackDelayTimer = 1.5f;



    ScoopCrtStatementUIScript scoopCrtStatementScript;


    public ScoopCrtStatementUIScript GETSCOOPUICRTSTATEMENT() 
    {
        if (scoopCrtStatementScript) 
        {
            return scoopCrtStatementScript;
        }



        return null;
    }

    float danceIemeratorCrtStatement;
    float danceIEmeratorMaxStatement;

 //   float stoppingDistance;

    bool HasDoTheDanceStatement = false;
   [HideInInspector]
public    bool isMoving = false;
   
  public  bool isFarming = false;

    [HideInInspector]
public    bool isInTalkingArea = false;

    [HideInInspector]
    public bool isDoingFighting = false;

    bool TakeDamageBoolean = false;




public    float movingToTalkingCrtStatement;
   
    public float movingToTalkingMaxStatement;

    Vector3 lookAtPlayerPosition;

    GameObject HaveTalkingPLAYERObj;

    bool isTalkingBoolean = false;

    bool HasStartTalkingIEmerator = false;

   // public bool isDead = false;

    public GameObject GetHasBeenSelectorObject() 
    {
        if (HasBeenSelectorObject) 
        {
            return HasBeenSelectorObject;
        }



        return null;
    }


    public GameObject ReceivedObject;

 public   AISOILDERCtrlScript aiSoilderCtrlScript;

    bool HasWeaponBoolean = false; 




    private void Awake()
    {

        GetComponentFunction();


    }

    //Function : GetComponentFunction
    //Method : This is the Function that used For Getting The Component Function
    void GetComponentFunction() 
    {

  if (navMeshAgents == null)
                navMeshAgents = GetComponent<NavMeshAgent>();

        if (capCollider == null)
            capCollider = GetComponent<CapsuleCollider>();

        if (rgbd == null)
                rgbd = GetComponent<Rigidbody>();


        if (anim == null)
                anim = GetComponentInChildren<Animator>();

        if (scoopCrtStatementScript == null)
            scoopCrtStatementScript = GetComponentInChildren<ScoopCrtStatementUIScript>();
    }

    private void Start()
    {
        SettingStatement(SCOOPENUMCrtStatement.IDLE);
        danceIEmeratorMaxStatement = Random.Range(3.5f, 5f);

        SettingBasicFunction();
       
    }

    // Function : SettingBasicFunction
    //Method: This is the Function used For Setting The Basic Function

    void SettingBasicFunction() 
    {
        // attackDelayTimer = Random.Range(8f, 9f);
     
        switch (scoopEnumType)
        {
            case ScoopEnumType.Farmer:
                energyType.CrtHP = energyType.MaxHP = Random.Range(5, 8);
                energyType.fighterEnergy = Random.Range(16f, 19f);
                break;

            case ScoopEnumType.Gathering:
                energyType.CrtHP = energyType.MaxHP = Random.Range(6, 9);

                energyType.fighterEnergy = Random.Range(14.5f, 17f);

                break;
            case ScoopEnumType.Axe:

                energyType.CrtHP = energyType.MaxHP = Random.Range(11, 14);
                energyType.fighterEnergy = Random.Range(9.2f, 11.8f);

                break;
            case ScoopEnumType.Hammer:
                energyType.CrtHP = energyType.MaxHP = Random.Range(17, 21);
                energyType.fighterEnergy = Random.Range(6f, 7f);

                break;



        }

        attackDelayTimer = energyType.fighterEnergy;

        movingToTalkingMaxStatement = 15;

        movingToTalkingCrtStatement = movingToTalkingMaxStatement;
        isTalkingBoolean = false;
        HasStartTalkingIEmerator = false;

        HasWeaponBoolean = false;

    }


    //Function : SettingStatement
    //Method : This Function is used For Setting The Function which is Setting The Statement 

  public  void SettingStatement(SCOOPENUMCrtStatement toscoop) 
    {
        scoopEnum = toscoop;


        if(this.gameObject != null) 
        {
            if (scoopEnum == SCOOPENUMCrtStatement.IDLE)
            {
                isMoving = false;
                isFarming = false;
                resourceCollectiveScript = null;
                navMeshAgents.isStopped = true;
                anim.SetBool(AnimMovingBooleanString, false);
                anim.SetBool(AnimFarmingBooleanString, false);
                anim.SetBool(AnimGatheringBooleanString, false);
                anim.SetBool(AnimisAxeingBooleanString, false);
                anim.SetBool(AnimisHammeringBooleanString, false);
                anim.SetBool(AnimisTalkingBooleanString, false);
                anim.ResetTrigger(AnimAttackTriggerString);
                SetTalkingBooleanStatement(false);
                if (energyType.CrtSpirit <= 0)
                {
                    anim.SetBool(AnimisTiringBooleanString, true);
                }
                else if (energyType.CrtSpirit > 0)
                {
                    anim.SetBool(AnimisTiringBooleanString, false);


                }




                navMeshAgents.ResetPath();
                if (FarmingObject != null)
                {
                    FarmingObject.SetActive(false);
                }

                if (AxeObject != null)
                {
                    AxeObject.SetActive(false);
                }

                if (HammerObject != null)
                {
                    HammerObject.SetActive(false);
                }


                if (WeaponObj != null)
                {
                    WeaponObj.SetActive(false);
                }

                isDoingFighting = false;


                aiSoilderCtrlScript = null;





            }






        }






    }

    //Function : MovToPositionFunction
    //Method : This is the Function used For Moving To 
    //The Destination 
    public void MovToPositionFunction(Vector3 pos) 
    {
        if(energyType.CrtSpirit <= 0) 
        {

            SettingStatement(SCOOPENUMCrtStatement.IDLE);

            return;
        }
        else if(energyType.CrtSpirit > 0) 
        {
            anim.SetBool(AnimisTiringBooleanString,false);
            SettingStatement(SCOOPENUMCrtStatement.MovingToDestination);
        }

        StopCoroutine(DOTalkingIEmerator());
        StopCoroutine(DODANCEIEnumerator());


        isMoving = true;

        isDoingFighting = false;

        aiSoilderCtrlScript = null;

        // navMeshAgents.stoppingDistance = Random.Range(0.2f, 0.9f);
        navMeshAgents.stoppingDistance = Random.Range(0.8f, 1.45f);
        SettingStatement(SCOOPENUMCrtStatement.MovingToDestination);
        anim.SetBool(AnimFarmingBooleanString, false);
        anim.SetBool(AnimGatheringBooleanString, false);
        anim.SetBool(AnimisAxeingBooleanString, false);
        anim.SetBool(AnimisHammeringBooleanString, false);
        anim.SetBool(AnimisTalkingBooleanString, false);
        anim.SetBool(AnimMovingBooleanString, true);
        anim.SetBool(AnimDODanceBoolean, false);
        anim.SetBool(AnimEQUIPWEAPONBooleanString, false);
        anim.ResetTrigger(AnimAttackTriggerString);

        resourceCollectiveScript = null;
        navMeshAgents.isStopped = false;
     navMeshAgents.SetDestination(pos);
        FarmingObject.SetActive(false);
        if (AxeObject != null)
        {
            AxeObject.SetActive(false);
        }

        if(WeaponObj != null) 
        {
            WeaponObj.SetActive(false);
        }





    }

    //Function : MovToResourceFunction
    //Method : This is the Function used For Soilder who are going to The Resource Area  

    public void MovToResourceFunction(Vector3 pos, SCOOPENUMCrtStatement scoopEnumType,ResourceCollectiveScript setResourceSource = null)
    {
        SettingStatement(scoopEnumType);

        StopCoroutine(DOTalkingIEmerator());



        isMoving = true;

        aiSoilderCtrlScript = null;


        anim.SetBool(AnimMovingBooleanString, true);
        anim.SetBool(AnimFarmingBooleanString, false);
        anim.SetBool(AnimGatheringBooleanString, false);
        anim.SetBool(AnimisHammeringBooleanString, false);
        anim.SetBool(AnimisAxeingBooleanString, false);
        anim.SetBool(AnimDODanceBoolean, false);
        anim.SetBool(AnimisTalkingBooleanString, false);
        anim.SetBool(AnimEQUIPWEAPONBooleanString, false);
        anim.ResetTrigger(AnimAttackTriggerString);

        navMeshAgents.isStopped = false;
       
        navMeshAgents.stoppingDistance = Random.Range(0.8f, 1.8f);




        navMeshAgents.SetDestination(pos);
        FarmingObject.SetActive(false);
        resourceCollectiveScript = setResourceSource;
        if (AxeObject != null)
        {
            AxeObject.SetActive(false);
        }

        HammerObject.SetActive(false);



        scoopCrtStatementScript.SetIldeSpriteFunction();



    }

    //Function : TalkingToAntherPlayerStatementFunction 
   public void TalkingToAnotherPlayerStatementFunction(Vector3 pos,GameObject talkingPlayerObject = null)
        
    {
     //   Debug.Log("Mov To Another Player Statement");


   //     SettingStatement(SCOOPENUMCrtStatement.MovToTalking);


        isMoving = true;


        if (!isFarming) 
        {

            anim.SetBool(AnimMovingBooleanString, true);
            anim.SetBool(AnimFarmingBooleanString, false);
            anim.SetBool(AnimGatheringBooleanString, false);
            anim.SetBool(AnimisHammeringBooleanString, false);
            anim.SetBool(AnimisAxeingBooleanString, false);
            anim.SetBool(AnimDODanceBoolean, false);
            anim.SetBool(AnimisTalkingBooleanString, false);
            anim.SetBool(AnimEQUIPWEAPONBooleanString, false);
            anim.ResetTrigger(AnimAttackTriggerString);
            navMeshAgents.isStopped = false;
            aiSoilderCtrlScript = null;




            navMeshAgents.stoppingDistance = 1.5f;

            if (WeaponObj != null)
            {
                WeaponObj.SetActive(false);
            }


            //    navMeshAgents.SetDestination(pos);

            lookAtPlayerPosition = pos;



        }



      

        HaveTalkingPLAYERObj = talkingPlayerObject;
    }

    //Function : MovToEnemySoilderFunction 
    //Method : This is the Function that used 
    //For Moving To The Enemy Soilder 
    public void MovToEnemySoilderFunction(Vector3 pos, AISOILDERCtrlScript soilderCtrlScript = null) 
    {

        //  Debug.Log("Has Been Called in Scoop Script ");

        StopCoroutine(DOTalkingIEmerator());
        StopCoroutine(DODANCEIEnumerator());

        isMoving = true;

        aiSoilderCtrlScript = soilderCtrlScript;

        if(aiSoilderCtrlScript == null)
        {

            isDoingFighting = false;

            if(WeaponObj != null) 
            {
                WeaponObj.SetActive(false);
            }


            SettingStatement(SCOOPENUMCrtStatement.IDLE);

            return;
        }




        if(aiSoilderCtrlScript != null) 
        {

            isDoingFighting = true;

            anim.SetBool(AnimEQUIPWEAPONBooleanString, true);

            anim.SetBool(AnimMovingBooleanString, true);

            anim.SetBool(AnimisTalkingBooleanString, false);

            anim.SetBool(AnimDODanceBoolean, false);

            anim.ResetTrigger(AnimAttackTriggerString);


            SettingStatement(SCOOPENUMCrtStatement.MovToFighting);
            
            navMeshAgents.isStopped = false;
            
            navMeshAgents.stoppingDistance = 1.5f;

            navMeshAgents.SetDestination(pos);

            if (WeaponObj != null)
            {
                WeaponObj.SetActive(true);
            }


            scoopCrtStatementScript.SetAttackSpriteFunction();


        }

    }

    //Function : SetEnemySoilderFunctiontoNULLFunction
    //Method : This is the Function used For Setting The Enemy 
    //Soilder to NULL Statement 
    public void SetEnemySoilderFunctionToNULLFunction() 
    {
        aiSoilderCtrlScript = null;
        SettingStatement(SCOOPENUMCrtStatement.IDLE);
    }





    private void Update()
    {
        if (!isDead) 
        
        {

 switch (scoopEnum) 
        {
            case SCOOPENUMCrtStatement.IDLE:
                IldeUpdateFunction();
                break;

            case SCOOPENUMCrtStatement.MovingToDestination:
                MovingToDestinationUpdateFunction();
                break;
            case SCOOPENUMCrtStatement.MovToFarming:
                MovToDestinationFarming();
                break;
            case SCOOPENUMCrtStatement.MovToTalking:
           //     MovToTalkingFunction();

                break;
            case SCOOPENUMCrtStatement.MovToFighting:

                MovToFightFunction();

                break;

            case SCOOPENUMCrtStatement.Farming:
                FARMINGUpdateStatement();
                break;
            case SCOOPENUMCrtStatement.Talking:

            //    TalkingUpdateStatement();

                break;
            case SCOOPENUMCrtStatement.Fighting:

                FightingUpdateStatement();

                break;

        }


            HasWeaponBoolean = anim.GetBool(AnimEQUIPWEAPONBooleanString);






        }
        else 
        {





        }



       

    }


    //Function : IldeUpdateFunction
    //Method : This is the Function that used For Update The Ilde Statement
    void IldeUpdateFunction() 
    {
        if (TakeDamageBoolean) 
        {



            return;
        }



        FarmingObject.SetActive(false);
        if (AxeObject != null)
        {
            AxeObject.SetActive(false);
        }

        if (HammerObject != null)
        {
            HammerObject.SetActive(false);
        }
        WeaponObj.SetActive(false);




        if (scoopCrtStatementScript.GetEmotionBubbleGameObject().gameObject.activeInHierarchy)
        {
            scoopCrtStatementScript.SetIldeSpriteFunction();




        }

        if(!isMoving ||!isFarming)
        {
            if (!isInTalkingArea) 
            {
               


                if(aiSoilderCtrlScript == null) 
                {

                    if (danceIemeratorCrtStatement > danceIEmeratorMaxStatement)
                    {
                        if (energyType.CrtSpirit > 0)
                            StartCoroutine(DODANCEIEnumerator());

                    }

                    movingToTalkingCrtStatement = 0.0f;

                    movingToTalkingMaxStatement = 15;
                    isTalkingBoolean = false;

                    SetTalkingBooleanStatement(false);
                    danceIemeratorCrtStatement += Time.deltaTime;






                }
                else 
                {
                    StopCoroutine(DOTalkingIEmerator());

                    StopCoroutine(DODANCEIEnumerator());

                }
                   
            }

            else 
            {


                //if(energyType.CrtSpirit > 0) 
                //{

                //    if(scoopEnum!= SCOOPENUMCrtStatement.Farming) 
                //    {
                       

                //        if(aiSoilderCtrlScript == null) 
                //        {
                //                SetTalkingBooleanStatement(false);
                //            movingToTalkingCrtStatement += Time.deltaTime;

                //            if (movingToTalkingCrtStatement >= movingToTalkingMaxStatement)
                //            {

                //                SettingStatement(SCOOPENUMCrtStatement.MovToTalking);
                //            }



                //        }
                //        else if(aiSoilderCtrlScript != null) 
                //        {

                //            movingToTalkingCrtStatement = 0.0f;
                //            SettingStatement(SCOOPENUMCrtStatement.MovToFighting);

                //        }
                //    }

                //}

            }

        }
        else 
        {
            StopCoroutine(DODANCEIEnumerator());
            anim.SetBool(AnimDODanceBoolean, false);
            danceIemeratorCrtStatement = 0.0f;
            danceIEmeratorMaxStatement = Random.Range(3.5f, 5f);
        }

    }

    //Function : MovingToDestinationUpdateFunctio
    //Method : This is the Function that used 
    //For Update  Moving To Destination Statement 
    void MovingToDestinationUpdateFunction() 
    {

        if(Vector3.Distance(transform.position,navMeshAgents.destination) <= navMeshAgents.stoppingDistance) 
        {
            SetTalkingBooleanStatement(false);

            resourceCollectiveScript = null;
            SettingStatement(SCOOPENUMCrtStatement.IDLE);
        }



    }

    //Function : MovToDestinationFarming 
    //Method : This is the Function that used For Moving To The Destination

    void MovToDestinationFarming() 
    {
        if(resourceCollectiveScript == null) 
        {
            SettingStatement(SCOOPENUMCrtStatement.IDLE);
            return;

        }

        anim.SetBool(AnimisTalkingBooleanString, false);
        anim.SetBool(AnimFarmingBooleanString, false);
        anim.SetBool(AnimisHammeringBooleanString, false);
        anim.SetBool(AnimisAxeingBooleanString, false);
        anim.SetBool(AnimGatheringBooleanString, false);


        FarmingObject.SetActive(false);
        if (AxeObject != null)
        {
            AxeObject.SetActive(false);
        }

        if (HammerObject != null)
        {
            HammerObject.SetActive(false);
        }
        WeaponObj.SetActive(false);



        if (Vector3.Distance(transform.position, navMeshAgents.destination) <= navMeshAgents.stoppingDistance)
        {
            
            anim.SetBool(AnimMovingBooleanString, false);
            SetTalkingBooleanStatement(false);

            if (resourceCollectiveScript.gameObject != null)
            LOOKAT(resourceCollectiveScript.gameObject.transform.position) ;
            else 
            {

                resourceCollectiveScript = null;
                SettingStatement(SCOOPENUMCrtStatement.IDLE);
            }
           



            //resourceCollectiveScript = null;
            SettingStatement(SCOOPENUMCrtStatement.Farming);
            

        }



    }

    //Function :  MovToTalkingFunction() 
    //Method : This is the Function used For Moving To Talking Statement
    void MovToTalkingFunction()
    {


        if (!isFarming)
        {

            SetTalkingBooleanStatement(false);

            if (isInTalkingArea)
            {

                if (Vector3.Distance(transform.position, navMeshAgents.destination) <= navMeshAgents.stoppingDistance)
                {
                    anim.SetBool(AnimMovingBooleanString, false);
                    StopCoroutine(DOTalkingIEmerator());
                    LookAtFunction(lookAtPlayerPosition);

                    SettingStatement(SCOOPENUMCrtStatement.Talking);

                }




            }

            else

            {
                StopCoroutine(DOTalkingIEmerator());

                SettingStatement(SCOOPENUMCrtStatement.IDLE);

            }




        }

        else 
        {
            anim.SetBool(AnimMovingBooleanString, false);
            SettingStatement(SCOOPENUMCrtStatement.Farming);
        }











    }

    //Function : MovToFightFunction 
    //Method : This is the Functio that used 
    //For Moving To Fighting Statement 
    void MovToFightFunction() 
    {
        if(aiSoilderCtrlScript == null) 
        {
            SettingStatement(SCOOPENUMCrtStatement.IDLE);
            return;
        }
        if(aiSoilderCtrlScript != null) 
        {
            if (aiSoilderCtrlScript.isDead) 
            {


            SettingStatement(SCOOPENUMCrtStatement.IDLE);
                aiSoilderCtrlScript = null;
            return;


            }





        }


        anim.SetBool(AnimisTalkingBooleanString,false);
        anim.SetBool(AnimFarmingBooleanString,false);
        anim.SetBool(AnimisHammeringBooleanString, false);
        anim.SetBool(AnimisAxeingBooleanString, false);
        anim.SetBool(AnimGatheringBooleanString, false);



        if (Vector3.Distance(transform.position, navMeshAgents.destination) <= navMeshAgents.stoppingDistance) 
        {

            StopCoroutine(DOTalkingIEmerator());
            StopCoroutine(DODANCEIEnumerator());


            isMoving = false;

            anim.SetBool(AnimMovingBooleanString, false);



            SettingStatement(SCOOPENUMCrtStatement.Fighting);





        }





    }

    //Function : FARMINGUpdateStatement
    //Method : This is the Function that used To Update The Statement 
    void FARMINGUpdateStatement() 
    {
        if (TakeDamageBoolean) 
        {


            return;
        }

        //Debug.Log("Farming Update Statement");
       if(resourceCollectiveScript == null) 
        {


            SettingStatement(SCOOPENUMCrtStatement.IDLE);

            return;
        }

       if(aiSoilderCtrlScript != null) 
        {
            SettingStatement(SCOOPENUMCrtStatement.MovToFighting);
            return;

        }

        isFarming = true;



       if(energyType.CrtSpirit <= 0) 
        {
            SettingStatement(SCOOPENUMCrtStatement.IDLE);
            resourceCollectiveScript = null;
            return;
        }


      



        SetTalkingBooleanStatement(false);


        if (Time.time > CollectCrtTiming) 
        {

            switch (resourceCollectiveScript.resourceType) 
            {
                case ResourceCollectiveScript.ResourceType.Resource_Farmings:

                    if (energyType.farmerCollectTiming != 0) 
                    {

                        CollectCrtTiming = Time.time + CollectDelayTiming / energyType.farmerCollectTiming;

                        switch (scoopEnumType) 
                        {
                            case ScoopEnumType.Farmer:
                                wasteEnergy = 0.25f;
                                break;

                            case ScoopEnumType.Gathering:
                                wasteEnergy = 0.7f;
                                break;

                            case ScoopEnumType.Axe:

                                wasteEnergy = 1.25f;
                                break;


                        }



                        energyType.CrtSpirit -= wasteEnergy;

                        FarmingObject.SetActive(true);
                        if (AxeObject != null)
                        {
                            AxeObject.SetActive(false);
                        }

                        if (HammerObject != null)
                        {
                            HammerObject.SetActive(false);
                        }

                        if (WeaponObj != null)
                        {
                            WeaponObj.SetActive(false);
                        }

                        resourceCollectiveScript.GatherAmounts((int)energyType.farmerEnergy * 1);


                        GameObject InstanReceivedObjecPrefab =
                            Instantiate(ReceivedObject, resourceCollectiveScript.transform.position, Quaternion.identity);




                        TextMesh textMesh = InstanReceivedObjecPrefab.GetComponent<TextMesh>();

                        if (textMesh)
                        {
                            textMesh.text = "Foods Received +" + ((int)energyType.farmerEnergy * 1).ToString();
                        }




                        anim.SetBool(AnimFarmingBooleanString, true);


                      
                       
                        if(UIManager.instance != null) 
                        {
                            UIManager.instance.UpdateCrtResourceTypeFunction
                                (PlayerManagerScript.instance.foods,
                                        PlayerManagerScript.instance.recoverFruits,
                                            PlayerManagerScript.instance.Woods,
                                                PlayerManagerScript.instance.Gold);
                        }

                    }
                       
                    else
                        Debug.LogError("The Collective Divide Should Not Be Zero");




                 

                    break;

                case ResourceCollectiveScript.ResourceType.Resource_Fruits:

                    if (energyType.gatheringCollectTiming != 0)
                    {






                        CollectCrtTiming = Time.time + CollectDelayTiming / energyType.gatheringCollectTiming;
                        switch (scoopEnumType)
                        {
                            case ScoopEnumType.Farmer:
                                wasteEnergy = 0.65f;
                                break;
                            case ScoopEnumType.Gathering:
                                wasteEnergy = 0.15f;

                                break;

                            case ScoopEnumType.Axe:
                                wasteEnergy = 1.25f;
                                break;


                        }





                        energyType.CrtSpirit -= wasteEnergy;

                        FarmingObject.SetActive(false);
                        if (AxeObject != null)
                        {
                            AxeObject.SetActive(false);
                        }

                        if (HammerObject != null)
                        {
                            HammerObject.SetActive(false);
                        }

                        if (WeaponObj != null)
                        {
                            WeaponObj.SetActive(false);
                        }





                        anim.SetBool(AnimGatheringBooleanString, true);


                        if(resourceCollectiveScript.CrtAmount < 0) 
                        {
                            resourceCollectiveScript.CrtAmount = 0;
                            SettingStatement(SCOOPENUMCrtStatement.IDLE);

                        }

                     


                        resourceCollectiveScript.GatherAmounts((int)energyType.gatheringEnergy * 1);

                        GameObject InstanReceivedObjecPrefab =
                           Instantiate(ReceivedObject, resourceCollectiveScript.transform.position, Quaternion.identity);




                        TextMesh textMesh = InstanReceivedObjecPrefab.GetComponent<TextMesh>();

                        if (textMesh)
                        {
                            textMesh.text = "Fruits +" + ((int)energyType.gatheringEnergy * 1).ToString();
                        }





                        if (UIManager.instance != null)
                        {
                            UIManager.instance.UpdateCrtResourceTypeFunction
                                (PlayerManagerScript.instance.foods,
                                        PlayerManagerScript.instance.recoverFruits,
                                            PlayerManagerScript.instance.Woods,
                                                PlayerManagerScript.instance.Gold);
                        }

                    }

                    else
                        Debug.LogError("The Collective Divide Should Not Be Zero");

                    break;

                case ResourceCollectiveScript.ResourceType.Resource_Axings_Woods:

                    if (energyType.axeCollectTiming != 0)
                    {
                        switch (scoopEnumType)
                        {
                            case ScoopEnumType.Farmer:
                                wasteEnergy = 1.45f;
                                break;
                            case ScoopEnumType.Gathering:
                                wasteEnergy = 0.95f;

                                break;
                            case ScoopEnumType.Axe:

                                wasteEnergy = 0.65f;
                                break;


                        }


                        FarmingObject.SetActive(false);
                       

                        if (HammerObject != null)
                        {
                            HammerObject.SetActive(false);
                        }

                        if (WeaponObj != null)
                        {
                            WeaponObj.SetActive(false);
                        }





                        if (AxeObject != null)
                        {
                            AxeObject.SetActive(true);
                        }



                        CollectCrtTiming = Time.time + CollectDelayTiming / energyType.axeCollectTiming;

                        energyType.CrtSpirit -= wasteEnergy;




                        anim.SetBool(AnimisAxeingBooleanString, true);




                        resourceCollectiveScript.GatherAmounts((int)energyType.axeEnergy * 1);
                        GameObject InstanReceivedObjecPrefab =
                               Instantiate(ReceivedObject, resourceCollectiveScript.transform.position, Quaternion.identity);




                        TextMesh textMesh = InstanReceivedObjecPrefab.GetComponent<TextMesh>();

                        if (textMesh)
                        {
                            textMesh.text = "WOODS +" + ((int)energyType.axeEnergy * 1).ToString();
                        }

                        if (textMesh) 
                        {
                            textMesh.text = "";
                        }


                        if (resourceCollectiveScript.CrtAmount < 0)
                        {
                            resourceCollectiveScript.CrtAmount = 0;
                            SettingStatement(SCOOPENUMCrtStatement.IDLE);

                        }

                        if (UIManager.instance != null)
                        {
                            UIManager.instance.UpdateCrtResourceTypeFunction
                                (PlayerManagerScript.instance.foods,
                                        PlayerManagerScript.instance.recoverFruits,
                                            PlayerManagerScript.instance.Woods,
                                                PlayerManagerScript.instance.Gold);
                        }

                    }

                    else
                        Debug.LogError("The Collective Divide Should Not Be Zero");






                    break;

                case ResourceCollectiveScript.ResourceType.Resource_Gold:

                    if (energyType.axeCollectTiming != 0)
                    {
                        switch (scoopEnumType)
                        {
                            case ScoopEnumType.Farmer:
                                wasteEnergy = 1.75f;
                                break;
                            case ScoopEnumType.Gathering:

                                wasteEnergy = 2.4f;

                                break;

                            case ScoopEnumType.Axe:
                                
                                wasteEnergy = 1.3f;

                                break;


                        }

                        //if (AxeObject != null)
                        //{
                        //    AxeObject.SetActive(true);
                        //}



                        CollectCrtTiming = Time.time + CollectDelayTiming / energyType.axeCollectTiming;

                        //     energyType.CrtSpirit -= wasteEnergy;

                        FarmingObject.SetActive(false);


                        if (HammerObject != null)
                        {
                            HammerObject.SetActive(true);
                        }

                        if (WeaponObj != null)
                        {
                            WeaponObj.SetActive(false);
                        }





                        if (AxeObject != null)
                        {
                            AxeObject.SetActive(false);
                        }




                        anim.SetBool(AnimisHammeringBooleanString, true);




                        resourceCollectiveScript.GatherAmounts((int)energyType.axeEnergy * 1);

                        GameObject InstanReceivedObjecPrefab =
                    Instantiate(ReceivedObject, resourceCollectiveScript.transform.position, Quaternion.identity);




                        TextMesh textMesh = InstanReceivedObjecPrefab.GetComponent<TextMesh>();

                        if (textMesh)
                        {
                            textMesh.text = "GOLD +" + ((int)energyType.axeEnergy * 1).ToString();
                        }




                        if (resourceCollectiveScript.CrtAmount < 0)
                        {
                            resourceCollectiveScript.CrtAmount = 0;
                            SettingStatement(SCOOPENUMCrtStatement.IDLE);

                        }

                        if (UIManager.instance != null)
                        {
                            UIManager.instance.UpdateCrtResourceTypeFunction
                                (PlayerManagerScript.instance.foods,
                                        PlayerManagerScript.instance.recoverFruits,
                                            PlayerManagerScript.instance.Woods,
                                                PlayerManagerScript.instance.Gold);
                        }

                    }

                    else
                        Debug.LogError("The Collective Divide Should Not Be Zero");













                    break;
            }


            if (scoopCrtStatementScript.GetEmotionBubbleGameObject().gameObject.activeInHierarchy) 
            {
                scoopCrtStatementScript.SETWorkingSpriteFunction();




            }


           


        }

     //   StopCoroutine(DOTalkingIEmerator());


    }


    //Function : TalkingUpdateStatement
    //Method : This is the Function used For
    void TalkingUpdateStatement() 
    
    {

      //  Debug.Log("is In The Talking Update Statement ");

        if(HaveTalkingPLAYERObj == null) 
        {
            SettingStatement(SCOOPENUMCrtStatement.IDLE);
            StopCoroutine(DOTalkingIEmerator());
            return;

        }

        if(HaveTalkingPLAYERObj != null) 
        {

     ScoopScript sS =       HaveTalkingPLAYERObj.GetComponent<ScoopScript>();

            if (sS.isFarming) 
            {
                SettingStatement(SCOOPENUMCrtStatement.IDLE);

                
                StopCoroutine(DOTalkingIEmerator());


                return;
            }


        }

        if(TakeDamageBoolean)
        {
            StopCoroutine(DOTalkingIEmerator());



            return;
        }

        if(aiSoilderCtrlScript != null) 
        {

            SettingStatement(SCOOPENUMCrtStatement.Fighting);

            return;

        }

        if (energyType.CrtSpirit<=0) 
        {

            SettingStatement(SCOOPENUMCrtStatement.IDLE);
            return;
        }

        if(scoopEnum == SCOOPENUMCrtStatement.Farming) 
        {
            return;
        }


        if(aiSoilderCtrlScript == null) 
        {

            if (!HasStartTalkingIEmerator) 
        {
         
            



            StartCoroutine(DOTalkingIEmerator());
            HasStartTalkingIEmerator = true;

        }
        }
        else if(aiSoilderCtrlScript != null) 
        {
            SettingStatement(SCOOPENUMCrtStatement.MovToFighting);

        }


    }



    //Function : FightingUpdateStatement
    //Method : This is the Function used For Setting 
    //The Function 
    void FightingUpdateStatement() 
    {
        if (TakeDamageBoolean) 
        {
            return;
        }

        if(aiSoilderCtrlScript == null) 
        {

            SettingStatement(SCOOPENUMCrtStatement.IDLE);

            return;

        }
       
        
        
        
        if(aiSoilderCtrlScript != null) 
        {
            if (energyType.CrtSpirit > 0)
            {
                if (Time.time > attackCrtTimer)
                {
                    anim.SetBool(AnimisTalkingBooleanString, false);
                    attackCrtTimer = Time.time + attackDelayTimer;
                    switch (scoopEnumType)
                    {
                        case ScoopEnumType.Farmer:

                            energyType.fighterEnergy = Random.Range(16f, 19f);
                            break;

                        case ScoopEnumType.Gathering:
                            energyType.fighterEnergy = Random.Range(14.5f, 17f);

                            break;
                        case ScoopEnumType.Axe:
                            energyType.fighterEnergy = Random.Range(9.2f, 11.8f);


                            break;
                        case ScoopEnumType.Hammer:
                            energyType.fighterEnergy = Random.Range(6f, 7f);

                            break;



                    }









                    attackDelayTimer = energyType.fighterEnergy;







                    LOOKAT(aiSoilderCtrlScript.transform.position);
                    //  aiSoilderCtrlScript.TakeDamageFunction();
                    anim.SetTrigger(AnimAttackTriggerString);

                }

                scoopCrtStatementScript.SetAttackSpriteFunction();
              
                anim.SetBool(AnimisTalkingBooleanString, false);



            }
            else if (energyType.CrtSpirit <= 0)
            {
                SettingStatement(SCOOPENUMCrtStatement.IDLE);
            }





            if (aiSoilderCtrlScript.isDead) 
            {
                aiSoilderCtrlScript = null;
                SettingStatement(SCOOPENUMCrtStatement.IDLE);
                return;
            }




        }





        FarmingObject.SetActive(false);
        if (AxeObject != null)
        {
            AxeObject.SetActive(false);
        }

        if (HammerObject != null) 
        {
            HammerObject.SetActive(false);
        }


        movingToTalkingCrtStatement = 0.0f;

        StopCoroutine(DOTalkingIEmerator());


    }

    //Function : LOOKAT
    //Method : This is the Function is Use For Setting LookAT Statement
    void LOOKAT(Vector3 pos)
    {
        Vector3 dir = (pos - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;



     //   transform.rotation = Quaternion.Euler(0f, angle, 0f);


        transform.eulerAngles = new Vector3(0f,angle , 0f);
    }

    //Function : LookAtFunction
    //Method : This is the Function used 
    //For LookAtFunction 
    void LookAtFunction(Vector3 pos)  
    {
        transform.LookAt(pos,Vector3.up);

        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0.0f);

    }

    //Function : DODANCEIEnumerator 
    //Method : This is the Function that used For 
    // DO A Dacing IEnumerator 

    IEnumerator DODANCEIEnumerator() 
    {
        if (HasDoTheDanceStatement) 
        {
            yield break;
        }



        HasDoTheDanceStatement = true;

        anim.SetBool(AnimDODanceBoolean, true);


        if (isMoving || isFarming) 
        {
            anim.SetBool(AnimDODanceBoolean, false);
            yield break;
        
        }


      




        yield return new WaitForSeconds(3f);




        anim.SetBool(AnimDODanceBoolean, false);

        danceIemeratorCrtStatement = 0.0f;
        danceIEmeratorMaxStatement = Random.Range(3.5f, 5f);
        HasDoTheDanceStatement = false;




    }

    //IEumerator : DOTalkingIEmerator
    //Method : This is the IEnumerator
    //used For Scanned The DoTalking IEmerator 
    IEnumerator DOTalkingIEmerator() 
    {

        if (isTalkingBoolean) 
        {

            yield break;

        }





        isTalkingBoolean = true;
       



        if (isFarming)
        {
            SetTalkingBooleanStatement(false);



            isTalkingBoolean = false;
            HasStartTalkingIEmerator = false;
            movingToTalkingCrtStatement = 0;
            movingToTalkingMaxStatement = 15;
            SettingStatement(SCOOPENUMCrtStatement.Farming);


            yield break;

        }



        anim.SetBool(AnimisTalkingBooleanString, true);




        yield return new WaitForSeconds(3.0f);


    //    yield return new WaitForEndOfFrame();


        isTalkingBoolean = false;
        HasStartTalkingIEmerator = false;
        movingToTalkingCrtStatement = 0;
        movingToTalkingMaxStatement = 15;

      


     //   SettingStatement(SCOOPENUMCrtStatement.IDLE);

    }


    //Function : GetAnimatorFunction
    //Method : This is the Function Used For Getting The Animator Function 
    public Animator GetAnimatorFunction() 
    {
        if (anim != null)
            return anim;


        return null;
    }

    //Function : GetTiringStringFunction 
    //Method : This is the Function that used 
    //For Getting The Tiring String 
    public  string GetTiringStringFunction() 
    {
        return AnimisTiringBooleanString;
    }

    //Function : GetTalkingStringFunction()
    //Method : This is the Function that used 
    //For Getting The is Talking Statement 
    public string GetisTalkingStringFunction() 
    {
        return AnimisTalkingBooleanString;
    }
  
    public string GetEquipWeaponStringFunction() 
    {

        return AnimEQUIPWEAPONBooleanString;
    }




    //Function : SetTalkingBooleanStatement
    //Method : This is the Function used it to 
    //Set Talking Boolean To True Or False
 public   void SetTalkingBooleanStatement(bool talkingboolean) 
    {
        anim.SetBool(AnimisTalkingBooleanString,talkingboolean);



    }

    //Function : ATTACK Function 
    //Method : This is the Function used To 
    //Setting Attack Statement 
    public void ATTACKFunction() 
    {
        if(aiSoilderCtrlScript== null) 
        {
            return;
        }

        aiSoilderCtrlScript.TakeDamageFunction();
        aiSoilderCtrlScript.SetScoopScriptFunction(this);





    }

    //Function : TakeDamageFunction 
    //Method : This is the Function used To Check The Take DamageFunction 

    public void TakeDamageFunction() 
    {
        TakeDamageBoolean = true;
  //      Debug.Log("You Have Been Take Damage ");






        if (HasWeaponBoolean)
            energyType.CrtHP--;
        else
            energyType.CrtHP -= 2;


        if(energyType.CrtHP <= 0) 
        {
            isDead = true;
           if( PlayerManagerScript.instance.scoopScriptList.Contains(this))
            {
                if(SelectedScoopScript.instance.scoopListScript.Contains(this))
                {
                    PlayerManagerScript.instance.scoopScriptList.Remove(this);
                    SelectedScoopScript.instance.scoopListScript.Remove(this);
                }


            }
        }







      if (anim.GetBool(AnimEQUIPWEAPONBooleanString) == true) 
        {
            if (!isDead) 
            {

                anim.SetTrigger(AnimGetTriggerString);

            }



           
        }

        if (isDead)         
        {
            anim.Play(AnimDEATHString);
            anim.applyRootMotion = true;
            rgbd.useGravity = false;

            aiSoilderCtrlScript = null;

            switch (scoopEnumType) 
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


            PlayerManagerScript.instance.UpdateCurrentTheCostAndCountHavePassedFunction();




            Destroy(capCollider);

            StartCoroutine(DeadIEnumerator());

            if(scoopCrtStatementScript.GetEmotionBubbleGameObject() != null) 
            {
                scoopCrtStatementScript.GetEmotionBubbleGameObject().gameObject.SetActive(false);



            }




            if(HasBeenSelectorObject.activeInHierarchy)
                HasBeenSelectorObject.SetActive(false);
        }

    }

    //IEnumerator : DeadIEnumerator
    //Method : This is the Function that used 
    //For Checking The Dead IEnumerator
    IEnumerator DeadIEnumerator() 
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(rgbd);

        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);




    }

    //Function : GETHITEXITSTATEMENT
    //Method : This is the Function used
    //For Get HIT Exit Statement From The 
    public void GETHITEXITSTATEMENT() 
    {
        TakeDamageBoolean = false;


    }

}
