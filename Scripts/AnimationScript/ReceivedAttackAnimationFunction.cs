using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivedAttackAnimationFunction : MonoBehaviour
{
   






    public void AttackAnimationReceivedFunction() 

    {
        gameObject.SendMessageUpwards("ATTACKFunction");


    }








}
