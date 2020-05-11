using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
  
    public static PlayerInputScript instance { get; set; }

    private static string MouseScrollWheelString = "Mouse ScrollWheel";
    private static string VerticalString = "Vertical";
    private static string HorizontalString = "Horizontal";




    [HideInInspector]
    public bool OnClickLeftMouseBtnDown;
   
    [HideInInspector]
    public bool OnClickLeftMouseBtn;
    
    [HideInInspector]
    public bool OnClickLeftMouseBtnUP;
    
    [HideInInspector]
    public bool MouseWheelClick;

    [HideInInspector]
    public bool OnClickRightBtnDown;

    public float MouseScrollWheelFloat;


    public float Horizontal,Vertical;





    private void Awake()
    {


        if (instance == null)
                    instance = this;



    }


    private void Update()
    {
        OnClickLeftMouseBtnDown = Input.GetMouseButtonDown(0);
        OnClickLeftMouseBtn = Input.GetMouseButton(0);
        OnClickLeftMouseBtnUP = Input.GetMouseButtonUp(0);
        MouseWheelClick = Input.GetMouseButton(2);
        OnClickRightBtnDown = Input.GetMouseButtonDown(1);
        MouseScrollWheelFloat = Input.GetAxis(MouseScrollWheelString);

        Horizontal = Input.GetAxis(HorizontalString);
        Vertical = Input.GetAxis(VerticalString);


    }



}
