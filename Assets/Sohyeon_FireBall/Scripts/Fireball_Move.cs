using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Move : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float fireball_Rate;

    public GameObject Fireball_Hit;  // hit prefab에 대한 게임 오브젝트 생성

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No Speed");
        }
    }


    //충돌이 총알도 아니고 플레이어도 아닌 경우. 이것이 한 번만 충돌하는지 확인하는 것이므로 개인 부울 생성
    private bool collided;

    private void OnCollisionEnter(Collision co)
    {
        //speed = 0;

        //Destroy(gameObject);

        

        // 만약 gameobject.tag가 Bullet도 아니고 Player도 아닌 경우 (기본적으로 플레이어 및 다른 발사체와 충돌하는 것을 원하지 않음)
        if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided)
        {
            collided = true;         // 일단 충돌하면 true

            // co.contacts[0].point인 충돌 위치에서 인스턴스화. 0번 인덱스?는 첫 번째 충돌점. Quaternion.identity = prefab 회전   /  as GameObject : 게임 오브젝트인지 확인
            var impact = Instantiate(Fireball_Hit, co.contacts[0].point, Quaternion.identity) as GameObject;
            Destroy(impact, 2);

            Destroy(gameObject);
        }

    }


    // OnCollisionenter 함수 이용
    //private void OnCollisionEnter(Collision co)
    //{
    //   speed = 0;

        /*
         ContactPoint contact = co.contacts[0];
         Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
         Vector3 pos = contact.point;

         if (hitPrefab != null)
         {
             var hitVFX = Instantiate(hitPrefab, pos, rot);

             var psHit = hitVFX.GetComponent<ParticleSystem>();
             if (psHit != hitVFX)
                 Destroy(hitVFX, psHit.main.duration);
             else
             {
                 var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                 Destroy(hitVFX, psChild.main.duration);
             }

         }

         */

     //   Destroy(gameObject);

    //}

    /*
    // OnTriggerEnter 함수 이용
    // 파이어볼이 총알에 맞으면 destroy
    private void OnTriggerEnter(Collider co)
    {

        if (co.gameObject.tag == "vfx_Projectile_Tutorial 태그 이름")
        {
            speed = 0;

            Destroy(this.gameObject);

        }
    }
     */
}
