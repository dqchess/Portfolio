using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public abstract class UnitMove : MonoBehaviourPunCallbacks
{
    
    #region variables
    protected NavMeshAgent navMeshAgent;
    protected int attackRange;
    protected Animator animator;
    protected float attackDelay;
    protected float timer;
    public float HP;
    protected Vector3 nowPos;
    #endregion
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        nowPos = gameObject.transform.position;
        timer = 0.0f;
        
        
    }
    protected virtual void Update()
    {
        if(HP<=Constants.GetNumber.dieHP)
            gameObject.SetActive(false);
    }
    private void FixedUpdate() => timer += Time.deltaTime;
    protected abstract void MoveAniPlay();
    protected abstract void MoveAniStop();  
}

