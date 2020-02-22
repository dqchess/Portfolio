﻿using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class MonsterMove : UnitMove
{
    #region variables
    protected float monsterMoveTimer = 0;
    protected float startMoveTime;
    public UnityEvent playerHit;
    private void OnCollisionEnter(Collision other)
    #endregion

    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHit.Invoke();
        }
    }
    protected override void Update()
    {
        base.Update();
        
        if (this.HP <= Constants.GetNumber.dieHP)
            GameManager.instance.numOfMonster -= 1;
    }

    #region randomly move per monster move timer
    protected void FixedUpdate()
    {
        monsterMoveTimer += Time.deltaTime;
        RandomDestSelect();
    }

    private void RandomDestSelect()
    {
        if (monsterMoveTimer > startMoveTime)
        {
            navMeshAgent.speed = Constants.GetNumber.monsterBaseSpeed + GameManager.instance.stageLevel;
            navMeshAgent.SetDestination(new Vector3(
                Random.Range(Constants.GetNumber.leftLimit, Constants.GetNumber.rightLimit),
                0, 
                Random.Range(Constants.GetNumber.downLimit, Constants.GetNumber.upLimit)));
            monsterMoveTimer = 0f;
        }
    }
    #endregion
}