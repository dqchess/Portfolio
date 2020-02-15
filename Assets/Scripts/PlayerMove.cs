using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.PlayerLoop;

public abstract class PlayerMove:UnitMove
{
    public Camera followCam;
    private float turnSmoothVelocity;
    private Vector3 lastMovingVelocity;
    private Vector3 movePos;
    private float moveSpeed = 5f;
    private float jumpForce = 15f;
    private float maxMoveSpeed = 10f;
    private float smoothTime = 1f;
    private float turnSmoothTime;
    private float xSpeed;
    private float zSpeed;
    private bool invicibility;

    private void Move()
    {
        transform.Translate(Vector3.forward * (moveSpeed * zSpeed * Time.deltaTime), Space.Self);
        transform.Translate(Vector3.right * (moveSpeed * xSpeed * Time.deltaTime), Space.Self);

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
        xSpeed = Input.GetAxis("Horizontal");
        zSpeed = Input.GetAxis("Vertical");
        movePos += new Vector3(xSpeed, 0 , zSpeed);
        Move();
        if(!Input.GetMouseButton(1))
            Rotate();
        if (Input.GetKey(KeyCode.Space))
            Attack();
    }
    
    protected virtual void Attack() => GameManager.instance.playerPressedATK = true;
}
