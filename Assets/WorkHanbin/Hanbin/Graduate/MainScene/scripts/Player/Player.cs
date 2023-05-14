using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject[] HPImage;

    [Header("player정보")]


    [SerializeField]
    private int maxhp=3;
    private int hp;

    public float score=0;

    [Header("Ingame요소들")]
   
   public Camera PlayerCamera;
    

    public GameObject[] weapons;//가지고있는 무기 구분
    ////////////////////////////////addition
    public GameObject[] weaponUI;//갖고있는 무기에 따른 UI


    //////////////////////addition
    public bool[] hasWeapon; //가지고 있는지 체크



    public GameObject nearOjbect;
    private GameObject equipWeapon;



    public GameObject HitUI;

    public GameObject timeline1;

    void Start()
    {
        hp=maxhp;
  PlayerShoot.shootInput += ShootRay;
    }

    // Update is called once per frame
    void Update()
    {
        ShootRay();
      


      
    }

   

    private void ShootRay()
    {
        Vector3 mousePos = Input.mousePosition;
        // 카메라에서 마우스 클릭 지점의 좌표로 레이를 쏩니다.
        Ray ray = PlayerCamera.ScreenPointToRay(mousePos);
        // 레이캐스트가 부딪힌 물체 정보를 저장할 변수를 선언합니다.
        RaycastHit hit;
        // 레이캐스트를 쏩니다. 레이캐스트가 부딪힌 물체가 있으면 true를 반환합니다.
        if (Physics.Raycast(ray, out hit))
        {
            
           if(Input.GetMouseButtonDown(0))
            {        

                
                if(hit.collider.gameObject.tag == "Weapon")
                    Interaction();
            }


        }
    }

    public GameObject introTimeLine;
    public AudioSource bgm;
    public AudioSource getGun;


    void Interaction()
    {
        if (nearOjbect != null)//주변에 물건이 있으면
        {
            if (nearOjbect.tag == "Weapon")//그게 무기이면
            {
                Debug.Log("hit!!!!");
                Item item = nearOjbect.GetComponent<Item>();//아이템 정보가져와서 인덱스에 기록
                int weaponIndex = item.value;

                for(int index=0;index<hasWeapon.Length;index++)
                {
                hasWeapon[index] = false;
                weaponUI[index].SetActive(false);
                }

                //갖고있는 무기체크 후 그거에 맞는 UI on
                hasWeapon[weaponIndex]= true;
                weaponUI[weaponIndex].SetActive(true);




                if(equipWeapon!=null)//이미 무기를 가지고있으면
                  equipWeapon.SetActive(false);

                equipWeapon=weapons[weaponIndex];
                equipWeapon.SetActive(true);
                
                
                introTimeLine.SetActive(false);
                bgm.Play();
                getGun.Play();

                HPImage[0].SetActive(true);
                HPImage[1].SetActive(true);
                HPImage[2].SetActive(true);

                timeline1.SetActive(true);
                Destroy(nearOjbect);//집은 무기는 삭제
                nearOjbect = null;
            }
        }
    }
//add

    private void OnTriggerEnter(Collider other) 
    {
    if (other.tag == "Monster")
            {
                hp--;
                UpdateLifeIcon(hp);
                if(hp==0)
                {
                    EndScene();
                }
                HitUI.SetActive(true);

            }
            else if(other.tag == "Bullet")
            {
                hp--;
                UpdateLifeIcon(hp);
                if(hp==0)
                {
                    EndScene();
                }
                HitUI.SetActive(true);
            
            }
        
    }

//add

    private void OnTriggerStay(Collider other)
    {
       if (other.tag == "Weapon")
       {
            nearOjbect = other.gameObject;
       }

    /*
        Debug.Log(nearOjbect.name);
    */   
    }
    private void OnTriggerExit(Collider other)//
    {
        
        if (other.tag == "Weapon")
            nearOjbect = null;
           

    }

    public void UpdateLifeIcon(int life)
    {
        for(int index=0;index<3;index++)
        {
            HPImage[index].SetActive(false);
        }

        for(int index=0;index<life;index++)
        {
            HPImage[index].SetActive(true);
        }


    }

     void EndScene()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("EndScene");
    }



}
