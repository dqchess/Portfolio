using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanMove : UnitMove
{

    void Start()
    {
        attackRange = 1;
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
        animator.SetBool("Moving",true);
        animator.SetFloat("Velocity X", moveTargetPos.x - transform.position.x);
        animator.SetFloat("Velocity Z", moveTargetPos.z - transform.position.z);   
    }
    protected override void MoveAniStop()
    {
        animator.SetBool("Moving",false);
        animator.SetFloat("Velocity X", 0);
        animator.SetFloat("Velocity Z", 0);   
    }
    protected override void Attack()
    {
        animator.SetTrigger("AttackTrigger");
        animator.SetBool("Moving",true);
        animator.SetInteger("Weapon",1);
        animator.SetInteger("Action",1);
    }
    void FootL()
    {
        //구매한 에셋에 있는 Read-only 애니메이션 이벤트 때문에 만든 빈 함수
    }
    void FootR()
    {
        //구매한 에셋에 있는 Read-only 애니메이션 이벤트 때문에 만든 빈 함수
    }
    void Hit()
    {
        //구매한 에셋에 있는 Read-only 애니메이션 이벤트 때문에 만든 빈 함수
    }
}
