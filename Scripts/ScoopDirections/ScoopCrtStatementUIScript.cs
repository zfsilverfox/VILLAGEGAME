using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class ScoopCrtStatementUIScript : MonoBehaviour
{
    ScoopScript scoopScript;

    [SerializeField] Image CrtHPImage,CrtSpiritImage;


    [SerializeField] Image EmotionBubbleSprite;

    [SerializeField] Sprite WorkingSprite,IldeSprite,AttackSprite;








    private void Awake()
    {
        GetComponentFunction();





    }

    void GetComponentFunction() 
    {
        if (scoopScript == null)
            scoopScript = GetComponentInParent<ScoopScript>();


    }


    void Update
        () 
    {
        if(CrtHPImage != null) 
        {
            CrtHPImage.fillAmount =
                (float)
                scoopScript.energyType.CrtHP /
                (float)
                scoopScript.energyType.MaxHP;


        }

        if(CrtSpiritImage != null) 
        {

            CrtSpiritImage.fillAmount = 
                (float)
                scoopScript.energyType.CrtSpirit
                    /(float)scoopScript.energyType.MaxSpirit ;


        }





    }


    //Function :SETWorkingSpriteFunction
    //Method : This is the Function that used 
    //For Set Working Sprite 
    public void SETWorkingSpriteFunction() 
    {
        EmotionBubbleSprite.sprite = WorkingSprite;



    }

    //Function : SetIlderSpriteFunction
    //Method : This is the Function used 
    //For Setting the Idle Statement 
    public void SetIldeSpriteFunction() 
    {
        EmotionBubbleSprite.sprite = IldeSprite;

    }

    //Function : SetAttackSpriteFunction
    //Method : This is the Function that used 
    //For Setting The Attack Sprite 
    public void SetAttackSpriteFunction() 
    {
        EmotionBubbleSprite.sprite = AttackSprite;
    }


    //Function : GetEmotionBubbleGameObject
    //Method : This is the Function used For
    //Getting The Emotion Bubble Image Object 
    public Image GetEmotionBubbleGameObject() 
    {
        if(EmotionBubbleSprite != null) 
        {
            return EmotionBubbleSprite;
        }


        return null;
    }

}
