using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitMove : MonoBehaviour
{
    public LayerMask whatIsEnemy;
    protected Vector3 moveTargetPos;
    protected int attackRange;
    protected Animator animator;
    protected NavMeshAgent navMeshAgent;
    protected Collider[] colls;
    protected List<GameObject> enemys;
    protected int attackDelay;
    protected float timer;
    public float HP;
    protected float ATK;
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemys = new List<GameObject>();
        moveTargetPos = new Vector3(0,0,0);
    }
    void Start()
    {
        timer = 0.0f;
    }
    protected virtual void Update()
    {
        if(HP<=0)
        {
            gameObject.SetActive(false);
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        enemyListControl();   
    }
    void enemyListControl()
    {
        for(int i = 0; i<enemys.Count; i++)
        {
            if(!enemys[i].activeSelf)
                enemys.RemoveAt(i);
        }
    }
    protected bool EnemyIsInAttacRange(Vector3 enemyPosition)
    {
        if((Mathf.Abs(enemyPosition.x - transform.position.x) > attackRange)||(Mathf.Abs(enemyPosition.z - transform.position.z) >attackRange))
            return false;
        else
            return true;
    }   
    protected virtual bool IsArrived()
    {
        if((Mathf.Abs(moveTargetPos.x - transform.position.x) > 1f)||(Mathf.Abs(moveTargetPos.z - transform.position.z) >1f))
            return false;
        else
        {
            return true;
        }
    }
    protected virtual void DamageControl(GameObject target, int targetIndex)
    {
        UnitMove damagedTarget = target.GetComponent<UnitMove>();
        damagedTarget.HP -= this.ATK;
    }
    protected bool IsEnemyNear()
    {
        colls = Physics.OverlapSphere(transform.position,10f,whatIsEnemy);
        if(colls.Length>=1)
        {
            for(int i = 0; i<colls.Length; i++)
            {
                if(!enemys.Contains(colls[i].gameObject))
                    enemys.Add(colls[i].gameObject);
            }
            return true;
        }
        else 
            return false;
    }
    protected void MovingAnimation()
    {       
        if(IsArrived())
            MoveAniStop();
        else
            MoveAniPlay();
    }

    protected abstract void Attack(int attackTarget);
    protected abstract void MoveAniPlay();
    protected abstract void MoveAniStop();  

}
