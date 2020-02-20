using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurtleMove : MonsterMove
{
    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        startMoveTime = 5f;
    }
    
    protected override void MoveAniPlay() => animator.SetBool("isMoving",true);

    protected override void MoveAniStop() => animator.SetBool("isMoving", false);
}