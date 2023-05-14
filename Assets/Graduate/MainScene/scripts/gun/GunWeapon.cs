using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NewBehaviourScript : MonoBehaviour
{
[Header("Info")]
    public new string name="gun";

[Header("Shooting")]
    public float damage=40;
    public float maxDistance;

[Header("Reloading")]
    public int currentAmmo=10;
    public int magSize=10;
    public float fireRate=600;
    public float reloadTime;
    
[HideInInspector]
    public bool reloading; 























}
