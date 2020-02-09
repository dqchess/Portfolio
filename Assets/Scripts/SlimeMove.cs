using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonsterMove
{
    protected override void Attack()
    {
        animator.SetTrigger("AttackTrigger");
    }
    protected override void PlayMovingAni()
    {
        animator.SetFloat("MoveSpeed",1);
    }
}
