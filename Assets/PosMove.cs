using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosMove : MonoBehaviour
{
    [SerializeField] [Range(0f,10f)] private float speed = 1f;
    [SerializeField] [Range(0f,10f)]  private float length = 1f;
 
    private float runningTime = 0f;
    private float yPos = 0f;
    private float xPos = 0f;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int k = Random.Range(0, 5);
        runningTime += Time.deltaTime * speed;
        yPos = Mathf.Sin(runningTime)*k;
        xPos = Mathf.Cos(runningTime)*k;
        this.transform.position = new Vector3(64-xPos,93+yPos,-93);
    }
}
