using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;








public class StateScript
{
    public Action EnterStatement, ExitStatement,UpdateStatement ;

    //class : StateScript 
    //Method : This is the Function used For 
    //Setting The StateScript 
    public StateScript(Action enter , Action exit,Action update) 
    {
        EnterStatement = enter;
        ExitStatement = exit;
        UpdateStatement = update;


    }

    //Function : EnterFunction 
    //Method : This is the Function used For Invoke The EnterFunction 
    public void EnterFunction() 
    {
        EnterStatement?.Invoke();

    }

    //Function : UpdateFunction
    //Method : This is the Function that 
    //used For Update Invoke The Update Function 
    public void UpdateFunction() 
    {

        UpdateStatement?.Invoke();

    }

    //Function : ExitFunction
    //Method : This is the Function that 
    //used For Exit The Invoke Statement 
    public void ExitFunction() 
    {
        ExitStatement?.Invoke();
    }




}
