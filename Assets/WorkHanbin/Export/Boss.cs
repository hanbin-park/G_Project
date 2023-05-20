using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    [Header("보스패턴 정형화")]

    public  bool patternOn;
    public int[] pattern;
    public int patCount=0;

    [Header("보스패턴1")]
    public Transform[] monsterSpawn;
   public GameObject[] monster;
  public  float patternStartTime;


Animator bossAnim;



    [Header("보스패턴2")]
//플레이어에게 다가오고 그동안 약점 3곳 때리기

    Transform[] RandomPos;
    
    void Start()
    {
        bossAnim=GetComponent<Animator>();
        pattern = new int[10]; 
        pattern[0]=1;
        pattern[1]=2;
        pattern[2]=3;
        for(int i= 3;i<10;i++)
        {
            pattern[i]=Random.Range(1,3);
        }
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




private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag=="Player")
    {
        var comp= other.gameObject.GetComponent<Player>();
    
    }
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

}




}
