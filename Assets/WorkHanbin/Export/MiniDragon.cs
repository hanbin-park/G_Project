using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MiniDragon : Bullet
{
   
    public Rigidbody rg;
public float rotateSpeed = 0.01f;


    
    [SerializeField]

    private float currentSpeed = 0;
     private void Awake() {
        Debug.Log("Awake");
    }

    void Start()
    {
          Debug.Log("Start");
        // player= GameObject.Find("cineCamera");
        rg= GetComponent<Rigidbody>();
      //  rg.velocity = new Vector3(0, 0.5f, 0.5f).normalized * 1;
    
    }
   
    // Update is called once per frame
     void LateUpdate()
    {
      Move();
    }


    public override void Move()
    {
        if (currentSpeed <= speed)
            currentSpeed += speed * Time.deltaTime;


        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        Vector3 direction = (player.transform.position - transform.position).normalized;
          transform.position = Vector3.MoveTowards(transform.position, player.transform.position, currentSpeed * Time.deltaTime);
    }
}
