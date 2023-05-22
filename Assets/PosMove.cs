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
        runningTime += Time.deltaTime * speed;
        yPos = Mathf.Sin(runningTime);
        xPos = Mathf.Cos(runningTime);
        this.transform.position = new Vector3(63+xPos,92+yPos,-80);
    }
}
