using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParadinMove : PlayerMove
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
        attackRange = 2;   
        attackDelay = 3;
        ATK = 10;
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
    protected override void Attack(GameObject attackTarget)
    {
        if(timer>attackDelay)
        {
            animator.SetTrigger("isAttacking");
            timer = 0.0f;
            UnitMove damagedTarget = attackTarget.GetComponent<UnitMove>();
            Debug.Log(gameObject.name + "is now attacking "+damagedTarget.gameObject.name);

        }
    }
}
