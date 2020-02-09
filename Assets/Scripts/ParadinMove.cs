using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadinMove : UnitMove
{
    protected override void CharMove(Vector3 moveTargetPos)
    {      
        navMeshAgent.SetDestination(moveTargetPos);
        MovingAnimation();
    }
    protected override void MovingAnimation()
    {       
        if(IsNotArrived())
            MoveAniPlay();
        else
            MoveAniStop();
    }
    protected override void MoveAniPlay()
    {
        Debug.Log(gameObject.name +" is Moving");
        animator.SetBool("isWalking",true); 
    }
    protected override void MoveAniStop()
    {
        Debug.Log(gameObject.name +" is Stopped");
        animator.SetBool("isWalking",false); 
    }
    protected override void Attack()
    {
        animator.SetTrigger("isAttacking");
    }
    protected override bool IsNotArrived()
    {
        if((Mathf.Abs(moveTargetPos.x - transform.position.x) > 2f)||(Mathf.Abs(moveTargetPos.z - transform.position.z) >2f))
            return true;
        else
        {
            clickPoint.gameObject.SetActive(false);
            return false;
        }
    }
}
