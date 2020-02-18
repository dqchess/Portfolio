using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerMove : UnitMove
{
    public Camera followCam;
    private float turnSmoothVelocity;
    private Vector3 lastMovingVelocity;
    private float turnSmoothTime;
    private Vector3 moveHorizontal;
    private Vector3 moveVertical;
    private bool invicibility;

    private void Move()
    {
        //자유롭게 이동 가능하지만, 범위를 넘어서면 맵 한 가운데로 소환된다.
        if (IsInBoundary())
        {
            transform.Translate(moveHorizontal, Space.Self);
            transform.Translate(moveVertical, Space.Self);
            if ((Math.Abs(Input.GetAxis("Horizontal")) > 0) || Math.Abs(Input.GetAxis("Vertical")) > 0)
                MoveAniPlay();
            else
                MoveAniStop();
        }
        else
        {
            MoveAniStop();
            SummonInCenter();
        }
    }
    private void Rotate()
    {
        float targetRotation = followCam.transform.eulerAngles.y;
        targetRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        transform.eulerAngles = Vector3.up * targetRotation;
    }

    private bool IsInBoundary()
    {
        if ((transform.position.x < Constants.GetNumber.rightLimit)
            && (transform.position.x > Constants.GetNumber.leftLimit)
            && (transform.position.z < Constants.GetNumber.upLimit) && (transform.position.z > Constants.GetNumber.downLimit))
            return true;
        return false;
    }
    protected override void Awake()
    {
        base.Awake();
        invicibility = false;
    }
    
    protected override void Update()
    {
        base.Update();
        moveHorizontal = Vector3.right * (Constants.GetNumber.moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        moveVertical = Vector3.forward * (Constants.GetNumber.moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        Move();
        if(!Input.GetMouseButton(1))
            Rotate();
        if (Input.GetKey(KeyCode.Space))
            Attack();
    }

    public void SummonInCenter()
    {
        transform.position = Vector3.zero;
    }
    protected virtual void Attack() => GameManager.instance.playerPressedATK = true;
}
