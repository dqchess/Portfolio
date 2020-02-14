using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParadinMove : PlayerMove
{
    private static readonly int kIsWalking = Animator.StringToHash("isWalking");
    private static readonly int kIsAttacking = Animator.StringToHash("isAttacking");
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
        enemys = new List<GameObject>();
        moveTargetPos = new Vector3(0,0,0);
    }
    protected override void Attack()
    {
        base.Attack();
        if (timer>attackDelay)
        {
            animator.SetTrigger(kIsAttacking);
            timer = 0.0f;
        }
    }
    protected override void MoveAniPlay() => animator.SetBool(kIsWalking,true);
    protected override void MoveAniStop() => animator.SetBool(kIsWalking,false); 
}
