using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankLight : MonoBehaviour
{
    public GameObject Light;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Light.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Light.SetActive(false);
        }
    }

}
