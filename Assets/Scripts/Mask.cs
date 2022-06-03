using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{


    private GameObject[] maskObj;
    // Start is called before the first frame update
    void Start()
    {
        maskObj = GameObject.FindGameObjectsWithTag("Coarse");
        for (int i = 0; i < maskObj.Length; i++)
        {
            maskObj[i].GetComponent<SpriteRenderer>().material.renderQueue = 3002;
        }
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }


}
