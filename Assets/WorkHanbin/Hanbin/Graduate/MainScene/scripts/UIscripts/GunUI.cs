using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GunUI : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject crossHead;
    public AutoTargetedMonsterUI autoTargetedMonsterUI;
    private Image crossHeadImageComp;
    public Sprite crossHeadImage;
    public Sprite crossHeadCheckedImage;


    public float boxdistance= 1.0f;

    public GameObject Gun;
    
    private Gun gun;
    private RectTransform crossHeadRect;
    public GameObject[] ammoUI;
    public GameObject targetGun;

    public LayerMask targetLayer;
    Gun gunInfo;
    int currentAmmo;

   

    
    // Start is called before the first frame update
    void Awake()
    {
        autoTargetedMonsterUI=GetComponent<AutoTargetedMonsterUI>();
        gun= Gun.GetComponent<Gun>();
        crossHeadImageComp=crossHead.GetComponent<Image>();
        Cursor.visible = false;
        crossHeadRect=crossHead.GetComponent<RectTransform>();
        gunInfo = targetGun.GetComponent<Gun>();
        currentAmmo = gunInfo.currentAmmo;
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 mousePos = Input.mousePosition;

        ChangeUI(mousePos);
        Ammo();
    }

private void ChangeUI(Vector3 mousePos)
    {
        Ray ray = playerCamera.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;
        bool isDetected = Physics.BoxCast(ray.origin, new Vector3(boxdistance,boxdistance,boxdistance), ray.direction, out hitInfo, Quaternion.identity, Mathf.Infinity, targetLayer);

        bool isDefaultLayer = (hitInfo.collider is not null) && (hitInfo.collider.gameObject.layer == 0);
        //Debug.Log(isDefaultLayer);
        if (!isDefaultLayer && isDetected)
        {
            
            
            gunInfo.IsMonsterInCrossHead=true;
            crossHeadImageComp.sprite = crossHeadCheckedImage;
          
           gunInfo.MonsterPos=hitInfo.collider.gameObject.transform.position;
  
           autoTargetedMonsterUI.targetedMonster  =hitInfo.collider.gameObject.transform;

     
        }
        else
        {
            gunInfo.IsMonsterInCrossHead=false;
            crossHeadImageComp.sprite = crossHeadImage;
            autoTargetedMonsterUI.targetedMonster=null;
        }

        crossHeadRect.position = mousePos;
    }

    private void Ammo()
    {
        if (currentAmmo != gunInfo.currentAmmo)
        {
            UpdateAmmoUI(gunInfo.currentAmmo);
            currentAmmo = gunInfo.currentAmmo;
        }
    }

    void UpdateAmmoUI(int amm)
    {

        {
            for (int i = 0; i < ammoUI.Length; i++)
            {
                if (i < gunInfo.currentAmmo)
                    ammoUI[i].SetActive(true);
                else
                    ammoUI[i].SetActive(false);
            }

        }


    }


    
}
