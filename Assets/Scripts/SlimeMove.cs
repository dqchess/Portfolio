﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SlimeMove : MonsterMove
{
    private static readonly int kMoveSpeed = Animator.StringToHash("MoveSpeed");
    private static readonly int kAttackTrigger = Animator.StringToHash("AttackTrigger");

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
    }
    protected override void Attack()
    {
        if (!(timer > attackDelay)) 
            return;
        animator.SetTrigger(kAttackTrigger);
        timer = 0.0f;
    }
    protected override void MoveAniPlay() => animator.SetFloat(kMoveSpeed,1);
    protected override void MoveAniStop() => animator.SetFloat(kMoveSpeed,0);
}
