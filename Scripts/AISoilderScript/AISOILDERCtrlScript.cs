using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;







[RequireComponent(typeof(StateMachineScript))]
public class AISOILDERCtrlScript : MonoBehaviour
{
  
    private static string ANIMGetHitString = "GETHIT";
    private static string AnimDeathString = "Death";
    private static string AnimisMovingString = "MovForward";
    private static string AnimDoAttackString = "AttackTrigger";

    Rigidbody rgbd;
    CapsuleCollider capColl;
    NavMeshAgent navMeshAgent;

    Animator anim;

    StateMachineScript stateMachineScript;
    AISoilderUIManager aiSoilderUIManager;




    public float CrtHealth,
        MaxHealth = 20;



    float AttackCrtTimer = 0.0f;
    public float AttackMaxTimer;


    [HideInInspector]
    public bool HasGetHit = false;


    [HideInInspector]
    public bool isDead = false;

 
    float damageEarn;
    float recoverCrtTimer;
    float recoverMaxTimer;
    float changeMindRandMovCrtTimer;
    float changeMindRandMovMaxTimer;

    ScoopScript scoopScript;
    [SerializeField] TextMesh textMesh;

    [SerializeField] GameObject InstanAskingCubeBoxObjects;

    InstanEnemiesScirpt instanEnemyBoxCollider;

   



    private void Awake()
    {
        GetComponentFunction();
    }
    
    //Function : GetComponentFunction
    //Method : This is the Function used For Getting The Component Function
    void GetComponentFunction() 
    {
        rgbd = GetComponent<Rigidbody>();
        capColl = GetComponent<CapsuleCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stateMachineScript = GetComponent<StateMachineScript>();
        aiSoilderUIManager = GetComponentInChildren<AISoilderUIManager>();

    }


    private void Start()
    {
        SettingBasicInformationFunction();
    }


//Function : SettingBasicInformationFunction
    //Method : This is the Function used 
    //For Setting Basic Information 
    void SettingBasicInformationFunction() 
    {

        for (int i = 0; i < GameManager.instance.lvl1UnlockEnemiesCount.Count; i++)
        {
            GameManager.instance.lvl1UnlockEnemiesCount[i].MaxHealth =
                GameManager.instance.lvl1UnlockEnemiesCount[i].CrtHealth= Random.Range(3, 5);


        }


        for (int i = 0; i < GameManager.instance.lvl2UnlockEnemiesCount.Count; i++)
        {
            GameManager.instance.lvl2UnlockEnemiesCount[i].MaxHealth =
          GameManager.instance.lvl2UnlockEnemiesCount[i].CrtHealth = Random.Range(6,8);

        }

        for (int i = 0; i < GameManager.instance.lvl3UnlockEnemiesCount.Count; i++)
        {

            GameManager.instance.lvl3UnlockEnemiesCount[i].MaxHealth =
       GameManager.instance.lvl3UnlockEnemiesCount[i].CrtHealth = Random.Range(9, 11);




        }

        for (int i = 0; i < GameManager.instance.lvl4UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl4UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl4UnlockEnemyCount[i].MaxHealth = Random.Range(6,12);

        }

        for (int i = 0; i < GameManager.instance.lvl5UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl5UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl5UnlockEnemyCount[i].MaxHealth = Random.Range(9, 15);
        }

        for (int i = 0; i < GameManager.instance.lvl6UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl6UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl6UnlockEnemyCount[i].MaxHealth = Random.Range(13, 18);
        }

        for (int i = 0; i < GameManager.instance.lvl7UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl7UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl7UnlockEnemyCount[i].MaxHealth = Random.Range(16, 19);
        }

        for (int i = 0; i < GameManager.instance.lvl9UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl9UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl9UnlockEnemyCount[i].MaxHealth = Random.Range(17, 20);
        }

        for (int i = 0; i < GameManager.instance.lvl10UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl10UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl10UnlockEnemyCount[i].MaxHealth = Random.Range(12, 15);
        }

        for (int i = 0; i < GameManager.instance.lvl11UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl11UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl11UnlockEnemyCount[i].MaxHealth = Random.Range(13, 16);
        }

        for (int i = 0; i < GameManager.instance.lvl12UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl12UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl12UnlockEnemyCount[i].MaxHealth = Random.Range(9, 16);
        }

        for (int i = 0;i < GameManager.instance.lvl14UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl14UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl14UnlockEnemyCount[i].MaxHealth = Random.Range(6, 13);
        }

        for (int i = 0; i < GameManager.instance.lvl15UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl15UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl15UnlockEnemyCount[i].MaxHealth = Random.Range(12, 15);
        }

        for (int i = 0; i < GameManager.instance.lvl16UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl16UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl16UnlockEnemyCount[i].MaxHealth = Random.Range(16, 19);
        }

        for (int i = 0; i < GameManager.instance.lvl17UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl17UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl17UnlockEnemyCount[i].MaxHealth = Random.Range(8, 12);
        }

        for (int i = 0; i < GameManager.instance.lvl18UnlockEnemyCount.Count; i++)
        {
            GameManager.instance.lvl18UnlockEnemyCount[i].CrtHealth = GameManager.instance.lvl18UnlockEnemyCount[i].MaxHealth = Random.Range(8, 21);
        }


        for (int i = 0; i < GameManager.instance.GetInstanSoilderCtrlListFunction().Count; i++)
        {
            GameManager.instance.GetInstanSoilderCtrlListFunction()[i].CrtHealth = GameManager.instance.GetInstanSoilderCtrlListFunction()[i].MaxHealth = Random.Range(25, 35);


        }





        // CrtHealth = MaxHealth = Random.Range(10,15);
        AttackCrtTimer = AttackMaxTimer = Random.Range(8.0f, 9.1f);
        changeMindRandMovCrtTimer = changeMindRandMovMaxTimer = Random.Range(6.2f, 9.8f);





        stateMachineScript.PushStateFunction(IdleEnterStatementFunction, 
            IdleExitStatementFunction, 
            IdleUpdateStatementFunction);


        aiSoilderUIManager.UpdateHealthAmountFunction(CrtHealth, MaxHealth);

    }

