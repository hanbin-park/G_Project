using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Gun",menuName ="Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public new string name;

[Header("Shooting")]
    public float damage;
    public float maxDistance;

[Header("Reloading")]
    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloadTime;
    
    [HideInInspector]
    public bool reloading;


    public float sensitivity = 2f; // 회전 감도



   private void Start() 
   {
  
   }



    void Update()
    {




    }

    
    
    
    









/*
       GunMove();
    private void GunMove()
    {
        float mouseX = Input.mousePosition.x; // 마우스의 X 위치
        float mouseY = Input.mousePosition.y; // 마우스의 Y 위치


        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 direction = new Vector3(mouseX, mouseY, 0) - screenCenter;

        // 회전할 각도를 계산합니다.
        float rotationX = (direction.y / Screen.height) * sensitivity * 18.0f;
        float rotationY = (direction.x / Screen.width) * sensitivity * 18.0f;
        // 물체를 회전합니다.
        transform.rotation = Quaternion.Euler(-rotationX, rotationY, 0);
    }
*/
}

