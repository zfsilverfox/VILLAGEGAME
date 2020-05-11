using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourceCollectiveScript : MonoBehaviour
{
  public enum ResourceType 
    {
        Resource_Farmings,
        Resource_Fruits,
        Resource_Gold,
        Resource_Axings_Woods,





    }


    public ResourceType resourceType;


    BuildObjectScript buildObjectScript;
    [SerializeField] bool isWoodObjects = false;





    public int CrtAmount;

    private void Awake()
    {

        GetComponentFunction();

    }

    //Function : GetComponentFunction
        //Method : This is the Function that used For Getting The Component
        //Statement
    void GetComponentFunction() 
    {
        if (buildObjectScript == null)
                buildObjectScript = GetComponent<BuildObjectScript>();
    }




    private void Start()
    {



        SettingBasicInformation();

    }


    //Function : Setting Basic Information
    //Method : This is the Function which is used For 
    //Setting The Basic Information
    void SettingBasicInformation() 
    {
        switch (resourceType) 
        {
            case ResourceType.Resource_Farmings:

                CrtAmount = Random.Range(45, 60);
                break;



            case ResourceType.Resource_Fruits:

                    CrtAmount = Random.Range(5, 15);

                    break;
            
            case ResourceType.Resource_Axings_Woods:

                    CrtAmount = Random.Range(25, 40);

                    break;

            case ResourceType.Resource_Gold:

                CrtAmount = Random.Range(5, 10);

                break;

          





        }


 


    }


    //Function : GatherAmounts
    //Method : This is the Function that used 
    // For Gather The Amounts 
    public void GatherAmounts(int collectiveResource) 
    {
        switch (resourceType) 
        {
            case ResourceType.Resource_Farmings:


                if (CrtAmount > 0)
                {



                    PlayerManagerScript.instance.foods += collectiveResource;
                    CrtAmount -= collectiveResource;
                }

                if (CrtAmount <= 0)
                {
                    if (GameManager.instance.buildObjectListScript.Contains(this.buildObjectScript))
                    {
                        GameManager.instance.buildObjectListScript.Remove(this.buildObjectScript);
                    }

                    if (GameManager.instance.GoldResourceCollectiveScript.Contains(this))
                    {
                        GameManager.instance.GoldResourceCollectiveScript.Remove(this);
                    }

                    GROUNDSScript.instance.RemoveBuilding(this.gameObject,transform.position);




                    Destroy(this.gameObject);
                }




                break;

            case ResourceType.Resource_Fruits:

                if(CrtAmount > 0) 
                {
                    PlayerManagerScript.instance.recoverFruits += collectiveResource;
                    CrtAmount -= collectiveResource;

                }

                if(CrtAmount <= 0) 
                {
                    if (GameManager.instance.buildObjectListScript.Contains(this.buildObjectScript)) 
                    {
                            GameManager.instance.buildObjectListScript.Remove(this.buildObjectScript);
                    }

                    if (GameManager.instance.GoldResourceCollectiveScript.Contains(this)) 
                    {
                        GameManager.instance.GoldResourceCollectiveScript.Remove(this);
                    }


                    GROUNDSScript.instance.RemoveBuilding(this.gameObject, transform.position);




                    Destroy(this.gameObject);
                }




           



                break;

            case ResourceType.Resource_Gold:


                if(CrtAmount > 0) 
                {
                        PlayerManagerScript.instance.Gold += collectiveResource;
                    CrtAmount -= collectiveResource;
                }

                if(CrtAmount <= 0) 
                {
                    if (GameManager.instance.buildObjectListScript.Contains(this.buildObjectScript))
                    {
                        GameManager.instance.buildObjectListScript.Remove(this.buildObjectScript);
                    }


                    if (GameManager.instance.GoldResourceCollectiveScript.Contains(this))
                    {
                        GameManager.instance.GoldResourceCollectiveScript.Remove(this);
                    }

                    GROUNDSScript.instance.RemoveBuilding(this.gameObject, transform.position);

                    Destroy(this.gameObject);
                }



            


                break;

            case ResourceType.Resource_Axings_Woods:

             if(CrtAmount > 0) 
                {   
                    PlayerManagerScript.instance.Woods += collectiveResource;
                    CrtAmount-= collectiveResource;
                }

                if (CrtAmount <= 0)
                {
                    if (GameManager.instance.buildObjectListScript.Contains(this.buildObjectScript))
                    {
                        GameManager.instance.buildObjectListScript.Remove(this.buildObjectScript);
                    }


                    if (GameManager.instance.GoldResourceCollectiveScript.Contains(this))
                    {
                        GameManager.instance.GoldResourceCollectiveScript.Remove(this);
                    }


                    GROUNDSScript.instance.RemoveBuilding(this.gameObject, transform.position);

                    Destroy(this.gameObject);
                }





                break;


        }


      








    }

    //Function : CheckGoldAmountFunction
    //Method : This is the Function used For Checking The Amount is BiggerOrNot
    public void CheckGoldAmountFunction(int enoughAmount) 
    {
        if(PlayerManagerScript.instance.Gold >= enoughAmount) 
        {
            UIManager.instance.GetYesButtonFunction().interactable = true;
            UIManager.instance.GetNoButtonFunction().interactable = true;
        }
        else if(PlayerManagerScript.instance.Gold < enoughAmount) 
        {
            UIManager.instance.GetYesButtonFunction().interactable = false;
            UIManager.instance.GetNoButtonFunction().interactable = true;




        }



    }









}
