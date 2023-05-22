using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FireBall : MonoBehaviour, IDamageable
{

    public float MaxHp = 250;
    private float hp;
    private Transform player;
    private bool isReady = false;
    private float speed = 3f;

    public float maxSpeed = 6.0f;
    private float rotateSpeed = 10f;

    private Rigidbody rb;
    private float rotationDuration = 2f;
    // Start is called before the first frame update

    public GameObject boss;
    private Boss bossScript;
    private Collider collider;
    
    void Start()
    {
        hp = MaxHp;
        rb = GetComponent<Rigidbody>();
        Invoke("ActivateHoming", 2f);
        boss = GameObject.Find("Boss_RED");
        bossScript=GetComponent<Boss>();
        collider= GetComponent<Collider>();
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
        collider.enabled=true;
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            var BossScript = boss.GetComponent<Boss>();
            BossScript.patternOn = true;
            
            Destroy(this.gameObject);
            
        }
    }

    public void Damage(int damage)
    {
        if (hp >0)
        {
             hp -= damage;
            
      
        }
        else if(hp<=0)
            {
                var BossScript = boss.GetComponent<Boss>();
            BossScript.patternOn=true;
            Destroy(this.gameObject);
        }
    }

}
