using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerMove:UnitMove
{
    protected Transform clickPoint;

    protected override void Update()
    {
        base.Update();
        if(IsEnemyNear())
        {
            int randomTarget = Random.Range(0,colls.Length);
            moveTargetPos = enemys[randomTarget].transform.position;
            if(EnemyIsInAttacRange(enemys[randomTarget].transform.position))
            {
                transform.LookAt(enemys[randomTarget].transform.position); 
                Attack(randomTarget); 
            }         
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