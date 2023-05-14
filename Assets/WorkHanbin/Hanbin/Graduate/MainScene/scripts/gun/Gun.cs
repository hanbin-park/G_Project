using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Camera playerCamera;

    public GunUI gunUI;
   
    public ParticleSystem muzzleFlashVFX;
    private GameObject targetMonster;
    AudioSource shootSound;
    public float sensitivity = 2;
    float timeSinceLastShot;

    [Header("Info")]
    public new string name = "gun";
    public LayerMask targetLayer;

    [Header("Shooting")]
    public int damage = 40;


    [Header("Reloading")]
    public int currentAmmo = 10;
    public int magSize = 10;
    public float fireRate = 600;
    public float reloadTime;

    [HideInInspector]
    public bool reloading;
    
    [HideInInspector]
    public bool IsMonsterInCrossHead;
    //CrossHead 안쪽에 부딪혔을때
    public Transform parentTransform;
    public Vector3 MonsterPos;
    private void OnEnable()
    {
        
        gunUI=GetComponent<GunUI>();
        shootSound = GetComponent<AudioSource>();
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
        parentTransform = transform.parent;
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        GunMove();
  
        // Debug.DrawRay(ray.origin, ray.direction * 20, Color.black, 10);

    }



    private bool CanShoot() => !reloading && timeSinceLastShot > 1f / (fireRate / 60f);



    private void Shoot()
    {

        {
            if (currentAmmo > 0) //현재총알이 0보다 많으면
            {
                if (CanShoot())//연사속도보다 시간지나고 재장전중이 아니면
                {

                    
                    shootSound.Play();
                    muzzleFlashVFX.Play();
                   
                    if(!IsMonsterInCrossHead)
                    {
                        rayshoot();
                    }
                    if(IsMonsterInCrossHead)
                    {
                       
                       rayshoot( MonsterPos);
                    }
                }
            }
        }
    }

    private void rayshoot(Vector3 monsterPos )
    {
        Vector3 screenPosition = playerCamera.WorldToScreenPoint(monsterPos);
        Ray ray = playerCamera.ScreenPointToRay(screenPosition);
        // 레이캐스트가 부딪힌 물체 정보를 저장할 변수를 선언합니다.
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // 레이캐스트가 부딪힌 물체의 정보를 출력합니다.
            Debug.Log("Hit object: " + hit.collider.name);

            if (hit.collider.tag == "Monster")
            {

                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                damageable?.Damage(damage);
            }
            else if(hit.collider.tag =="Bullet")
            {
                Destroy(hit.collider.gameObject);
            }
        }

        currentAmmo--;
        timeSinceLastShot = 0;
    }





    protected virtual void rayshoot()
    {
        // 마우스 클릭 지점의 좌표를 구합니다.
        Vector3 mousePos = Input.mousePosition;
        // 카메라에서 마우스 클릭 지점의 좌표로 레이를 쏩니다.
        Ray ray = playerCamera.ScreenPointToRay(mousePos);
        // 레이캐스트가 부딪힌 물체 정보를 저장할 변수를 선언합니다.
        RaycastHit hit;
        // 레이캐스트를 쏩니다. 레이캐스트가 부딪힌 물체가 있으면 true를 반환합니다.
        if (Physics.Raycast(ray, out hit))
        {
            // 레이캐스트가 부딪힌 물체의 정보를 출력합니다.
            Debug.Log("Hit object: " + hit.collider.name);

            if (hit.collider.tag == "Monster")
            {

                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                damageable?.Damage(damage);
            }
            else if(hit.collider.tag =="Bullet")
            {
                Destroy(hit.collider.gameObject);
            }
        }

        currentAmmo--;
        timeSinceLastShot = 0;
    }



    private void OnDisable()
    {

        PlayerShoot.shootInput -= Shoot;
        PlayerShoot.reloadInput -= StartReload;
    }


    protected virtual void GunMove()
    {
        float mouseX = Input.mousePosition.x; // 마우스의 X 위치
        float mouseY = Input.mousePosition.y; // 마우스의 Y 위치



        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 direction = new Vector3(mouseX, mouseY, 0) - screenCenter;

        // 회전할 각도를 계산합니다.
        float rotationX = (direction.y / Screen.height) * sensitivity * 18.0f;
        float rotationY = (direction.x / Screen.width) * sensitivity * 18.0f;
        // 물체를 회전합니다.-rotationXrotationY

        Quaternion parentRotation = parentTransform.rotation;
        Quaternion inverseParentRotation = Quaternion.Inverse(parentRotation);


        transform.rotation = parentRotation * Quaternion.Euler(-rotationX, rotationY, 0);

    }

    public void StartReload()
    {
        if(currentAmmo == magSize)
        {
            return;
        }

        if (!reloading)
        {
            StartCoroutine(Reload());
        }
    }

    public AudioSource reloadGun;

    private IEnumerator Reload()
    {
        reloadGun.Play();
        reloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = magSize;
        reloading = false;


    }

     private IEnumerator DeactivateMuzzleFlash(GameObject instance, float delay)
    {
        yield return new WaitForSeconds(delay);
        instance.SetActive(false);
    }

}
