using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterMove : UnitMove
{
    protected override void Update()
    {
        if(IsEnemyNear())
        {
            int randomPick = Random.Range(0,colls.Length);
            if(EnemyIsInAttacRange(enemys[randomPick].transform.position))
            {
                transform.LookAt(enemys[randomPick].transform.position);                
                Attack(enemys[randomPick].gameObject);     
            }     
        }
    }
}
