using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour,IDamageable
{
   public bool isDead = false;

AudioSource [] audios ;
[SerializeField]
public float waitTime=1;

[SerializeField]
  public bool haveWaitTime= false;

[Header("어떤 몬스터인지 조절하는 변수들")]

    public bool IsCrossAwayMonster = false;
    public float CrossingTime = 3f;
    private float currentTime=0;
    private Vector3 thisPos;
    public GameObject destination ;


[SerializeField]
    private bool IslookingMonster = true;
[SerializeField]
 private bool IsComingMonster = false;
    public bool IsAttackMonster = false;
    public float attackRange = 30.0f;
    public float attackPeriod= 3.0f;

//change
  

  private  float lookSpeed= 10;

  [Header("몬스터 스테이터스")]
//change
   public Animator m_anim;
    public float health = 100;
    public float fadeTime = 1.0f;
    public float dieDelayTime = 1.0f;

    public float monsterScore = 10;

    Score scoreUI;
    public float moveSpeed = 1;


//change
    GameObject targetplayer;
       //
    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;

    private void Start()
    {
//change
       targetplayer = GameObject.Find("cineCamera");
       //
        m_anim = gameObject.GetComponent<Animator>();
        scoreUI = FindObjectOfType<Score>();
    }


    private void Awake()
    {
        bulletPos = transform.Find("bulletPos");
        thisPos=GetComponent<Transform>().position;
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;

        
    }
    void Update()
    {
           
    }


   

    virtual public  void Damage(int damage)
    {
        health -= damage;

        if (health <= -0)
        {
            Collider cd = gameObject.GetComponent<Collider>();
            cd.enabled = false;
            StartCoroutine(Die());

            return;
        }
        else
        {


            StartCoroutine(GetHit());
        }



    }


    private IEnumerator GetHit()
    {   
        if(monsterHit!=null)
        monsterHit.Play();

        m_anim.SetTrigger("gethit");

        // m_anim.SetBool("GetHit",false);
        yield return null;


    }

    // Start is called before the first frame update


    private IEnumerator Die()
    {

        isDead = true;

        GameObject checkDragon;
        checkDragon = transform.GetChild(0).gameObject;
        if(checkDragon.name == "DeformationSystem")
        {
            GameObject liveL;
            liveL = transform.GetChild(1).GetChild(0).GetChild(4).gameObject;
            GameObject liveR;
            liveR = transform.GetChild(1).GetChild(0).GetChild(5).gameObject;        
            GameObject deadL;
            deadL = transform.GetChild(1).GetChild(0).GetChild(2).gameObject;
            GameObject deadR;
            deadR = transform.GetChild(1).GetChild(0).GetChild(3).gameObject;
            
            if(liveL != null && liveR != null && deadL != null &&  deadR != null)
            {
                liveL.SetActive(false);
                liveR.SetActive(false);
                deadL.SetActive(true);
                deadR.SetActive(true);
            }
        }

        m_anim.SetTrigger("IsDead");

      if(monsterDie!=null)
        monsterDie.Play();

        yield return new WaitForSeconds(dieDelayTime);

        
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
            if(IsCrossAwayMonster)
            {
                
                if(other.tag=="Destination")
                {

                    Debug.Log("arrived!");
                    //Destroy(other.gameObject);
                    other.gameObject.SetActive(false);
                    IsCrossAwayMonster = false;
                }
            }
    }

    public virtual void SethaveWaitTime()
    {
        
       StartCoroutine(changeState());
    }


IEnumerator  changeState()
{
    yield return new WaitForSeconds(waitTime);
    Debug.Log("changed!");
    haveWaitTime= true;
   
}
    // Update is called once per frame


[Header("공격 몬스터일때 설정")]
    [SerializeField]
    LayerMask targetLayer;
    private float attackTime = 0;
[SerializeField]
    
    public GameObject bullet;
    private Transform bulletPos;
    
    public AudioSource monsterAttack;
    public AudioSource monsterHit;
    public AudioSource monsterDie;

    //targetplayer
    private void AttackMonster()
    {
        if (Physics.CheckSphere(transform.position, attackRange, targetLayer))
        {
            m_anim.SetTrigger("Attack");
            
            monsterAttack.Play();

            float ran=UnityEngine.Random.Range(-10,-7);
            GameObject instance = Instantiate(bullet, bulletPos.position, Quaternion.identity);
            instance.GetComponent<Rigidbody>().velocity= new Vector3(0,1,ran).normalized*1;
        }
    }
}