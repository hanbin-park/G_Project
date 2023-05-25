using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack3 : StateMachineBehaviour
{
    bool giveWeapon= false;

    Boss boss;

    Collider col;

   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
        boss=animator.GetComponent<Boss>();
          col=boss.gameObject.GetComponent<Collider>();
        col.enabled=false;
       if(giveWeapon==false)
       {
         giveWeapon=true;
          boss.cannonWeapon.SetActive(true);
       
       }

        


    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
       
      
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

 
}
