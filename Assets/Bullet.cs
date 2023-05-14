using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamageable
{
   
    GameObject player = null;



    [SerializeField]
    float speed = 3.0f;
    private float currentSpeed =0;
    [SerializeField]
    //LayerMask layerMask = 6;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        player= GameObject.Find("cineCamera");////////////////////////////////////////////이거 수정할것!
     
    }

   
    void Update()
    {
  
            if(currentSpeed<=speed )
             currentSpeed += speed*Time.deltaTime;

             transform.position += transform.up * currentSpeed *Time.deltaTime;

             Vector3 direction= (player.transform.position-transform.position).normalized;
             transform.up= Vector3.Lerp(transform.up,direction,0.25f);
 
    }
  private void OnTriggerEnter(Collider other)
  {
    if(other.tag=="Player")
    {
        Destroy(gameObject);
        
    }
  }

    public void Damage(int damage)
    {
       Destroy(gameObject);
    }
}
