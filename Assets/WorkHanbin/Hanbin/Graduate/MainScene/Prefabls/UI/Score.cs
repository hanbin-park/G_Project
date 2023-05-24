using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Score : MonoBehaviour
{

    TMP_Text textScore;
       
    public static int getScore = 0;    

     private void Awake() 
    {
        var objs= FindObjectsOfType<Score>();
        if(objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
       
    }
    void Start()
    {
        textScore=GetComponent<TMP_Text>();
        textScore.text = ScoreManager.Instance.score.ToString();
    }

   public void IncreaseScore()
    {
        textScore.text = ScoreManager.Instance.score.ToString();

        textScore.transform.DOScale(1.5f, 0.1f).OnComplete
        (() =>
        {
            textScore.transform.DOScale(1f, 0.1f);

        });
    }    
}