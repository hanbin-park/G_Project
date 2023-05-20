using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcom : MonoBehaviour
{

  
public GameObject[] dragon;

public GameObject[] pos;
private void Start() {
    
   


    Instantiate(dragon[0],pos[0].transform.position,pos[0].transform.rotation);
     Instantiate(dragon[1],pos[1].transform.position,pos[1].transform.rotation);
      Instantiate(dragon[2],pos[2].transform.position,pos[2].transform.rotation);
}

}
