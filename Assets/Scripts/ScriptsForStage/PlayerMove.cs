using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerMove : UnitMove
{
    public GameObject attackBullet;
    public Camera followCam;
    private float turnSmoothVelocity;
    private Vector3 lastMovingVelocity;
    private float turnSmoothTime;
    private Vector3 moveHorizontal;
    private float attackTimer;
    private Vector3 moveVertical;
    private bool invicibility;
    private bool canMove = true;

    private void Start()
    {
        followCam.enabled = true;
        attackTimer = 0f;
    }
    private void Move()
    {
        if (IsInBoundary() && canMove)
        {
            transform.Translate(Vector3.forward * Constants.GetNumber.moveSpeed * Time.deltaTime,Space.Self);
            MoveAniPlay();
        }
        else if(!IsInBoundary())
        {
            MoveAniStop();
            SummonInCenter();
        }
    }
    private void Rotate()
    {
        float targetRotation = followCam.transform.eulerAngles.y;
        targetRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity,
            turnSmoothTime);
        transform.eulerAngles = Vector3.up * targetRotation;
    }
    private bool IsInBoundary()
    {
        if ((transform.position.x < Constants.GetNumber.rightLimit)
            && (transform.position.x > Constants.GetNumber.leftLimit)
            && (transform.position.z < Constants.GetNumber.upLimit) 
            && (transform.position.z > Constants.GetNumber.downLimit))
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
        Move();
        if(!Input.GetMouseButton(1))
            Rotate();
    }
    protected virtual void FixedUpdate()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > Constants.GetNumber.attackDelay)
        {
            Attack();
            attackTimer = 0f;
        }
    }
    protected virtual void Attack()
    {
        for (int i = 0; i < GameManager.instance.stageLevel; i++)
        {
            Vector3 bulletSummonPos =
                new Vector3(transform.position.x + i, transform.position.y + 2f, transform.position.z);
            Instantiate(attackBullet, bulletSummonPos, Quaternion.identity);
        }
    }
    public void CantMovePlayer() => canMove = false;
    public void CorpseDisappear() => gameObject.SetActive(false);
    public void SummonInCenter() => transform.position = Vector3.zero;
    public abstract void Die();
}
