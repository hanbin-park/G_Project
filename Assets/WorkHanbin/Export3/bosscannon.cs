using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosscannon : MonoBehaviour
{
    private GameObject boss;
    private Boss bossScript;
    // Start is called before the first frame update
    void Start()
    {
        boss=GameObject.Find("Boss_RED");
        bossScript= boss.GetComponent<Boss>();
     bossScript.IsAttacked=true;
    }

private void OnEnable() {
   
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
