 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{

    private bool isDead = false;

    AudioSource [] audios ;
[SerializeField]
private float waitTime=1;

[SerializeField]
   private bool haveWaitTime= false;

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
    Animator m_anim;
    public int health = 100;
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
            if(haveWaitTime)//일정 시간 지난 후 실행
        {
            if(IsCrossAwayMonster)
            {
             
                currentTime += Time.deltaTime;
                if(currentTime<=CrossingTime)
                 transform.position = Vector3.Lerp(thisPos, destination.transform.position,  currentTime/CrossingTime);
                 transform.LookAt(destination.transform);
            }

            else
            {
                if (IslookingMonster)
                {
                    Look();


                    if (IsAttackMonster)
                    {
                        attackTime += Time.deltaTime;
                        
                        if (attackPeriod <= attackTime)
                        {
                            if(isDead)////이거 두줄 수정
                            return;////이거 두줄 수정
                            attackTime = 0f;
                            AttackMonster();
                        }
                    }

                }

            }
        }

    }
//change
    private void Look()// player를 바라보는 몬스터 함수
    {
        Vector3 playerDirection = targetplayer.transform.position - transform.position;
        playerDirection.y = 0.0f;
        Quaternion lookRotation = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, lookSpeed * Time.deltaTime);
    }

     private void Attack()
    {

        



    }

//change


   

    public void Damage(int damage)
    {
        health -= (int)damage;

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
        monsterHit.Play();
        m_anim.SetTrigger("gethit");

        // m_anim.SetBool("GetHit",false);
        yield return null;


    }

    // Start is called before the first frame update


    private IEnumerator Die()
    {
        isDead = true;

        m_anim.SetTrigger("IsDead");

        monsterDie.Play();

        yield return new WaitForSeconds(dieDelayTime);

        GameManager.Instance.monsterCount--;
        if (GameManager.Instance.monsterCount == 0)
        {
            GameManager.Instance.NextStage();
        }

        float startTime = Time.time;
        while (Time.time < startTime + fadeTime)
        {
            float t = (Time.time - startTime) / fadeTime;

            Color c = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color;

            c.a = Mathf.Lerp(1.0f, 0.0f, t);
            yield return null;
        }
        
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

    public void SethaveWaitTime()
    {
        
       StartCoroutine(changeState());
    }


IEnumerator changeState()
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

            float ran=UnityEngine.Random.Range(-1,1);
            GameObject instance = Instantiate(bullet, bulletPos.position, Quaternion.identity);
            instance.GetComponent<Rigidbody>().velocity= new Vector3(0,1,ran).normalized*1;
        }
    }
}