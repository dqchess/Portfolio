﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwordmanMove : PlayerMove
{
    void Awake()
    {        
        clickPoint = GameObject.FindGameObjectWithTag("clickPoint").transform;
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemys = new List<GameObject>();
        moveTargetPos = new Vector3(0,0,0);
    }
    void Start()
    {
        attackRange = 1;
        attackDelay = 2;
        ATK = 5;
    }
    protected override void Update()
    {
        base.Update();
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
    protected override void Attack(GameObject attackTarget)
    {
        if(timer>attackDelay)
        {
            animator.SetTrigger("AttackTrigger");
            animator.SetBool("Moving",true);
            animator.SetInteger("Weapon",1);
            animator.SetInteger("Action",1);
            timer = 0.0f;
            UnitMove damagedTarget = attackTarget.GetComponent<UnitMove>();
            Debug.Log(gameObject.name + "is now attacking "+damagedTarget.gameObject.name);
        }
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
