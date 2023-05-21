using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crown : MonoBehaviour
{
    float y ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        y= Time.deltaTime;
        gameObject.transform.position= new Vector3(0,Mathf.Cos(y)*0.1f,0);
    }
}
