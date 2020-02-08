using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnitMove : MonoBehaviour
{
    Vector3 moveTargetPos;
    Vector3 lastMovingVelocity;
    Animator animator;
    public float smoothTime;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        moveTargetPos = new Vector3(0,0,0);
    }
    void Update()
    {  
        if(Input.GetMouseButton(0))
            moveTargetPos = GetMovePos();

        if(Input.GetMouseButton(1))
        {
            Attack();
        }

        CharMove(moveTargetPos);
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
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, moveTargetPos, ref lastMovingVelocity, smoothTime);
        transform.position = smoothPosition;
        MovingAnimation(moveTargetPos);
    }
    void MovingAnimation(Vector3 moveTargetPos)
    {
        animator.SetBool("Moving",true);
        animator.SetFloat("Velocity X", moveTargetPos.x - transform.position.x);
        animator.SetFloat("Velocity Z", moveTargetPos.z - transform.position.z);
    }

    void Attack()
    {
        animator.SetTrigger("AttackTrigger");
        animator.SetBool("Moving",true);
        animator.SetInteger("Weapon",1);
        animator.SetInteger("Action",1);
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
