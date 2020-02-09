﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadinMove : UnitMove
{
    void Start()
    {
        attackRange = 2;   
    }
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
        animator.SetBool("isWalking",true); 
    }
    protected override void MoveAniStop()
    {
        animator.SetBool("isWalking",false); 
    }
    protected override void Attack()
    {
        animator.SetTrigger("isAttacking");
    }
    protected override bool IsNotArrived()
    {
        if((Mathf.Abs(moveTargetPos.x - transform.position.x) > 3f)||(Mathf.Abs(moveTargetPos.z - transform.position.z) >3f))
            return true;
        else
        {
            clickPoint.gameObject.SetActive(false);
            return false;
        }
    }
}