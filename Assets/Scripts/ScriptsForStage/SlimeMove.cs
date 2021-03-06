﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SlimeMove : MonsterMove
{
    #region variables
    private static readonly int kMoveSpeed = Animator.StringToHash("MoveSpeed");
    private static readonly int kAttackTrigger = Animator.StringToHash("AttackTrigger");
    #endregion

    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        startMoveTime = 5f;
    }
    protected override void MoveAniPlay() => animator.SetFloat(kMoveSpeed,1);
    protected override void MoveAniStop() => animator.SetFloat(kMoveSpeed,0);
}
