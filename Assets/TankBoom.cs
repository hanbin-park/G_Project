using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBoom : MonoBehaviour
{
    public GameObject TimeLineBoom;

    public GameObject WithTank;

    public GameObject scoreUI;

    public void Boom()
    {
        ScoreManager.Instance.score += 500;
        scoreUI.GetComponent<Score>().IncreaseScore();
        GameManager.Instance.monsterCount = 0;
        Destroy(WithTank);
        TimeLineBoom.SetActive(true);
    }

}