    //Function : TakeDamageFunction 
    //Method : This is the Function used For 
    //Taking The Damage Function 
    public void TakeDamageFunction() 
    {
        //     Debug.Log("This Function is mainly used For Taking The Damage ");

    damageEarn = Random.Range(1,3);

      
            CrtHealth -= damageEarn;



        aiSoilderUIManager.UpdateHealthAmountFunction(CrtHealth, MaxHealth);




        
       if (CrtHealth <=0) 
        {
            anim.ResetTrigger(ANIMGetHitString);
            isDead = true;

        }

        if (!isDead)
            anim.SetTrigger(ANIMGetHitString);


        HasGetHit = true;



    }

    //Function : HURTEXITSTATEMENT
    //Method : This is the Function that used 
    //For Setting The Exit Statement for which is used
    //For Animator ExitStatement 
    public void HURTEXITSTATEMENT() 
    {

 //       Debug.Log("Has Enter The Exit Statement ");

        HasGetHit = false;


    }


    //Function : ATTACKFunction 

        //Method : This isThe Function 
       //used For Attack The Function 
    public void ATTACKFunction() 
    {
        if(scoopScript == null) 
        {
            return;
        }

        scoopScript.TakeDamageFunction();



    }

    //Function : IdleEnterStatementFunction 
    //Method : This is the Function used For Setting  Idle 
    //EnterStatement 
    void IdleEnterStatementFunction() 
    {
      //  Debug.Log("IdleEnterStatement ");
     if(scoopScript == null) 
        { 
            textMesh.text = "Idle";

        }
        
        
       




    }
    
