using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MiniDragon : MonoBehaviour
{

    public Rigidbody rb;
    public float rotateSpeed = 1f;
    public float initialDelay = 1f;
    public float maxSpeed=6.0f;


    public GameObject boss;
    private Boss bossScript;

  private float speed = 0f;
    private GameObject player;
    private Animator Anim;
    private SpawnMonster monster;
    private Transform target;
private bool isReady = false;

    [SerializeField]



    private float currentSpeed = 0;
    private void Awake()
    {
        boss=GameObject.Find("Boss_RED");
        bossScript=boss.GetComponent<Boss>();    }

    void Start()
    {
        float x=Random.Range(-1.0f,1.0f);
        float y=Random.Range(-1.0f,1.0f);
        player= GameObject.Find("cineCamera");
        rb = GetComponent<Rigidbody>();
       rb.velocity+= new Vector3(x,y,0);
       //rb.AddForce(x,y,2f,ForceMode.VelocityChange);
        transform.localRotation = Quaternion.LookRotation(rb.velocity);

        //new Vector3(x,y,2f)
      Invoke("ActivateHoming", initialDelay);
      monster= GetComponent<SpawnMonster>();
      Anim=GetComponent<Animator>();
      speed=3;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }


    public  void Move()
    {


        if (isReady && target != null)
        {
            if(!monster.isDead)
            {
                 Vector3 direction = (target.position - transform.position- new Vector3(0,1.5f,0)).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            transform.rotation=Quaternion.RotateTowards(transform.rotation,rotation,rotateSpeed);
            if(speed<=maxSpeed)
             speed+=Time.deltaTime;
          
             rb.velocity = transform.forward * speed;
         
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
    

        }



    }


        private void ActivateHoming()
    {
        isReady = true;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void OnTriggerEnter(Collider other) {
           if(other.gameObject.tag=="Player")
        {
            Debug.Log("hgi");
            Destroy(this.gameObject);
        }
    }
  

  private void OnDestroy() {
    
    Boss_Attack1.monsterCount--;
   if(Boss_Attack1.monsterCount==0)
   {
    bossScript.patternOn=true;
    Boss_Attack1.monsterCount=9;
   } 
  }
}
