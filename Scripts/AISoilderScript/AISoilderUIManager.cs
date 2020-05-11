using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class AISoilderUIManager : MonoBehaviour
{
    [SerializeField] Image CrtAmountHPFilled;
    [SerializeField] TextMesh CrtLevelTextMesh;





    //Function : UpdateHealthAmountFunction
    //Method : This is the Function used For 
    //Update The Health Amount Function 
    public void UpdateHealthAmountFunction(float CrtHealth = 0.0f, float MaxHealth = 1.0f)
    {

        CrtAmountHPFilled.fillAmount = CrtHealth / MaxHealth;


    }

    //Function : SetTextMeshFunction
        //Method : This is the Function that used 
            //For Setting The TextMesh  
    public void SetTextMeshFunction(string textMeshString = "") 
    {
        CrtLevelTextMesh.text = textMeshString;
    }





}
