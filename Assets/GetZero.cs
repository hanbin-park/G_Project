using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetZero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            GameManager.Instance.monsterCount = 0;
        }
    }
}
