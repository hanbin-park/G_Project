using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManual : MonoBehaviour
{
    public GameObject Manuals;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Manuals.SetActive(true);
    }
}
