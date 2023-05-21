using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHPUI : MonoBehaviour
{

    private float health;
    [SerializeField]
    private float lerpTimer = 1f;
    public float maxHealth = 1000;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image BackHealthBar;



    private Boss boss;







    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        boss= GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {

    }

    

}
