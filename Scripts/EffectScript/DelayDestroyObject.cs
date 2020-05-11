using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestroyObject : MonoBehaviour
{
    public float delayTime = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DESTROYGameObjectIEnumerator());
    }

    IEnumerator DESTROYGameObjectIEnumerator() 
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);


    }




}
