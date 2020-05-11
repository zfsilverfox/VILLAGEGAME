using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class GameTitleManager : MonoBehaviour
{
    
    public static GameTitleManager instance { private set; get; }



    [SerializeField] GameObject CtrlWay1PanelObj,CtrlWay2PanelObj,ExplainPanel1,ExplainPanel2;


    [SerializeField] GameObject LoadingPanelObj;

    [SerializeField] Image LoadingValue;

    private void Awake()
    {
        if (instance == null) instance = this;


    }





    public void OpenCtrlWay1PanelObj() 
    {
        if (CtrlWay2PanelObj.activeInHierarchy) 
        {
            CtrlWay2PanelObj.SetActive(false);
        }

        CtrlWay1PanelObj.SetActive(true);



    }
    public void OpenCtrlWay2PanelObj() 
    {
        if (CtrlWay1PanelObj.activeInHierarchy) 
        {
            CtrlWay1PanelObj.SetActive(false);
        }

        CtrlWay2PanelObj.SetActive(true);


    }

    public void OpenExplainPanel1Obj() 
    {
        if (ExplainPanel2.activeInHierarchy) 
        {
            ExplainPanel2.SetActive(false);
        }


        ExplainPanel1.SetActive(true);


    }

    public void OpenExplainPanel2Obj() 
    {
        if (ExplainPanel1.activeInHierarchy) 
        {
            ExplainPanel1.SetActive(false);
        }

        ExplainPanel2.SetActive(true);



    }


    public void CloseCtrlWayPanelObj() 
    {

        if(CtrlWay1PanelObj.activeInHierarchy)
        {
            CtrlWay1PanelObj.SetActive(false);
        }

        if (CtrlWay2PanelObj.activeInHierarchy) 
        {
            CtrlWay2PanelObj.SetActive(false);
        }

        if (ExplainPanel1.activeInHierarchy) 
        {
            ExplainPanel1.SetActive(false);
        }

        if (ExplainPanel2.activeInHierarchy) 
        {
            ExplainPanel2.SetActive(false);
        }




    }




    public void StartGameFunction() 
    {
        StartCoroutine(SCENEMANAGERScript.instance.RestartIEnumerator());




        LoadingPanelObj.SetActive(true);



    }


    public void SetValueFunction(float value= 0.0f  ) 
    {
        LoadingValue.fillAmount = value;
    }










}
