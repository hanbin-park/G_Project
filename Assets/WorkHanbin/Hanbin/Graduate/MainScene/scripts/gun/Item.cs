using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type { Hand, Pistol, MachineGun, Cannon };
    public Type type;
    public int value;
    public int rotateSpeed;

    private void Start()
    {

        value = (int)type;
    }


    private void Update()
    {
        if (value == 3)
        {
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }
}
