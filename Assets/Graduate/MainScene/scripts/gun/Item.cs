using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type{Hand,Pistol,MachineGun,Granade};
    public Type type;
    public int value;
    public int rotateSpeed;

    private void Start() {
        
        value= (int)type;
    }


    private void Update() 
    {
        transform.Rotate(Vector3.up*rotateSpeed*Time.deltaTime);
    }
}
