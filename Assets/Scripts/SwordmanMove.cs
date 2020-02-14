using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwordmanMove : PlayerMove
{
    private void Start()
    {
        attackRange = 2;
        attackDelay = 0.25f;
        ATK = 45;
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
        if (!(timer > attackDelay)) 
            return;
        base.Attack();
        animator.SetTrigger("isAttacking");
        timer = 0.0f;
    }
    
    protected override void MoveAniPlay() => animator.SetBool("isMoving", true);
    protected override void MoveAniStop() => animator.SetBool("isMoving",false);
}
