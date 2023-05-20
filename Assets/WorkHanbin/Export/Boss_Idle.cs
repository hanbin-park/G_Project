using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Idle : StateMachineBehaviour
{
    enum state {pattern1,pattern2,pattern3};
    Transform BossTransform;
    public Boss boss;
    public bool patternOn;
    float patterntime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BossTransform = animator.GetComponent<Transform>();
        boss = animator.GetComponent<Boss>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss.haveWaitTime)
        {
            if (patternOn)
            {
                patterntime += Time.deltaTime;
            }
            if (patterntime > 3.0f)

            {
                patternOn = false;
                patterntime = 0;

                boss.DoPattern(boss.pattern[boss.patCount]);
            }
        }






    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