    //Function : IdleUpdateStatementFunction
    //Method : This is the Function used For UpdateStatementFunction 
    void IdleUpdateStatementFunction() 
    {

        if (HasGetHit) 
        {
            if (CrtHealth > 0)
            {


                stateMachineScript.PushStateFunction(GetHitEnterStatementFunction, GetHitExitStatementFunction, GetHitUpdateStatementFunction);

            }
            else if (CrtHealth <= 0) 
            {
                stateMachineScript.PushStateFunction(DeadEnterStatement, null, null);

            }
                  
            return;

        }


        if (scoopScript == null)
        {

            changeMindRandMovCrtTimer -= Time.deltaTime;

            if (changeMindRandMovCrtTimer <= 0)
            {
                stateMachineScript.PushStateFunction(WanderEnterStatementFunction, WanderExitStatementFunction, WanderUpdateStatementFunction);
            }




        }
        else if(scoopScript != null) 
        {

            stateMachineScript.PushStateFunction(MovToAttackEnterFunction, MovToAttackExitFunction, MovToAttackUpdateFunction);


        }
    }

    //Function : IdleExitStatementFunction
    //This Function is used For Setitng 
    //The Idle Statement 

    void IdleExitStatementFunction() 
    {


        if (HasGetHit) 
        {
            recoverMaxTimer = Random.Range(1.5f, 2.4f);
            recoverCrtTimer = recoverMaxTimer;

        }






    }


    //Function : GetHitEnterStatementFunction
    //Method : This is the Function used For Setting GetHit Enter Statement 
    //Function 
    void GetHitEnterStatementFunction() 
    {
      //  Debug.Log("get Hit Enter Has Enter The Statement ");

        navMeshAgent.isStopped = true;
        navMeshAgent.ResetPath();
        
     






    }

    //Function : GetHitUpdateStatementFunction
    //Method : This is the Function used For GetHit Update Statement 
    //
    void GetHitUpdateStatementFunction() 
    {
        if(CrtHealth <= 0) 
        {
            stateMachineScript.PushStateFunction(DeadEnterStatement,null,null);



            return;
        }
        
        if(scoopScript != null) 
        {
            stateMachineScript.PushStateFunction(MovToAttackEnterFunction,MovToAttackExitFunction,MovToAttackUpdateFunction);

            return;
        }
        







        Debug.Log("Get Hit Update Statement ");

    }


