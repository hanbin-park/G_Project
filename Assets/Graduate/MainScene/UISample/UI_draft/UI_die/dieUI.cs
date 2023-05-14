using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dieUI : MonoBehaviour
{
   

   

Image uiImage ;

public  float disappearTime= 1;
float alpha =0;
public float timer ;
    // Start is called before the first frame update
    void Awake()
    {
        uiImage=GetComponent<Image>();

        alpha= uiImage.color.a;
        timer= 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        float alpha = 1f - Mathf.Clamp01(timer / disappearTime);
        
        uiImage.color = new Color(uiImage.color.r, uiImage.color.g, uiImage.color.b, alpha);
        if (timer >= disappearTime)
        {
            timer=0;
            gameObject.SetActive(false);
        }


    }




}
