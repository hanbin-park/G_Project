using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Bullet
{
   
    public Rigidbody rg;
public float rotateSpeed = 0.01f;

   private GameObject player;
    [SerializeField]

    private float currentSpeed = 0;
    void Start()
    {
        // player= GameObject.Find("cineCamera");
        rg= GetComponent<Rigidbody>();
        rg.velocity = new Vector3(0, 0.5f, 0.5f).normalized * 1;
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
        transform.forward = Vector3.Lerp(direction, Vector3.forward, rotateSpeed);
    }
}
