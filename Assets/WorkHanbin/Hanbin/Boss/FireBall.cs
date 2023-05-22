using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FireBall : MonoBehaviour
{
    private Transform player;
    private bool isReady = false;
    private float speed = 3f;

    public float maxSpeed = 6.0f;
    private float rotateSpeed = 10f;

    private Rigidbody rb;
    private float rotationDuration = 2f;
    // Start is called before the first frame update

    public GameObject boss;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        Invoke("ActivateHoming", 2f);
        boss=GameObject.Find("Boss_RED");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.DORotate(new Vector3(0f, 360f, 0f), rotationDuration, RotateMode.LocalAxisAdd)
        //     .SetLoops(-1, LoopType.Restart);

        Move();
    }
    public void Move()
    {


        if (isReady && player != null)
        {

            Vector3 direction = (player.position - transform.position - new Vector3(0, 1.5f, 0)).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
            if (speed <= maxSpeed)
                speed += Time.deltaTime;

            rb.velocity = transform.forward * speed;

        }



    }






    private void ActivateHoming()
    {
        isReady = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.CompareTag("Player"))
        {
            var BossScrpt = boss.GetComponent<Boss>();
            BossScrpt.patternOn=true;
            Destroy(this.gameObject);
        }
    }
}
