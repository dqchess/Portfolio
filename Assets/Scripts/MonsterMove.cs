using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterMove : UnitMove
{
    public LayerMask whatIsPlayer;
    protected Collider[] player;
    protected override void Update()
    {
        base.Update();
    }
    protected bool IsPlayerNear()
    {
        player = Physics.OverlapSphere(transform.position, 5f, whatIsPlayer);
        if (player.Length > 0)
            return true;
        else
            return false;
    }
}
