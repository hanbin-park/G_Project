using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyStart : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.gameObject.SetActive(false);
        }
    }
}
