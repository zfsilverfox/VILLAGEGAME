using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanPlayerisInTheSphereColliderScript : MonoBehaviour
{

    ScoopScript scoopScript;

    private void Awake()
    {


        GetComponentFunction();


    }

    void GetComponentFunction() 
    {
        if (scoopScript == null)
            scoopScript = GetComponentInParent<ScoopScript>();


    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagsObjectScript.PlayerTagsName)) 
        {
            //     Debug.Log("Has Enter the Trigger ");
          


        }




    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(TagsObjectScript.PlayerTagsName))
        {
          


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(TagsObjectScript.PlayerTagsName))
        {
            //  Debug.Log("Has Leaved in the Trigger ");
          
        }
    }

}
