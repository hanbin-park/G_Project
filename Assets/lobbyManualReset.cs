using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lobbyManualReset : MonoBehaviour
{
    public GameObject Manuals;

    public GameObject image1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(R());
        }
    }

    IEnumerator R()
    {
        Manuals.SetActive(false);
        image1.SetActive(true);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
