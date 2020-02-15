using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.PlayerLoop;

public abstract class MonsterMove : UnitMove
{
    public LayerMask whatIsPlayer;
    protected NavMeshAgent navMeshAgent;
    protected float startMoveTime;
    protected Collider[] player;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject.name + " is attacking player!");
            GameObject attackedEnemy = other.transform.gameObject;
            DamageControl(attackedEnemy);
        }
    }
    protected override void Update()
    {
        base.Update();
        
        if (this.HP <= 0)
            GameManager.instance.numOfMonster -= 1;
        
        if (IsPlayerNear())
            Attack();
    }
    protected void FixedUpdate()
    {
        timer++;
        RandomDestSelect();
    }
    protected bool IsPlayerNear()
    {
        player = Physics.OverlapSphere(transform.position, 5f, whatIsPlayer);
        if (player.Length > 0)
            return true;
        return false;
    }

    protected void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void RandomDestSelect()
    {
        if (timer > startMoveTime)
        {
            navMeshAgent.SetDestination(new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)));
            timer = 0f;
        }
    }
}