    //Function : GetHitExitStatementFunction
    //Method : This is the Function that used
    //For Setting Get Hit Exit Statement 
    void GetHitExitStatementFunction() 
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.ResetPath();
    }
    
  //Function : WanderEnterStatementFunction 
        //Method : This is the Function that used 
            //For Wander Enter Statement Function 
    void WanderEnterStatementFunction() 
    {


        anim.SetBool(AnimisMovingString, true);
        Vector3 randomDir = (Random.insideUnitSphere *0.5f) + transform.position;
        NavMeshHit navMeshHit;

        NavMesh.SamplePosition(randomDir, out navMeshHit, 1.2f, NavMesh.AllAreas);
        Vector3 destination = navMeshHit.position;
        navMeshAgent.isStopped = false;
        navMeshAgent.stoppingDistance = 0.0f;
        navMeshAgent.SetDestination(destination);

        if(scoopScript == null) 
        {
            textMesh.text = "Wander";
        }




    }

    //Function : WanderUpdateStatementFunction
    //Method : This is the Function used For Wander Update Statement 

    void WanderUpdateStatementFunction() 
    {
        if (HasGetHit) 
        {
            anim.SetBool(AnimisMovingString, false);
            stateMachineScript.PushStateFunction(GetHitEnterStatementFunction, GetHitExitStatementFunction, GetHitUpdateStatementFunction);  
            return;


        }
        if(scoopScript != null) 
        {
            stateMachineScript.PushStateFunction(IdleEnterStatementFunction,IdleExitStatementFunction,IdleUpdateStatementFunction);


            return;
        }






        if (navMeshAgent.remainingDistance <= 0.25f)
        {
            changeMindRandMovCrtTimer = Random.Range(2.4f, 4.3f);
            navMeshAgent.ResetPath();
           stateMachineScript.PushStateFunction(IdleEnterStatementFunction, 
                                                        IdleExitStatementFunction,IdleUpdateStatementFunction);

        }






    }

    //Function : WanderExitStatementFunction
    //Method : This is the Function that used For Wander Exit Statement

    void WanderExitStatementFunction() 
    {

        anim.SetBool(AnimisMovingString, false);
    }

    //Function : MovToAttackEnterFunction
    //Method : This is the Function used 
    //For Attack 
    void MovToAttackEnterFunction() 
    {
        navMeshAgent.stoppingDistance = 1f;
        navMeshAgent.isStopped = false;

        anim.SetBool(AnimisMovingString,true);




        if(scoopScript != null) 
        {

            textMesh.text = "Attacking";



            navMeshAgent.SetDestination(scoopScript.gameObject.transform.position);
        }
        else if(scoopScript == null) 
        {
            textMesh.text = "IDLE";


            stateMachineScript.PushStateFunction(IdleEnterStatementFunction, IdleExitStatementFunction, IdleUpdateStatementFunction);
            return;
        }


    }

    //Function : MovToAttackUpdateFunction
        //Method : Mov To Attack Player Statement  Update
    void MovToAttackUpdateFunction() 
    {
        if (isDead) 
        {
            stateMachineScript.PushStateFunction(DeadEnterStatement, null,null) ;

            return;

        }
        
        
        if(scoopScript == null) 
        {
            stateMachineScript.PushStateFunction(IdleEnterStatementFunction, IdleExitStatementFunction, IdleUpdateStatementFunction);

            return;
        }

        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) 
        {
        //  Debug.Log("This is the Function used For Setting The Attack Statement ");
            stateMachineScript.PushStateFunction(AttackEnterStatementFunction, AttackExitStatementFunction, AttackUpdateStatementFunction);



        }


        float distanceWithPlayer = Vector3.Distance(this.transform.position,scoopScript.transform.position);



        if(distanceWithPlayer > 5.0f) 
        {
            scoopScript = null;
        }
        else if(distanceWithPlayer > 2.5f && distanceWithPlayer <= 5.0f) 
        {
            stateMachineScript.PushStateFunction(IdleEnterStatementFunction, IdleExitStatementFunction, IdleUpdateStatementFunction);

        }


    }

    //Function : MovToAttackExitFunction
    //Method : Mov To Attack Player Statement  Exit Statement 

    void MovToAttackExitFunction() 
    {
        anim.SetBool(AnimisMovingString, false);
    }

    //Function : AttackEnterStatementFunction
    //Method : This Function is used For Attack Enter Statement 
    void AttackEnterStatementFunction() 
    {
      //  Debug.Log("Attack Player Enter Statement ");


        navMeshAgent.isStopped = true;
        navMeshAgent.ResetPath();

        if (scoopScript != null) 
        {
            textMesh.text = "ATTACK";
        }



    }

    //Function : AttackUpdateStatementFunction 

    //Method : This Function is used For Attack Update Statement 
    void AttackUpdateStatementFunction() 
    
    {
        if(scoopScript == null) 
        {

            stateMachineScript.PushStateFunction(IdleEnterStatementFunction, IdleExitStatementFunction, IdleUpdateStatementFunction);

            return;
        }

        float WithPlayerDistance = Vector3.Distance(this.transform.position,scoopScript.transform.position);

        if(WithPlayerDistance > 1.0f) 
        {
            stateMachineScript.PushStateFunction(MovToAttackEnterFunction, MovToAttackExitFunction, MovToAttackUpdateFunction);

        }
        else if(WithPlayerDistance <= 1.0f) 
        {
        //   Debug.Log("Attack Player Distance Between 1.0f ");
            if (!isDead) 
            {


            if (!HasGetHit) 
            {
                AttackCrtTimer -= Time.deltaTime;

                if(AttackCrtTimer <= 0) 
                {
                    if (!scoopScript.isDead) 
                    {
                        anim.SetTrigger(AnimDoAttackString);

                        AttackMaxTimer = Random.Range(8.0f, 12.0f);
                        AttackCrtTimer = AttackMaxTimer;
                    }
                    else 
                    {
                        scoopScript = null;
                    }


                

                }

            }



            }
            else 
            {

                stateMachineScript.PushStateFunction(DeadEnterStatement, null, null);



            }





        }

    }

    //Function : AttackExitStatementFunction
    //Method : This Function is used Fpr Attack Exit Statement 
    void AttackExitStatementFunction() 
    {

    }

    //Function : DeadEnterStatement
    //Method : This is the Function that used 
    //For Dead Enter Statement 
    void DeadEnterStatement()
    {
        anim.applyRootMotion = true;
        anim.Play(AnimDeathString);



        if (GameManager.instance.lvl1UnlockEnemiesCount.Contains(this))
        {

            GameManager.instance.lvl1UnlockEnemiesCount.Remove(this);
        }

        if (GameManager.instance.lvl2UnlockEnemiesCount.Contains(this))
        {
            GameManager.instance.lvl2UnlockEnemiesCount.Remove(this);


        }

        if (GameManager.instance.lvl3UnlockEnemiesCount.Contains(this))
        {
            GameManager.instance.lvl3UnlockEnemiesCount.Remove(this);


        }

        if (GameManager.instance.lvl4UnlockEnemyCount.Contains(this)) 
        {

            GameManager.instance.lvl4UnlockEnemyCount.Remove(this);
        }

        if (GameManager.instance.lvl5UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl5UnlockEnemyCount.Remove(this);
        }

        if (GameManager.instance.lvl6UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl6UnlockEnemyCount.Remove(this);
        }

        if (GameManager.instance.lvl7UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl7UnlockEnemyCount.Remove(this);

        }

        if (GameManager.instance.lvl9UnlockEnemyCount.Contains(this)) 
        {

            GameManager.instance.lvl9UnlockEnemyCount.Remove(this);


        }

        if (GameManager.instance.lvl10UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl10UnlockEnemyCount.Remove(this);
        }

        if (GameManager.instance.lvl11UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl11UnlockEnemyCount.Remove(this);
        }

        if (GameManager.instance.lvl12UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl12UnlockEnemyCount.Remove(this);
        }

        if (GameManager.instance.lvl14UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl14UnlockEnemyCount.Remove(this);
        }

        if (GameManager.instance.lvl15UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl15UnlockEnemyCount.Remove(this);
        }

        if (GameManager.instance.lvl16UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl16UnlockEnemyCount.Remove(this);
        }

        if (GameManager.instance.lvl17UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl17UnlockEnemyCount.Remove(this);
        }

        if (GameManager.instance.lvl18UnlockEnemyCount.Contains(this)) 
        {
            GameManager.instance.lvl18UnlockEnemyCount.Remove(this);
        }






        if (GameManager.instance.GetInstanSoilderCtrlListFunction().Contains(this)) 
        {
             GameManager.instance.GetInstanSoilderCtrlListFunction().Remove(this);
        }


        PlayerManagerScript.instance.Gold += Random.Range(3, 6);

        CheckTheCurrentStatementToZeroFunction();

        UIManager.instance.UpdateCrtResourceTypeFunction
            (PlayerManagerScript.instance.foods,
                    PlayerManagerScript.instance.recoverFruits,
                        PlayerManagerScript.instance.Woods,
                            PlayerManagerScript.instance.Gold);











        rgbd.useGravity = false;

        Destroy(navMeshAgent);


        Destroy(capColl);

        StartCoroutine(DeadIEnumerator());

    }

    //Function : CheckTheCurrentStatementToZeroFunction
    //Method : This is the Function used 
    //For Checking The Current Statement To Zero
    private void CheckTheCurrentStatementToZeroFunction()
    {
        if (GameManager.instance.lvl1UnlockEnemiesCount.Count <=0)
        {
          
            if (instanEnemyBoxCollider.isStage1)
            {
                instanEnemyBoxCollider.Unlocked = true;

                UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();



                if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = true;
                    UIManager.instance.GetNoButtonFunction().interactable = true;


                }
                else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = false;
                    UIManager.instance.GetNoButtonFunction().interactable = true;

                }





            }

     
           // SelectedScoopScript.instance.SetAskingCubeObject(askingCube);




        }

        if (GameManager.instance.lvl2UnlockEnemiesCount.Count <= 0)
        {

            if (instanEnemyBoxCollider.isStage2)
            {
                instanEnemyBoxCollider.Unlocked = true;

                UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();



                if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = true;
                    UIManager.instance.GetNoButtonFunction().interactable = true;


                }
                else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = false;
                    UIManager.instance.GetNoButtonFunction().interactable = true;

                }





            }
        //    instanEnemyBoxCollider.SetAskingCubeBoxFunction(askingCube);

        }

        if(GameManager.instance.lvl3UnlockEnemiesCount.Count <= 0) 
        {

            if (instanEnemyBoxCollider.isStage3) 
            {

                instanEnemyBoxCollider.Unlocked = true;

                UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();



                if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = true;
                    UIManager.instance.GetNoButtonFunction().interactable = true;


                }
                else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = false;
                    UIManager.instance.GetNoButtonFunction().interactable = true;

                }

            }



         



        }

        if(GameManager.instance.lvl4UnlockEnemyCount.Count <= 0) 
        {
            if (instanEnemyBoxCollider.isStage4)
            {

                instanEnemyBoxCollider.Unlocked = true;

                UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();



                if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = true;
                    UIManager.instance.GetNoButtonFunction().interactable = true;


                }
                else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = false;
                    UIManager.instance.GetNoButtonFunction().interactable = true;

                }

            }



     


        }

        if(GameManager.instance.lvl5UnlockEnemyCount.Count <= 0) 
        {
            if (instanEnemyBoxCollider.isStage5) 
            {
                instanEnemyBoxCollider.Unlocked = true;
                UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();



                if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = true;
                    UIManager.instance.GetNoButtonFunction().interactable = true;


                }
                else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = false;
                    UIManager.instance.GetNoButtonFunction().interactable = true;

                }




            }

         

        }

        if (GameManager.instance.lvl6UnlockEnemyCount.Count <= 0)
        {
            if (instanEnemyBoxCollider.isStage6)
            {
                instanEnemyBoxCollider.Unlocked = true;
                UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();



                if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = true;
                    UIManager.instance.GetNoButtonFunction().interactable = true;


                }
                else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = false;
                    UIManager.instance.GetNoButtonFunction().interactable = true;

                }




            }

        }

        if (GameManager.instance.lvl7UnlockEnemyCount.Count <= 0)
        {
            if (instanEnemyBoxCollider.isStage7)
            {
                instanEnemyBoxCollider.Unlocked = true;
                UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();



                if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = true;
                    UIManager.instance.GetNoButtonFunction().interactable = true;


                }
                else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
                {
                    UIManager.instance.GetYesButtonFunction().interactable = false;
                    UIManager.instance.GetNoButtonFunction().interactable = true;

                }




            }




        }

        if(GameManager.instance.lvl9UnlockEnemyCount.Count <= 0) 
        {
            instanEnemyBoxCollider.Unlocked = true;
            UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();



            if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = true;
                UIManager.instance.GetNoButtonFunction().interactable = true;


            }
            else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = false;
                UIManager.instance.GetNoButtonFunction().interactable = true;

            }


        }

        if (GameManager.instance.lvl10UnlockEnemyCount.Count <= 0)
        {
            instanEnemyBoxCollider.Unlocked = true;
            UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();



            if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = true;
                UIManager.instance.GetNoButtonFunction().interactable = true;


            }
            else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = false;
                UIManager.instance.GetNoButtonFunction().interactable = true;

            }


        }

        if (GameManager.instance.lvl11UnlockEnemyCount.Count <= 0)
        {
            instanEnemyBoxCollider.Unlocked = true;
            UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();



            if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = true;
                UIManager.instance.GetNoButtonFunction().interactable = true;


            }
            else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = false;
                UIManager.instance.GetNoButtonFunction().interactable = true;

            }


        }

        if (GameManager.instance.lvl12UnlockEnemyCount.Count <= 0) 
        {
            instanEnemyBoxCollider.Unlocked = true;
            UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();

            if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = true;
                UIManager.instance.GetNoButtonFunction().interactable = true;


            }
            
            else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = false;
                UIManager.instance.GetNoButtonFunction().interactable = true;

            }


        }
        
        if (GameManager.instance.lvl14UnlockEnemyCount.Count <= 0)
        {
            instanEnemyBoxCollider.Unlocked = true;
            UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();

            if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = true;
                UIManager.instance.GetNoButtonFunction().interactable = true;


            }

            else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = false;
                UIManager.instance.GetNoButtonFunction().interactable = true;

            }


        }

        if (GameManager.instance.lvl15UnlockEnemyCount.Count <= 0) 
        {
            instanEnemyBoxCollider.Unlocked = true;
            UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();

            if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = true;
                UIManager.instance.GetNoButtonFunction().interactable = true;


            }

            else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = false;
                UIManager.instance.GetNoButtonFunction().interactable = true;

            }
        }

        if(GameManager.instance.lvl16UnlockEnemyCount.Count <= 0) 
        {
            instanEnemyBoxCollider.Unlocked = true;
            UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();

            if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = true;
                UIManager.instance.GetNoButtonFunction().interactable = true;


            }

            else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = false;
                UIManager.instance.GetNoButtonFunction().interactable = true;

            }

        }

        if (GameManager.instance.lvl17UnlockEnemyCount.Count <= 0) 
        {
            instanEnemyBoxCollider.Unlocked = true;
            UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();

            if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = true;
                UIManager.instance.GetNoButtonFunction().interactable = true;


            }

            else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = false;
                UIManager.instance.GetNoButtonFunction().interactable = true;

            }



        }

        if (GameManager.instance.lvl18UnlockEnemyCount.Count <= 0) 
        {
            instanEnemyBoxCollider.Unlocked = true;
            UIManager.instance.GetGoldenCostTextFunction().text = "Golden Has To Cost :" + instanEnemyBoxCollider.GoldenCost.ToString();

            if (PlayerManagerScript.instance.Gold >= instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = true;
                UIManager.instance.GetNoButtonFunction().interactable = true;


            }

            else if (PlayerManagerScript.instance.Gold < instanEnemyBoxCollider.GoldenCost)
            {
                UIManager.instance.GetYesButtonFunction().interactable = false;
                UIManager.instance.GetNoButtonFunction().interactable = true;

            }


        }






        if (instanEnemyBoxCollider.Unlocked) 
        {
            GameObject InstanCubeBox = Instantiate(InstanAskingCubeBoxObjects, new Vector3(instanEnemyBoxCollider.transform.position.x, 2.38f, instanEnemyBoxCollider.transform.position.z), Quaternion.identity);
            AskingCubeBoxScript askingCube = InstanCubeBox.GetComponent<AskingCubeBoxScript>();

            SelectedScoopScript.instance.SetAskingCubeObject(askingCube);





        }

    }

    //IEnumerator : DeadIEnumerator
    //Method : This is the Function used For
    //Setting The Dead IEnumerator 
    IEnumerator DeadIEnumerator() 
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(rgbd);


        yield return new WaitForSeconds(3.0f);

        Destroy(this.gameObject);


    }


    //Function : SetScoopScriptFunction
    //Method : this is the Function used For Setting The 
    public void SetScoopScriptFunction(ScoopScript scoop = null) 
    {


        scoopScript = scoop;




    }



    //Function : InstanboxColliderScript

        //Method : This is the Function used For Insgtane The Box Collider 
    public void InstanboxColliderScript(InstanEnemiesScirpt instan = null) 
    {
        instanEnemyBoxCollider = instan;
    }

    //AISoilderUIManager : GetAISoilderManager 
    //Method : 
    public AISoilderUIManager GetAISoilderManager() 
    {
        return aiSoilderUIManager; 
    }



}
