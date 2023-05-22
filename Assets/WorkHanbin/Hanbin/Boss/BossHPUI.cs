using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPUI : MonoBehaviour
{


    [SerializeField]
    private float lerpTimer = 0f;
    public float maxHealth = 1000;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image BackHealthBar;

    bool updateUI = false;

    public float fillSpeed = 3f;
    public GameObject BossUI;

    private Boss boss;
   
   public bool UIOn=false;

   public bool UION
   {
    get
    {
        return UIOn;
    }
    set
    {
        UIOn=value;
        if(UIOn)
        {
            BossUI.SetActive(true);
        }
        else if(!UIOn)
        {
            BossUI.SetActive(false);
        }
    }
   }

 private BossUITween bossUITween;





    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponent<Boss>();
        maxHealth = boss.health;
       bossUITween=BossUI.GetComponent<BossUITween>();
        // StartCoroutine(Addhealth());
    }

    // Update is called once per frame
    void Update()
    {
        boss.health = Mathf.Clamp(boss.health, 0, maxHealth);
        UpdateHealthUI();
        if(boss.haveWaitTime)
        {
            UION=true;
        }
        
    }

    public void UpdateHealthUI()
    {

        float fillF = frontHealthBar.fillAmount;
        float fillB = BackHealthBar.fillAmount;
        float hFraction = boss.health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            BackHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;

            BackHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            BackHealthBar.color = Color.green;
            BackHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;

            frontHealthBar.fillAmount = Mathf.Lerp(fillF, BackHealthBar.fillAmount, percentComplete);
        }
    }



    // IEnumerator Addhealth()
    // {frontHealthBar.fillAmount=0;
    //    BackHealthBar.fillAmount=0;
    //     while(frontHealthBar.fillAmount<=1)
    //     {
    //         frontHealthBar.fillAmount+=Time.deltaTime/fillSpeed;
    //     BackHealthBar.fillAmount+=Time.deltaTime/fillSpeed;
    //     yield return null;
    //     }
    //     if(frontHealthBar.fillAmount>=1)
    //     updateUI=true;
    // }

}
