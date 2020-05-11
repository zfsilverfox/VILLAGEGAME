using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanEnemiesScirpt : MonoBehaviour
{

    public bool Unlocked = false;

    public int CrtCount ;
    public bool isStage1 = false;
    public bool isStage2 = false;
    public bool isStage3 = false;
    public bool isStage4 = false;
    public bool isStage5 = false;
    public bool isStage6 = false;
    public bool isStage7 = false;
    public bool isStage8= false;
    public bool isStage9 = false;
    public bool isStage10 = false;
    public bool isStage11 = false;
    public bool isStage12 = false;
    public bool isStage13 = false;
    public bool isStage14 = false;
    public bool isStage15 = false;
    public bool isStage16 = false;
    public bool isStage17 = false;
    public bool isStage18 = false;
    public bool isStage19 = false;








    AskingCubeBoxScript askingCubeBoxScript;

    public int GoldenCost;


    private void Start()
    {

        InstanEnemyFunction();
    }



    //Function : InstanEnemyFunction
        //Method : This is the Function that used 
            //For InstanEnemyFunction 
 public   void InstanEnemyFunction() 
    {

    

   Vector3     vector3 = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f),
                                            transform.position.y,
                                                transform.position.z + Random.Range(-1.5f, 1.5f));

     


        if (!Unlocked) 
        {

            if (isStage1) 
            {
                if (GameManager.instance.lvl1UnlockEnemiesCount.Count < CrtCount)
                {

                    for (int i = GameManager.instance.lvl1UnlockEnemiesCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());



                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();


                        aiSoilderScript.InstanboxColliderScript(this);











                        GameManager.instance.lvl1UnlockEnemiesCount.Add(aiSoilderScript);

                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 1 ");





                    }



                }




            }

            else if (isStage2) 
            {

                if (GameManager.instance.lvl2UnlockEnemiesCount.Count < CrtCount)
                {

                    for (int i = GameManager.instance.lvl2UnlockEnemiesCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());



                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();


                        aiSoilderScript.InstanboxColliderScript(this);


                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 2");








                        GameManager.instance.lvl2UnlockEnemiesCount.Add(aiSoilderScript);







                    }



                }




            }
            else if (isStage3) 
            {

                if(GameManager.instance.lvl3UnlockEnemiesCount.Count< CrtCount) 
                {

                    for (int i = GameManager.instance.lvl3UnlockEnemiesCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());



                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();


                        aiSoilderScript.InstanboxColliderScript(this);

                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 3");









                        GameManager.instance.lvl3UnlockEnemiesCount.Add(aiSoilderScript);







                    }




                }







            }
            else if (isStage4) 
            {

              if(GameManager.instance.lvl4UnlockEnemyCount.Count < CrtCount) 
                {
                    for (int i = GameManager.instance.lvl4UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());



                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 4");

                        aiSoilderScript.InstanboxColliderScript(this);











                        GameManager.instance.lvl4UnlockEnemyCount.Add(aiSoilderScript);


                    }







                }







            }
            else if (isStage5) 
            {
                if(GameManager.instance.lvl5UnlockEnemyCount.Count< CrtCount) 
                {
                    for (int i = GameManager.instance.lvl5UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());



                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 5");

                        aiSoilderScript.InstanboxColliderScript(this);











                        GameManager.instance.lvl5UnlockEnemyCount.Add(aiSoilderScript);


                    }






                }



            }
            else if (isStage6) 
            {

                if (GameManager.instance.lvl6UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl6UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());



                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 6");

                        aiSoilderScript.InstanboxColliderScript(this);











                        GameManager.instance.lvl6UnlockEnemyCount.Add(aiSoilderScript);


                    }






                }












            }
            else if (isStage7) 
            {
                if (GameManager.instance.lvl7UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl7UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());
                      


                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
  aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 7");

                        aiSoilderScript.InstanboxColliderScript(this);











                        GameManager.instance.lvl7UnlockEnemyCount.Add(aiSoilderScript);


                    }






                }












            }
            else if (isStage8) 
            {
                HaveLevelToUnlockThisGroundScript haveLevelToUnlock = GetComponent<HaveLevelToUnlockThisGroundScript>();


                haveLevelToUnlock.isUnlock =Unlocked ;
                GoldenCost = haveLevelToUnlock.Cost;



            }
            else if (isStage9) 
            {
                if (GameManager.instance.lvl9UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl9UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());



                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 9");

                        aiSoilderScript.InstanboxColliderScript(this);

                        GameManager.instance.lvl9UnlockEnemyCount.Add(aiSoilderScript);

                    }






                }




            }
            else if (isStage10) 
            {
                if (GameManager.instance.lvl10UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl10UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());

                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 10");

                        aiSoilderScript.InstanboxColliderScript(this);

                        GameManager.instance.lvl10UnlockEnemyCount.Add(aiSoilderScript);

                    }






                }










            }
            else if(isStage11)
            {

                if (GameManager.instance.lvl11UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl11UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());

                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 10");

                        aiSoilderScript.InstanboxColliderScript(this);

                        GameManager.instance.lvl11UnlockEnemyCount.Add(aiSoilderScript);

                    }

                }

            }
            else if (isStage12) 
            {
                if (GameManager.instance.lvl12UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl12UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());

                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 12");

                        aiSoilderScript.InstanboxColliderScript(this);

                        GameManager.instance.lvl12UnlockEnemyCount.Add(aiSoilderScript);

                    }

                }


            }
            else if (isStage13) 
            {
                HaveLevelToUnlockThisGroundScript haveLevelToUnlock = GetComponent<HaveLevelToUnlockThisGroundScript>();


                haveLevelToUnlock.isUnlock = Unlocked;
                GoldenCost = haveLevelToUnlock.Cost;



            }
            else if (isStage14) 
            {
                if (GameManager.instance.lvl14UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl14UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());

                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 14");

                        aiSoilderScript.InstanboxColliderScript(this);

                        GameManager.instance.lvl14UnlockEnemyCount.Add(aiSoilderScript);

                    }

                }








            }
            else if (isStage15) 
            {
                if (GameManager.instance.lvl15UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl15UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());

                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 15");

                        aiSoilderScript.InstanboxColliderScript(this);

                        GameManager.instance.lvl15UnlockEnemyCount.Add(aiSoilderScript);

                    }

                }



            }
            else if (isStage16) 
            {
                if (GameManager.instance.lvl16UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl16UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());

                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 16");

                        aiSoilderScript.InstanboxColliderScript(this);

                        GameManager.instance.lvl16UnlockEnemyCount.Add(aiSoilderScript);

                    }

                }




            }
            else if (isStage17) 
            {
                if (GameManager.instance.lvl17UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl17UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());

                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 17");

                        aiSoilderScript.InstanboxColliderScript(this);

                        GameManager.instance.lvl17UnlockEnemyCount.Add(aiSoilderScript);

                    }

                }


            }
            else if(isStage18)
            {
                if (GameManager.instance.lvl18UnlockEnemyCount.Count < CrtCount)
                {
                    for (int i = GameManager.instance.lvl18UnlockEnemyCount.Count; i < CrtCount; i++)
                    {

                        GameObject InstanEnemyObj = Instantiate(GameManager.instance.GetSoilderEnemyObject(), vector3, Quaternion.identity);

                        if (GameManager.instance.GetSoilderTroopParentTransform())
                            InstanEnemyObj.transform.SetParent(GameManager.instance.GetSoilderTroopParentTransform());

                        AISOILDERCtrlScript aiSoilderScript = InstanEnemyObj.GetComponent<AISOILDERCtrlScript>();
                        aiSoilderScript.GetAISoilderManager().SetTextMeshFunction("Level 18");

                        aiSoilderScript.InstanboxColliderScript(this);

                        GameManager.instance.lvl18UnlockEnemyCount.Add(aiSoilderScript);

                    }

                }

            }
            else if (isStage19) 
            {

            }

        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagsObjectScript.DestroyCubeBuildingTagsName)) 
        {
            SetAskingCubeBoxFunction(other.gameObject.GetComponent<AskingCubeBoxScript>());
        }



    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag(TagsObjectScript.DestroyCubeBuildingTagsName))
        {
            SetAskingCubeBoxFunction(other.gameObject.GetComponent<AskingCubeBoxScript>());
        }



    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag(TagsObjectScript.DestroyCubeBuildingTagsName))
        {
            SetAskingCubeBoxFunction(null);
        }




    }








    public void SetAskingCubeBoxFunction(AskingCubeBoxScript askingCubeBox) 
    {
        askingCubeBoxScript = askingCubeBox;
    }

    public AskingCubeBoxScript GetAskingCubeBoxFunction() 
    {
        return askingCubeBoxScript;
    }

}
