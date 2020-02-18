using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerMove:UnitMove
{
    public Camera followCam;
    private float turnSmoothVelocity;
    private Vector3 lastMovingVelocity;
    private float moveSpeed = 5f;
    private float jumpForce = 15f;
    private float maxMoveSpeed = 10f;
    private float smoothTime = 1f;
    private float turnSmoothTime;
    private Vector3 moveHorizontal;
    private Vector3 moveVertical;
    private bool invicibility;

    private void Move()
    {
        transform.Translate(moveHorizontal, Space.Self);
        transform.Translate(moveVertical,Space.Self);     
        if ((Math.Abs(Input.GetAxis("Horizontal")) > 0) || Math.Abs(Input.GetAxis("Vertical")) > 0)
            MoveAniPlay();
        else
            MoveAniStop();
    }

    private void Rotate()
    {
        float targetRotation = followCam.transform.eulerAngles.y;
        targetRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        transform.eulerAngles = Vector3.up * targetRotation;
    }


    protected override void Awake()
    {
        base.Awake();
        moveSpeed = 3f;
        invicibility = false;
    }
    
    protected override void Update()
    {
        base.Update();
        moveHorizontal = Vector3.right * (moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        moveVertical = Vector3.forward * (moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        Move();
        if(!Input.GetMouseButton(1))
            Rotate();
        if (Input.GetKey(KeyCode.Space))
            Attack();
    }

    protected virtual void Attack() => GameManager.instance.playerPressedATK = true;
}
