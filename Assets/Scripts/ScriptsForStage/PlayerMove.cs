using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerMove : UnitMove
{
    #region variables
    public GameObject attackBullet;
    public GameObject magicAura;
    public Camera followCam;
    private float turnSmoothVelocity;
    private Vector3 lastMovingVelocity;
    private float turnSmoothTime;
    private Vector3 moveHorizontal;
    private float attackTimer;
    private Vector3 moveVertical;
    private bool invicibility;
    private bool canMove = true;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        invicibility = false;
    }

    private void Start()
    {
        magicAura.SetActive(false);  
        followCam.enabled = true;
        attackTimer = 0f;
    }

    protected override void Update()
    {
        base.Update();
        Move();
        if (!Input.GetMouseButton(1))
            Rotate();
    }

    #region move in boundary
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

    private bool IsInBoundary()
    {
        if ((transform.position.x < Constants.GetNumber.rightLimit)
            && (transform.position.x > Constants.GetNumber.leftLimit)
            && (transform.position.z < Constants.GetNumber.upLimit)
            && (transform.position.z > Constants.GetNumber.downLimit))
            return true;
        return false;
    }
    
    private void Rotate()
    {//회전
        float targetRotation = followCam.transform.eulerAngles.y;
        targetRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity,
            turnSmoothTime);
        transform.eulerAngles = Vector3.up * targetRotation;
    }
    #endregion

    #region attack per frame
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
        if (GameManager.instance.stageLevel <= 5)
        {
            GameManager.instance.playerBulletCount = GameManager.instance.stageLevel;
        }

        for (int i = 0; i < GameManager.instance.playerBulletCount; i++)
        {
            Vector3 bulletSummonPos =
                new Vector3(transform.position.x + i * 3f, transform.position.y + i * 3f, transform.position.z + i * 3f);
            Instantiate(attackBullet, bulletSummonPos, Quaternion.identity);
        }

    }
    #endregion
    public void ActivateAura()
    {
        Constants.GetNumber.invicibilityOffTime += 1.5f;
        magicAura.SetActive(true);
        Invoke("AuraOff", 3f);
    }
    private void AuraOff()
    {
        Constants.GetNumber.invicibilityOffTime = 1.5f;
        magicAura.SetActive(false);
    }

    public void CantMovePlayer() => canMove = false;
    public void CorpseDisappear() => gameObject.SetActive(false);
    public void SummonInCenter() => transform.position = Vector3.zero;
    public abstract void Die();
}
