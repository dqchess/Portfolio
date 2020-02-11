using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerMove:UnitMove
{
    protected Transform clickPoint;
    protected int attackTarget;
    protected override void Awake()
    {
        base.Awake();
        attackTarget = 0;
        clickPoint.gameObject.SetActive(false);
    }
    protected override void Update()
    {
        Debug.Log(gameObject.name + " has " + enemys.Count +" enemies");

        base.Update();
        if(IsEnemyNear())
        {
            int randomPick = Random.Range(0,enemys.Count);
            if(attackTarget >= enemys.Count)
                attackTarget = 0;
            if(!enemys[attackTarget].activeSelf)
                attackTarget = randomPick;
            if(EnemyIsInAttacRange(enemys[attackTarget].transform.position))
            {
                transform.LookAt(enemys[attackTarget].transform.position); 
                Attack(attackTarget); 
            }      
            moveTargetPos = enemys[attackTarget].transform.position;
        }
        else
        {
          if(Input.GetMouseButton(0))
          {
              moveTargetPos = GetMovePos();
              SetDestPoint();
          }
        }      
        CharMove(moveTargetPos);
    }
    protected Vector3 GetMovePos()
    {
        Vector3 destination = new Vector3(0,0,0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,Mathf.Infinity))       
            destination = hit.point;
    
        transform.LookAt(hit.point);
        return destination;
    }
    protected void CharMove(Vector3 moveTargetPos)
    {  
        if(gameObject.activeSelf)
        {     
            navMeshAgent.SetDestination(moveTargetPos);
            MovingAnimation();
        }
    }
    void SetDestPoint()
    {
        clickPoint.position = new Vector3(moveTargetPos.x, 0.001f, moveTargetPos.z);
        clickPoint.gameObject.SetActive(true);
    }
    protected override bool IsArrived()
    {
        if((Mathf.Abs(moveTargetPos.x - transform.position.x) > 1f)||(Mathf.Abs(moveTargetPos.z - transform.position.z) >1f))
            return false;
        else
        {
            clickPoint.gameObject.SetActive(false);
            return true;
        }
    }
}