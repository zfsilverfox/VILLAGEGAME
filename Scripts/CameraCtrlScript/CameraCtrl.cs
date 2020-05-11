using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public static CameraCtrl instance { private set; get; }


    Camera cam;

    public bool isDragging = false;

    private Vector3 draggingOriginPosition;

    private Vector3 offset;

    private Vector3 originPosition;

    //   Transform DefaultPositionSetting;

    Vector3 DefaultVector3Position;

    public float MovSpd = 100.0f;




    private void Awake()
    {
        if (instance == null)
                instance = this;


        cam = Camera.main;
        originPosition = transform.position;

    }

    private void Start()
    {

        DefaultVector3Position = transform.position;

        //DefaultPositionSetting = transform;


    }





    private void Update()
    {
        if (PlayerInputScript.instance.MouseWheelClick) 
        {
            
            DraggingMousePosition();

        }
        else 
        {
            isDragging = false;
        }


        if(!UIManager.instance.GetUNLockPanelObject().activeInHierarchy)
        {
            if (!UIManager.instance.GetRequireLevelPanelFunction().activeInHierarchy) 
            {
                if (!UIManager.instance.GetWorkerPanelObjFunction().activeInHierarchy)

                {




                    if (isDragging)
                    {
                        transform.position = draggingOriginPosition - offset;
                    }
                    else
                    {
                        cam.orthographicSize -= PlayerInputScript.instance.MouseScrollWheelFloat;

                        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 1.87f, 5f);






                    }


                  
                        transform.position = new Vector3( transform.position.x +(MovSpd * Time.deltaTime * PlayerInputScript.instance.Horizontal), transform.position.y,transform.position.z + ( MovSpd *PlayerInputScript.instance.Vertical)* Time.deltaTime);



                }




            }





        }






    }

    //Function : DraggingMousePosition
    //Method : This is the Function that used For Dragging Position
    void DraggingMousePosition() 
    {
        offset =(cam.ScreenToWorldPoint(Input.mousePosition) -transform.position);

        if (!isDragging) 
        {
            isDragging = true;
            draggingOriginPosition = cam.ScreenToWorldPoint(Input.mousePosition);


        }



    }



    //Function : SetStartPositionFunction
    //Method : This Function is mainly used For Setting The Starting Position
    public void SetStartPositionFunction()
    {

        transform.position = DefaultVector3Position;



    }






}
