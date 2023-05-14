using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    [SerializeField]
    GameObject stage;
    
    
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
        if(other.gameObject.CompareTag("Player"))
        {
            if(stage.GetComponent<Stage>()!=null)
            {
                var compo= stage.GetComponent<Stage>();
                compo.movePosition();
                Destroy(gameObject,0.25f);
            }
        }
    }
}
