using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunUI : MonoBehaviour
{

    public GameObject crossHead;
    private RectTransform crossHeadRect;
    public GameObject[] ammoUI;

    public GameObject targetGun;

    Gun gunInfo;

    int currentAmmo;

    
    // Start is called before the first frame update
    void Awake()
    {
       Cursor.visible = false;
        crossHeadRect=crossHead.GetComponent<RectTransform>();
        gunInfo = targetGun.GetComponent<Gun>();
        currentAmmo = gunInfo.currentAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        crossHeadRect.position = mousePos;
        Ammo();
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