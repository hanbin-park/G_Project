using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    public GameObject stage; //다음 스테이지

    public GameObject monsterSet; //몬스터 활성화 콜라이더 on

    public int monsterNum; //이번 스테이지 총 몬스터 수

    public int clearMonsterNum = 0; //클리어 한 몬스터 수(점점 더하기)

    void Update()
    {
        if(clearMonsterNum == monsterNum)
        {
            stage.SetActive(true);
            monsterSet.SetActive(true);
            clearMonsterNum = 0;
            this.gameObject.SetActive(false);
            GameObject[] monsterBullet = GameObject.FindGameObjectsWithTag("Bullet");
            for (int i = 0; i < monsterBullet.Length; i++)
            {
                Destroy(monsterBullet[i]);
            }
            
        }
    }
}
