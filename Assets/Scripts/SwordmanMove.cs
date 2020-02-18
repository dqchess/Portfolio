using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SwordmanMove : PlayerMove
{
    private static readonly int attackAniID = Animator.StringToHash("isAttacking");
    private static readonly int moveAniID = Animator.StringToHash("isMoving");
    private static readonly int dieAniID = Animator.StringToHash("dieAniTrigger");
    private void Start()
    {
        attackRange = 2;
        attackDelay = 0.25f;
        ATK = 45;
    }
    protected override void Awake()
    {        
        animator = GetComponent<Animator>();
    }
    protected override void Attack()
    {
        if (!(timer > attackDelay)) 
            return;
        base.Attack();
        animator.SetTrigger(attackAniID);
        timer = 0.0f;
    }

    public override void Die()
    {
        animator.SetTrigger(dieAniID);
    }
    protected override void MoveAniPlay() => animator.SetBool(moveAniID, true);
    protected override void MoveAniStop() => animator.SetBool(moveAniID,false);
}
