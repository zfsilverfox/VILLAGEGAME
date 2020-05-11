using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BuildUIBtnScript : MonoBehaviour
{
    Button thisBtn;
  [SerializeField]  Text buildingText;

 [SerializeField] Text SetCostText;







    public int BuildingIndex = 0;


    private void Awake()
    {
        GetComponentFunction();
    }

    //Function : GetComponentFunction 
    //Method : This is 
    void GetComponentFunction() 
    {
        thisBtn = GetComponent<Button>();
       // buildingText = GetComponentInChildren<Text>();

        thisBtn.onClick.AddListener(ADDThisListenerFunction);

    }




    
    public void SetBuildingNameText(string textName) 
    {
        buildingText.text = textName;
    }


    public void SetCrtNumberIndex(int index ) 
    {
        BuildingIndex = index;




    }


    //Function : SetCostTextFunction
    //Method : This is the Function used For Setting The Cost 

    public void SetCostTextFunction(int costInteger) 
    {
        SetCostText.text = "COST :" + costInteger.ToString();




    }







    void ADDThisListenerFunction() 
    {

        GameManager.instance.BuildingIndex = BuildingIndex;

    }




}
