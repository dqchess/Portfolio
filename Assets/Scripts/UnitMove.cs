using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitMove : MonoBehaviour
{
    public float atkRange;
    public LayerMask whatIsEnemy;
    protected Vector3 moveTargetPos;
    protected int attackRange;
    protected Animator animator;
    protected float attackDelay;
    protected float timer;
    public float HP;
    protected float ATK;
    
    protected void DamageControl(GameObject target)
    {
        UnitMove damagedTarget = target.GetComponent<UnitMove>();
        damagedTarget.HP -= this.ATK;
        GameManager.instance.playerPressedATK = false;
    }
    
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        timer = 0.0f;
    }
    protected virtual void Update()
    {
        if(HP<=0)
            gameObject.SetActive(false);    
    }
    
    protected virtual void Attack() => GameManager.instance.playerPressedATK = true;
    private void FixedUpdate() => timer += Time.deltaTime;
    protected abstract void MoveAniPlay();
    protected abstract void MoveAniStop();  
}

