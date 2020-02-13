using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerMove:UnitMove
{
    public Camera followCam;
    private float turnSmoothVelocity;
    private Vector3 lastMovingVelocity;
    private Vector3 movePos;
    private float moveSpeed = 5f;
    private float maxMoveSpeed = 10f;
    private float turnSmoothTime;
    private float xSpeed;
    private float zSpeed;
    protected int attackTarget;
    protected override void Awake()
    {
        base.Awake();
        attackTarget = 0;
        moveSpeed = 3f;
        movePos = Vector3.zero;
    }
    protected override void Update()
    {
        base.Update();
        xSpeed = Input.GetAxis("Horizontal");
        zSpeed = Input.GetAxis("Vertical");
        movePos += new Vector3(xSpeed, 0 , zSpeed);
        Move(movePos);
        if(!Input.GetMouseButton(1))
            Rotate();
    }
    void AttackTargetSelect()
    {
        int randomPick = Random.Range(0,enemys.Count);
        if(attackTarget >= enemys.Count)
            attackTarget = 0;
        if(!enemys[attackTarget].activeSelf)
            attackTarget = randomPick;
    }
    
    protected override bool IsArrived()
    {
        if((Mathf.Abs(moveTargetPos.x - transform.position.x) > 1f)||(Mathf.Abs(moveTargetPos.z - transform.position.z) >1f))
            return false;
        else
        {
            return true;
        }
    }
    void Move(Vector3 movePos)
    {
        //transform.position = Vector3.Lerp(transform.position,movePos,moveSpeed);
        //transform.position = Vector3.SmoothDamp(transform.position, movePos, ref lastMovingVelocity, moveSpeed, maxMoveSpeed);
        
        transform.Translate(Vector3.forward * moveSpeed * zSpeed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.right * moveSpeed * xSpeed * Time.deltaTime, Space.Self);
        if((Input.GetAxis("Horizontal")!=0) || Input.GetAxis("Vertical") !=0 )
        {
            MoveAniPlay();
        }
        else
            MoveAniStop();
    }
    void Rotate()
    {
        var targetRotation = followCam.transform.eulerAngles.y;
        targetRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        transform.eulerAngles = Vector3.up * targetRotation;
    }
}



// 자동 진행 기능 구현 할 때 쓸 함수들
//TODO: 네비매쉬를 이용한 자동이동
// protected void CharMove(Vector3 moveTargetPos)
// {  
//     if(gameObject.activeSelf)
//     {     
//         navMeshAgent.SetDestination(moveTargetPos);
//         MovingAnimation();
//     }
// }
//TODO: 근처에 적이 있다면 자동으로 전투.
// if(IsEnemyNear())
// {
//     AttackTargetSelect();
//     if(EnemyIsInAttacRange(enemys[attackTarget].transform.position))
//     {
//         transform.LookAt(enemys[attackTarget].transform.position); 
//         Attack(attackTarget); 
//     }      
//     moveTargetPos = enemys[attackTarget].transform.position;
// }