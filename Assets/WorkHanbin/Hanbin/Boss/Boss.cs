using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Boss : Monster
{
    [Header("보스패턴 정형화")]

    public  bool patternOn =true;
    private bool plz =true;
    public bool HaveWaitTime
    {
        get
        {
            return haveWaitTime;
        }
        set
        {
            haveWaitTime=value;
            if(haveWaitTime&&plz)
            {
                bossHPUI.UION=true;
                plz=false;
            }
        }
    }
   
    public int[] pattern;
    public int patCount=0;

   

    [Header("보스패턴1")]
    public Transform[] monsterSpawn;
   public GameObject[] monster;
  public  float patternStartTime;

    private GameObject player;
public Animator bossAnim;



    [Header("보스패턴2")]
//플레이어에게 다가오고 그동안 약점 3곳 때리기

   
   public Transform fireBallTransform;

    public GameObject fireBall;
    




    private BossHPUI bossHPUI;





    void Start()
    {
       player= GameObject.FindWithTag("Player");
        bossHPUI= GetComponent<BossHPUI>();
        //GetComponent<Animator>();
        pattern = new int[10]; 
        pattern[0]=1;
        pattern[1]=2;
        pattern[2]=3;
        for(int i= 3;i<10;i++)
        {
            pattern[i]=Random.Range(1,3);
        }
         
    }

private void Awake() {
      bossAnim=  m_anim;
}
    // Update is called once per frame
    void Update()
    {
     
    }



    public void DoPattern(int pat)
    {
        patCount++;
        
        if(pat==1)
        {
            bossAnim.SetBool("Attack1",true);
            StartCoroutine(WaitBeIdle(pat));
             
        }
        else if(pat==2)
        {
        bossAnim.SetBool("Attack2",true);
        StartCoroutine(WaitBeIdle(pat));
         
        }
        else if(pat==3)
        {
        bossAnim.SetBool("Attack3",true);
        StartCoroutine(WaitBeIdle(pat));
        
        }
    }


IEnumerator WaitBeIdle(int pattern)
{if(pattern==1)
{
yield return new WaitForSeconds(2.5f);
 bossAnim.SetBool("Attack1",false);
}
else if(pattern==2)
{
yield return new WaitForSeconds(2.5f);
bossAnim.SetBool("Attack2",false);
}
else if(pattern==3)
{
yield return new WaitForSeconds(2.5f);
bossAnim.SetBool("Attack3",false);
}
}



private void OnTriggerEnter(Collider other) 
{
     if(other.gameObject.tag=="Player")
    {
        var comp= other.gameObject.GetComponent<Player>();
    
    }
}




override public  void Damage(float damage)
{
        health -= damage;

        if (health <= -0)
        {
            Collider cd = gameObject.GetComponent<Collider>();
            cd.enabled = false;
            StartCoroutine(BossDie());

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

       

        // m_anim.SetBool("GetHit",false);
        yield return null;


    }

    // Start is called before the first frame update


    private IEnumerator BossDie()
    {

        isDead = true;
        bossHPUI.UION=false;
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


        bossHPUI.BossUI.SetActive(false);
        Destroy(gameObject);
    }


public override void SethaveWaitTime()
{
    StartCoroutine(changeState());
}

IEnumerator  changeState()
{
    yield return new WaitForSeconds(waitTime);
    Debug.Log("changed!");
    HaveWaitTime= true;
   
}




























/////////////////////////////공격패턴 1

public void SpawnDragon()
{
     StartCoroutine(PatternStartTime(patternStartTime));

}

IEnumerator PatternStartTime(float time)
{
    yield return new WaitForSeconds(time);

    var dragon1 = Instantiate(monster[0],monsterSpawn[0].position,Quaternion.identity);
    dragon1.transform.SetParent(this.gameObject.transform);
    yield return new WaitForSeconds(0.1f);
    var dragon2 = Instantiate(monster[1],monsterSpawn[1].position,Quaternion.identity);
    yield return new WaitForSeconds(0.2f);
    var dragon3 = Instantiate(monster[2],monsterSpawn[2].position,Quaternion.identity);
 yield return new WaitForSeconds(0.5f);
    var dragon4 = Instantiate(monster[3],monsterSpawn[3].position,Quaternion.identity);
    yield return new WaitForSeconds(0.1f);
     var dragon5 = Instantiate(monster[4],monsterSpawn[4].position,Quaternion.identity);
     yield return new WaitForSeconds(0.1f);
      var dragon6 = Instantiate(monster[5],monsterSpawn[5].position,Quaternion.identity);
      yield return new WaitForSeconds(0.1f);
       var dragon7 = Instantiate(monster[6],monsterSpawn[6].position,Quaternion.identity);
       yield return new WaitForSeconds(0.2f);
        var dragon8 = Instantiate(monster[7],monsterSpawn[7].position,Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
         var dragon9 = Instantiate(monster[8],monsterSpawn[8].position,Quaternion.identity);
}

float elapsedTime = 0f;
        


public void BossLookMethod()
{
    StartCoroutine(BossLook());
}

private IEnumerator BossLook()
{
     Quaternion rotation = Quaternion.LookRotation(player.gameObject.transform.position-this.gameObject.transform.position);
         while (elapsedTime < 0.5f)
        {
            float t = elapsedTime / 0.5f;
            this.gameObject.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, rotation, t);

            elapsedTime += Time.deltaTime;
            yield return null; // 다음 프레임까지 대기
        }
    elapsedTime=0;
}      
           




///////////////////////////////공격패턴 2

public void MakeFireBall()
{
    GameObject fireball=GameObject.Instantiate(fireBall,fireBallTransform.position,Quaternion.identity);

    MoveAndScaleFireBall();
    Invoke("ChasePlayer",2f);
}

private void MoveAndScaleFireBall()
{
    fireBall.transform.DOMoveY(fireBall.transform.position.y+5f,2f);
    fireBall.transform.DOScale(Vector3.one*2f,2f);
}


}
