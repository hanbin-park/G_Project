using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class off61 : MonoBehaviour
{
    public GameObject cam;

    private void OnTriggerEnter(Collider other)
    {
        cam.SetActive(false);
    }
}
