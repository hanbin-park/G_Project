using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcom : MonoBehaviour
{

  




    // public LayerMask layerMask;


 
    // public GameObject player;
    // public Camera camera2;
    // public GameObject ui;
    // public RectTransform uiRect;

    // public float uiWidth =0;
    // public float uiHeight = 0; 

    // public float boxSize =1.0f;
    
    // // Start is called before the first frame update
    // void Awake()
    // {
    //  uiRect= ui.gameObject.GetComponent<RectTransform>();   
    //  uiWidth= uiRect.rect.width;
    //  uiHeight= uiRect.rect.height;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     IsObjectInCrossHead();

    // }

    // private void IsObjectInCrossHead()
    // {
    //     Vector3 mousePos = Input.mousePosition;

    //     Ray ray = camera2.ScreenPointToRay(Input.mousePosition);

    //     RaycastHit hitInfo;
    //     Debug.DrawRay(ray.origin, ray.direction * 20, Color.black, 10);
    //     if (Physics.BoxCast(ray.origin, new Vector3(1, 1, 1), ray.direction, out hitInfo, Quaternion.identity, Mathf.Infinity, layerMask))
    //     {
    //         Debug.Log(hitInfo.collider.name);
    //     }
    // }


}
