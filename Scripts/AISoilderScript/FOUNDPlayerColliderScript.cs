using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOUNDPlayerColliderScript : MonoBehaviour
{
    AISOILDERCtrlScript aiSoilderCtrlScript;

    private void Awake()
    {
        GetComponentFunction();



    }

    //Function : GetComponentFunction
    //Method : This is the Function that used 
    //For Getting the component 
    void GetComponentFunction() 
    {
        if (aiSoilderCtrlScript == null)
            aiSoilderCtrlScript = GetComponentInParent<AISOILDERCtrlScript>();


    }





    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(TagsObjectScript.PlayerTagsName)) 
        {
        //    Debug.Log("Found Player Has Been Tags ");
            aiSoilderCtrlScript.SetScoopScriptFunction(other.gameObject.GetComponent<ScoopScript>());


        }



    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(TagsObjectScript.PlayerTagsName))
        {
         //   Debug.Log("Player Has Been Tagged in ");

            aiSoilderCtrlScript.SetScoopScriptFunction(other.gameObject.GetComponent<ScoopScript>());






        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(TagsObjectScript.PlayerTagsName))
        {
         //   Debug.Log("Player Has Exit the ");
            aiSoilderCtrlScript.SetScoopScriptFunction(null);
        }
    }











}
