using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class managerWeaponUI : MonoBehaviour
{
    public Image prefabUI;
    private Image uiUse;

    private GameObject objPlayer;
    private float time;

    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Vector3 addPosition;
    [SerializeField]
    private float radius = 1;
    [SerializeField]
    private float floatingspeed = 2;
    [SerializeField]



    private void OnEnable() 
    {
        objPlayer=GameObject.FindGameObjectWithTag("Player");
        uiUse = Instantiate(prefabUI, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        MoveUpDown();
      

    }
    private void OnDestroy() 
    {
        Destroy(uiUse);
    }

  

    private void MoveUpDown()//상하 운동
    {
        float y = radius * Mathf.Cos(time * floatingspeed);
        Vector3 floating = new Vector3(0, y, 0);
        uiUse.transform.position = mainCamera.WorldToScreenPoint(transform.position + addPosition + floating);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag== "Player")
            this.gameObject.GetComponent<managerWeaponUI>().enabled=true;

        
    }
    private void OnTriggerExit(Collider other)//
    {
        if (other.tag== "Player")
        {Destroy(uiUse);
        this.gameObject.GetComponent<managerWeaponUI>().enabled=false;
        
        }
      
    }








}
