using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyStart : MonoBehaviour
{   
    public GameObject Video;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Video.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
