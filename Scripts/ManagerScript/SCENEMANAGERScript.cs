using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class SCENEMANAGERScript : MonoBehaviour
{
  public static SCENEMANAGERScript instance { private set; get; }

    private string GameMainString = "GameMain";
    private string GameTitleString = "GameTitle";



    private void Awake()
    {

        if (instance == null)
                instance = this;
    }






    public void RestartSceneFunction() 
    {

        StartCoroutine(RestartIEnumerator());

    }






    public void QuitGameSceneFunction() 
    {
        QuitIEnumerator();
    }


    //IEnumerator : RestartIEnumerator 
    //Method : This is the Function that used For
    //IEnumerator 
public    IEnumerator RestartIEnumerator() 
    {

        yield return new WaitForSeconds(0.2f);

   

        AsyncOperation async = SceneManager.LoadSceneAsync(GameMainString);

        while (!async.isDone) 
        {
            if(UIManager.instance != null) 
            {
 UIManager.instance.SetNowLoadingCrtValue(async.progress);

            }

            if(GameTitleManager.instance != null) 
            {
                GameTitleManager.instance.SetValueFunction(async.progress);
            }




           
         yield   return null;
        }


   



    }

  public  IEnumerator QuitIEnumerator() 
    {

        yield return new WaitForSeconds(0.2f);

        AsyncOperation async = SceneManager.LoadSceneAsync(GameTitleString);

        

        while (!async.isDone) 
        {
          
            if (UIManager.instance != null)
            {
                UIManager.instance.SetNowLoadingCrtValue(async.progress);

            }
            yield return null;


        }





    }






}
