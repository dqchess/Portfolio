using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParadinMove : PlayerMove
{
    private static readonly int walkingAniID = Animator.StringToHash("isWalking");
    private static readonly int attackAniID = Animator.StringToHash("isAttacking");
    private void Start()
    {
        attackRange = 2;   
        attackDelay = 3;
        ATK = 50;
    }
    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        moveTargetPos = Vector3.zero;
    }
    protected override void Attack()
    {
        base.Attack();
        if (timer>attackDelay)
        {
            animator.SetTrigger(attackAniID);
            timer = 0.0f;
        }
    }
    protected override void MoveAniPlay() => animator.SetBool(walkingAniID,true);
    protected override void MoveAniStop() => animator.SetBool(walkingAniID,false); 
}
