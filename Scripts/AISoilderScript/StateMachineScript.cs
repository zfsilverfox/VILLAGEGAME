using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineScript : MonoBehaviour
{
    Stack<StateScript> stateStackScript { get; set; }

    private void Awake()
    {
        stateStackScript = new Stack<StateScript>();



    }


    private void Update()
    {
       
    
        if(GetCrtStateFunction() != null) 
        {
            GetCrtStateFunction().UpdateFunction();
        }


    }


    //Function : PushStateFunction 
    //Method : This is the Function that used For 
    //Pushing The Statement 
    public void PushStateFunction(System.Action enter,System.Action exit , System.Action update ) 
    {
        if(GetCrtStateFunction() != null) 
        
        {

            GetCrtStateFunction().ExitFunction();



        }

        StateScript stateScript = new StateScript(enter, exit, update);


        stateStackScript.Push(stateScript);
        stateScript.EnterFunction();


    }


    //Function : GetCrtStateFunction
    //Method : This is the Function That used
    //Getting The Current Statement Function 
    StateScript GetCrtStateFunction() 
    {
        return stateStackScript.Count > 0 ?stateStackScript.Peek(): null;


    }




}
