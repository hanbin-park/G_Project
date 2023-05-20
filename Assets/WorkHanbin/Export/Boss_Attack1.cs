using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack1 : StateMachineBehaviour
{
   int monsterCount=3;
    Boss_Idle boss_Idle;
   Boss boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       boss= animator.GetComponent<Boss>();
        
        boss.SpawnDragon();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

 

    void DestroyedMonster()
    {
            monsterCount--;
            if(monsterCount==0)
            {
                boss.patternOn=true;
                monsterCount=3;
            }
    }




}
