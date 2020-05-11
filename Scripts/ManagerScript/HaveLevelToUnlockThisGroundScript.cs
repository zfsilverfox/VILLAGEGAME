using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InstanEnemiesScirpt))]
public class HaveLevelToUnlockThisGroundScript : MonoBehaviour
{
  public bool isUnlock = false;
    public int Cost;

  public  bool isStage1 = false;
    public bool isStage2 = false;

    public bool isStage3 = false;








  public bool CheckForUnLockLevelConditions() 
    {

        if(isStage1)
        {
           if (GameManager.instance.unLockStatement.hasUnLockLevel1&& 
                        GameManager.instance.unLockStatement.hasUnLockLevel2&&
                        GameManager.instance.unLockStatement.hasUnLockLevel3)
                        
                {
                return true;
                }  
        }
        else if (isStage2) 
        {
            if(GameManager.instance.unLockStatement.hasUnLockLevel10
                && GameManager.instance.unLockStatement.hasUnLockLevel11
                    && GameManager.instance.unLockStatement.hasUnLockLevel12) 
            {
                return true;
            }




        }
        else if (isStage3) 
        {
            if(GameManager.instance.unLockStatement.hasUnLockLevel8
                        && GameManager.instance.unLockStatement.hasUnLockLevel13
                        ) 
            {
                return true;
            }








        }

        return false;

    }


    public
    void UpdateTheUnlockStatementFunction() 
    {
        if (CheckForUnLockLevelConditions()) 
        {
            isUnlock = true;
        }



    }

  
    //String : GetTheUnlockRequipmentTextFunction 
    //Method : This is the Function used For Getting 
    //The Unlock Requipment Text 
    public string GetTheUnlockRequipmentTextFunction() 
    {

        if(isStage1)
        {

            if (!GameManager.instance.unLockStatement.hasUnLockLevel1 &&
!GameManager.instance.unLockStatement.hasUnLockLevel2 &&
!GameManager.instance.unLockStatement.hasUnLockLevel3

                )
            {
                return "Level 1" + "\n" + "Level 2 " + "\n" + "Level 3" + "\n";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel1 &&
                !GameManager.instance.unLockStatement.hasUnLockLevel2 &&
                !GameManager.instance.unLockStatement.hasUnLockLevel3
                )
            {
                return "Level 2 " + "\n" + "Level 3 ";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel1&&
                GameManager.instance.unLockStatement.hasUnLockLevel2&&  
                !GameManager.instance.unLockStatement.hasUnLockLevel3)
            {
              return  "Level 3 ";
            }
            else if(GameManager.instance.unLockStatement.hasUnLockLevel1 &&
                GameManager.instance.unLockStatement.hasUnLockLevel3&& 
                !GameManager.instance.unLockStatement.hasUnLockLevel2)
            {
                return "Level 2 ";
            }
            else if(GameManager.instance.unLockStatement.hasUnLockLevel2
                && !GameManager.instance.unLockStatement.hasUnLockLevel1 
                && !GameManager.instance.unLockStatement.hasUnLockLevel3) 
            {
                return "Level 1 " + "\n" + "Level 3 ";
            }
            else if (!GameManager.instance.unLockStatement.hasUnLockLevel1
                && GameManager.instance.unLockStatement.hasUnLockLevel2
                && GameManager.instance.unLockStatement.hasUnLockLevel3)
            {
                return "Level 1" ;
            }


        }
            else if (isStage2) 
        {
            if (!GameManager.instance.unLockStatement.hasUnLockLevel10 &&
!GameManager.instance.unLockStatement.hasUnLockLevel11 &&
!GameManager.instance.unLockStatement.hasUnLockLevel12

              )
            {
                return "Level 10" + "\n" + "Level 11 " + "\n" + "Level 12" + "\n";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel10 &&
                !GameManager.instance.unLockStatement.hasUnLockLevel11 &&
                !GameManager.instance.unLockStatement.hasUnLockLevel12
                )
            {
                return "Level 11 " + "\n" + "Level 12 ";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel10 &&
                GameManager.instance.unLockStatement.hasUnLockLevel11 &&
                !GameManager.instance.unLockStatement.hasUnLockLevel12)
            {
                return "Level 12 ";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel10 &&
                GameManager.instance.unLockStatement.hasUnLockLevel11 &&
                !GameManager.instance.unLockStatement.hasUnLockLevel12)
            {
                return "Level 11 ";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel10
                && !GameManager.instance.unLockStatement.hasUnLockLevel11
                && !GameManager.instance.unLockStatement.hasUnLockLevel12)
            {
                return "Level 10 " + "\n" + "Level 12 ";
            }
            else if (!GameManager.instance.unLockStatement.hasUnLockLevel10
                && GameManager.instance.unLockStatement.hasUnLockLevel11
                && GameManager.instance.unLockStatement.hasUnLockLevel12)
            {
                return "Level 10";
            }

        }
                else if (isStage3) 
                {
                    if(!GameManager.instance.unLockStatement.hasUnLockLevel8 &&
                            !GameManager.instance.unLockStatement.hasUnLockLevel13) 
                    {
                        return "Level 8" + "\n" + "Level 13";
                    }
                    else if(GameManager.instance.unLockStatement.hasUnLockLevel8
                                && !GameManager.instance.unLockStatement.hasUnLockLevel13) 
                        {
                            return "Level 13";
                        }
                    else if (!GameManager.instance.unLockStatement.hasUnLockLevel8
                                    && GameManager.instance.unLockStatement.hasUnLockLevel13) 
                            {
                                return "Level 8";
                            }



                }
        return "";


    }

