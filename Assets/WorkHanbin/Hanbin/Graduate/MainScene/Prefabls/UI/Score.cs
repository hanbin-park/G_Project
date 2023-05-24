using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
        textScore.text="점수: "+ ScoreManager.Instance.score;
    }


   public void IncreaseScore()
    {
        textScore.text= "점수: " + ScoreManager.Instance.score;
    }

}