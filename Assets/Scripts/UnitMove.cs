using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitMove : MonoBehaviour
{
    protected Vector3 moveTargetPos;
    protected Vector3 lastMovingVelocity;
    protected Animator animator;
    protected NavMeshAgent navMeshAgent;
    protected Transform clickPoint;
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
    protected virtual bool IsNotArrived()
    {
        if((Mathf.Abs(moveTargetPos.x - transform.position.x) > 1f)||(Mathf.Abs(moveTargetPos.z - transform.position.z) >1f))
            return true;
        else
        {
            clickPoint.gameObject.SetActive(false);
            return false;
        }
    }
    protected abstract void CharMove(Vector3 moveTargetPos);
    protected abstract void MovingAnimation();
    protected abstract void MoveAniPlay();
    protected abstract void MoveAniStop();  
    protected abstract void Attack();

}
