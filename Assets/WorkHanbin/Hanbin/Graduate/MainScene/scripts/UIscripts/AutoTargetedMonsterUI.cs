using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoTargetedMonsterUI : MonoBehaviour
{
    public Transform targetedMonster=null;

    public bool Istargeted =false;


    [Header("직접 갔다놓아서 변경 할 것들")]
    public Camera Player;
    public GameObject targetedUI;
    void Start()
    {
        
    }

    public AudioSource hitOn;

    // Update is called once per frame
    void Update()
    {
    
        if(targetedMonster !=null)
        {
            
            targetedUI.SetActive(true);
        
            
            Vector3 monsterPos = Player.WorldToScreenPoint(targetedMonster.transform.position);

            targetedUI.transform.position=new Vector3(monsterPos.x,monsterPos.y,0);
            
            
            
        }
        else
        {
            targetedUI.SetActive(false);
            hitOn.Play();
        }
        
    }
}
