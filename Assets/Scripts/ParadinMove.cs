﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParadinMove : PlayerMove
{       
    protected override void Awake()
    {
        clickPoint = GameObject.FindGameObjectWithTag("clickPoint").transform;
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemys = new List<GameObject>();
        moveTargetPos = new Vector3(0,0,0);
    }
    void Start()
    {
        attackRange = 2;   
        attackDelay = 3;
        ATK = 50;
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void MoveAniPlay()
    {
        animator.SetBool("isWalking",true); 
    }
    protected override void MoveAniStop()
    {
        animator.SetBool("isWalking",false); 
    }
    protected override void Attack(int attackTarget)
    {
        if(timer>attackDelay)
        {
            animator.SetTrigger("isAttacking");
            DamageControl(enemys[attackTarget],attackTarget);
            timer = 0.0f;
        }
    }
}
