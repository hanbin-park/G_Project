 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{

    
    int checkDieMonster = 0;

   
    [SerializeField]
    private float downMoveDistance= 9;

    void Start()
    {
       
    }

    void Update()
    {

    }

    public void movePosition()
    {
            gameObject.transform.position+= new Vector3(0,-this.downMoveDistance,0);
            
    }



  private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            GameManager.Instance.monsterCount++;

            var monsterScript = other.gameObject.GetComponent<Monster>();
            if(monsterScript!=null)  //addition!
            {
                monsterScript.SethaveWaitTime();
            }
           Destroy(this.gameObject,0.1f);
        }
    }
}


