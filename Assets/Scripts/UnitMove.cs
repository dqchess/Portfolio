using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    Vector3 moveTargetPos;
    Vector3 lastMovingVelocity;
    Animator animator;
    NavMeshAgent navMeshAgent;
    Transform clickPoint;
    public float smoothTime;

    void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        clickPoint = GameObject.FindGameObjectWithTag("clickPoint").transform;
    }
    void Start()
    {
        moveTargetPos = new Vector3(0,0,0);
    }
    void Update()
    {  
        if(Input.GetMouseButton(0))
        {
            moveTargetPos = GetMovePos();
            SetDestPoint();
        }
        if(Input.GetMouseButton(1))
            Attack();       

        CharMove(moveTargetPos);
    }
    void SetDestPoint()
    {
        clickPoint.position = new Vector3(moveTargetPos.x, 0.001f, moveTargetPos.z);
        clickPoint.gameObject.SetActive(true);
    }
    Vector3 GetMovePos()
    {
        Vector3 destination = new Vector3(0,0,0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,Mathf.Infinity))       
            destination = hit.point;
    
        transform.LookAt(hit.point);
        return destination;
    }
    void CharMove(Vector3 moveTargetPos)
    {
        if(ArrivedAtDestination())
            clickPoint.gameObject.SetActive(false);
        
        navMeshAgent.SetDestination(moveTargetPos);
        MovingAnimation(moveTargetPos);
    }
    void MovingAnimation(Vector3 moveTargetPos)
    {       
        if(IsNotArrived())
            MoveAniPlay();
        else
            MoveAniStop();
    }
    void MoveAniPlay()
    {
        Debug.Log(gameObject.name +" is Moving");
        animator.SetBool("Moving",true);
        animator.SetFloat("Velocity X", moveTargetPos.x - transform.position.x);
        animator.SetFloat("Velocity Z", moveTargetPos.z - transform.position.z);   
    }
    void MoveAniStop()
    {
        Debug.Log(gameObject.name +" is Stopped");
        animator.SetBool("Moving",false);
        animator.SetFloat("Velocity X", 0);
        animator.SetFloat("Velocity Z", 0);   
    }
    bool IsNotArrived()
    {
        if((Mathf.Abs(moveTargetPos.x - transform.position.x) > 1f)||(Mathf.Abs(moveTargetPos.z - transform.position.z) >1f))
            return true;
        else
            return false;
    }
    void Attack()
    {
        animator.SetTrigger("AttackTrigger");
        animator.SetBool("Moving",true);
        animator.SetInteger("Weapon",1);
        animator.SetInteger("Action",1);
    }
    bool ArrivedAtDestination()
    {
        if(navMeshAgent.remainingDistance <=0.3f)
            return true;       
        else
            return false;       
    }
    void FootL()
    {
        //구매한 에셋에 있는 Read-only 애니메이션 이벤트 때문에 만든 빈 함수
    }
    void FootR()
    {
        //구매한 에셋에 있는 Read-only 애니메이션 이벤트 때문에 만든 빈 함수
    }
    void Hit()
    {
        //구매한 에셋에 있는 Read-only 애니메이션 이벤트 때문에 만든 빈 함수
    }
}
