using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterMove : UnitMove
{
    protected override void Update()
    {
        base.Update();
        if(IsEnemyNear())
        {
            int randomTarget = Random.Range(0,colls.Length);
            if(EnemyIsInAttacRange(enemys[randomTarget].transform.position))
            {
                transform.LookAt(enemys[randomTarget].transform.position);                
                Attack(randomTarget);     
            }     
        }
    }
}
