using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterMove : UnitMove
{
    public LayerMask whatIsPlayer;
    protected NavMeshAgent navMeshAgent;
    protected Collider[] player;

    protected override void Update()
    {
        base.Update();
        
        if (this.HP <= 0)
            GameManager.instance.numOfMonster -= 1;
        
        if (IsPlayerNear())
            Attack();
    }
    protected bool IsPlayerNear()
    {
        player = Physics.OverlapSphere(transform.position, 5f, whatIsPlayer);
        if (player.Length > 0)
            return true;
        return false;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject.name + " is attacking player!");
            GameObject attackedEnemy = other.transform.gameObject;
            DamageControl(attackedEnemy);
        }
    }
    private void DamageControl(GameObject target)
    {
        UnitMove damagedTarget = target.GetComponent<UnitMove>();
        damagedTarget.HP -= this.ATK;
        GameManager.instance.playerPressedATK = false;
    }
    protected void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
}
