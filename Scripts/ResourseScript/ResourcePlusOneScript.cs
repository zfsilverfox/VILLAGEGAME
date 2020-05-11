using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePlusOneScript : MonoBehaviour
{

    public float Spd = 25f;

    private void Start()
    {
        StartCoroutine(iemeratorDestroyThisGameObject());
    }

    private void Update()
    {
        this.transform.position = transform.position + Vector3.up * Spd * Time.deltaTime;


    }




    IEnumerator iemeratorDestroyThisGameObject() 
    {
        yield return new WaitForSeconds(Random.Range(0.4f, 1.4f));

        Destroy(this.gameObject);

    }





}
