using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeMove : MonsterMove
{
    private void Start()
    {
        attackRange = 2;
        attackDelay = 3;
        ATK = 5;
    }
    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemys = new List<GameObject>();
    }
    protected override void Attack()
    {
        if (!(timer > attackDelay)) 
            return;
        animator.SetTrigger("AttackTrigger");
        timer = 0.0f;
    }
    protected override void MoveAniPlay() => animator.SetFloat("MoveSpeed",1);
    protected override void MoveAniStop() => animator.SetFloat("MoveSpeed",0);
}
