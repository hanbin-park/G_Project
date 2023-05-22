using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossUITween : MonoBehaviour
{

  


    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        this.transform.DOLocalMoveY(-2,3).SetEase(Ease.OutCubic);
    }
    private void OnDisable() {
        
    }
    public void GoUP()
    {
        this.transform.DOLocalMoveY(30,3).SetEase(Ease.OutCubic);
    }
    
}
