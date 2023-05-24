using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack3 : StateMachineBehaviour
{
    private Boss boss;


    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       boss=animator.GetComponent<Boss>();
       if(boss.giveweapon==false)
       {
        boss.giveweapon=true;
        Instantiate(boss.giveDropWeapon,boss.WeaponPos.position,Quaternion.identity,boss.gameObject.transform);;
   
       }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }







 
}
