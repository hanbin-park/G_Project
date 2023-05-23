using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyImageNext : MonoBehaviour
{
    public GameObject next;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(N());
        }
    
    }

    IEnumerator N()
    {
        next.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
