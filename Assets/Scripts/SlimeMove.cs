using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SlimeMove : MonsterMove
{
    private static readonly int kMoveSpeed = Animator.StringToHash("MoveSpeed");
    private static readonly int kAttackTrigger = Animator.StringToHash("AttackTrigger");

    private void Start()
    {
        base.Start();
        attackRange = 2;
        ATK = 5;
    }
    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        startMoveTime = 5f;
    }
    protected override void MoveAniPlay() => animator.SetFloat(kMoveSpeed,1);
    protected override void MoveAniStop() => animator.SetFloat(kMoveSpeed,0);
}
