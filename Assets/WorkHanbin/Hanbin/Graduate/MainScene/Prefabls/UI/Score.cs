using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{



   int scoreInt;
    TMP_Text textScore;
    public  float score =0;
     
    
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
      textScore.text="0";
    }

    // Update is called once per frame
    void Update()
    {
     
    }


   public void IncreaseScore(float killscore)
    {
        this.score +=killscore;
         scoreInt= (int)this.score;
        textScore.text= scoreInt.ToString();
        GameManager.Instance.playerScore+=killscore;
    }

}