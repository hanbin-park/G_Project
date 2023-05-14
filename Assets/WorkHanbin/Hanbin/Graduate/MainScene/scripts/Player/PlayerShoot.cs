using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
   public static Action shootInput;
   public static Action reloadInput;

   private Vector3 mousePos;

 private void Update() 
 {
   mousePos = Input.mousePosition;

    if(Input.GetMouseButton(0))
    {
        shootInput?.Invoke(); 
    }

   if(mousePos.y >= 980)
   {
      reloadInput?.Invoke();
   }
 }

}
