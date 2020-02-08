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

    void FootL()
    {
        //구매한 에셋에 Read-only 타입으로 지정된 애니메이션 이벤트때문에 만든 빈 함수
    }

    void FootR()
    {
        //구매한 에셋에 Read-only 타입으로 지정된 애니메이션 이벤트때문에 만든 빈 함수
    }
}
