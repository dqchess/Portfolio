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
        enemys = new List<GameObject>();
    }
    void Start()
    {
        attackRange = 2;
        attackDelay = 3;
        ATK = 5;
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void Attack()
    {
        // if(timer>attackDelay)
        // {
        //     animator.SetTrigger("AttackTrigger");
        //     timer = 0.0f;
        //     UnitMove damagedTarget = attackTarget.GetComponent<UnitMove>();
        //     damagedTarget.HP -= this.ATK;
        //     Debug.Log(gameObject.name + "is now attacking "+damagedTarget.name);
        // }
    }
    protected override void MoveAniPlay()
    {
        // animator.SetFloat("MoveSpeed",1);
    }
    protected override void MoveAniStop()
    {
        // animator.SetFloat("MoveSpeed",0);
    }
}
