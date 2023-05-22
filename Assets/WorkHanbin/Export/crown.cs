using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crown : MonoBehaviour
{
    float y ;
    public float speed=4f;
    public float addPos=1.3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        y= Mathf.Sin(Time.time*speed)*0.1f+addPos ;

        gameObject.transform.localPosition= new Vector3(transform.localPosition.x,y,transform.localPosition.z);
    }
}
