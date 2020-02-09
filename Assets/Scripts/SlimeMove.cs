using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonsterMove
{
    protected override void Attack()
    {
        Debug.Log("Slime is Attacking");
        animator.SetTrigger("AttackTrigger");
    }
    protected override void PlayMovingAni()
    {
        Debug.Log("Slime is Moving");
        animator.SetFloat("MoveSpeed",1);
    }
}