    public string GetTheHaveUnlockRequipmentTextFunction() 
    {
        if (isStage1) 
        {
            if (!GameManager.instance.unLockStatement.hasUnLockLevel1 &&
                    !GameManager.instance.unLockStatement.hasUnLockLevel2 &&
                        !GameManager.instance.unLockStatement.hasUnLockLevel3
                )
            {

                return "";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel1
                && !GameManager.instance.unLockStatement.hasUnLockLevel2
                 && !GameManager.instance.unLockStatement.hasUnLockLevel3)
            {
                return "Level 1 ";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel1
                && GameManager.instance.unLockStatement.hasUnLockLevel2
                && !GameManager.instance.unLockStatement.hasUnLockLevel3)
            {
                return "Level 1 " + "\n" + "Level 2 ";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel1
                &&  !GameManager.instance.unLockStatement.hasUnLockLevel2
               && GameManager.instance.unLockStatement.hasUnLockLevel3) 
            {
                return "Level 1 " + "\n" + "Level 3 ";
            }
          else if (!GameManager.instance.unLockStatement.hasUnLockLevel1
                && GameManager.instance.unLockStatement.hasUnLockLevel2
                && ! GameManager.instance.unLockStatement.hasUnLockLevel3)
            {
                return "Level 2";
            }
            else if (!GameManager.instance.unLockStatement.hasUnLockLevel1
                && GameManager.instance.unLockStatement.hasUnLockLevel2
                && GameManager.instance.unLockStatement.hasUnLockLevel3)
            {
                return "Level 2" + "\n" +"Level 3 ";
            }






        }
        else if (isStage2) 
        {
            if (!GameManager.instance.unLockStatement.hasUnLockLevel10 &&
                    !GameManager.instance.unLockStatement.hasUnLockLevel11 &&
                        !GameManager.instance.unLockStatement.hasUnLockLevel12
                )
            {

                return "";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel10
                && !GameManager.instance.unLockStatement.hasUnLockLevel11
                 && !GameManager.instance.unLockStatement.hasUnLockLevel12)
            {
                return "Level 10 ";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel10
                && GameManager.instance.unLockStatement.hasUnLockLevel11
                && !GameManager.instance.unLockStatement.hasUnLockLevel12)
            {
                return "Level 10 " + "\n" + "Level 11 ";
            }
            else if (GameManager.instance.unLockStatement.hasUnLockLevel10
                && !GameManager.instance.unLockStatement.hasUnLockLevel11
               && GameManager.instance.unLockStatement.hasUnLockLevel12)
            {
                return "Level 10 " + "\n" + "Level 12 ";
            }
            else if (!GameManager.instance.unLockStatement.hasUnLockLevel10
                  && GameManager.instance.unLockStatement.hasUnLockLevel11
                  && !GameManager.instance.unLockStatement.hasUnLockLevel12)
            {
                return "Level 11";
            }
            else if (!GameManager.instance.unLockStatement.hasUnLockLevel10
                && GameManager.instance.unLockStatement.hasUnLockLevel11
                && GameManager.instance.unLockStatement.hasUnLockLevel12)
            {
                return "Level 11" + "\n" + "Level 12 ";
            }








        }
        else if (isStage3) 
        
        {
            if (!GameManager.instance.unLockStatement.hasUnLockLevel8&& ! GameManager.instance.unLockStatement.hasUnLockLevel13) 
            {
                return "";
            }
           else if(GameManager.instance.unLockStatement.hasUnLockLevel8 && !GameManager.instance.unLockStatement.hasUnLockLevel13              )
            {
                return "Level 8 ";
            }
            else if (!GameManager.instance.unLockStatement.hasUnLockLevel8 && GameManager.instance.unLockStatement.hasUnLockLevel13) 
            {
                return "Level 13";
            }



        }

        return "";
    }




}
