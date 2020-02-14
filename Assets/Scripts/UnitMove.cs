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
    protected NavMeshAgent navMeshAgent;
    protected List<GameObject> enemys;
    protected float attackDelay;
    protected float timer;
    public float HP;
    protected float ATK;
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemys = new List<GameObject>();
        moveTargetPos = new Vector3(0,0,0);
        timer = 0.0f;
    }
    protected virtual void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward);
        if(HP<=0)
            gameObject.SetActive(false);    
    }
    protected bool EnemyIsInAttackRange(Vector3 enemyPosition)
    {
        if ((Mathf.Abs(enemyPosition.x - transform.position.x) > attackRange) || (Mathf.Abs(enemyPosition.z - transform.position.z) > attackRange))
            return false;
        else
            return true;
    }
    protected virtual bool IsArrived()
    {
        if ((Mathf.Abs(moveTargetPos.x - transform.position.x) > 1f) || (Mathf.Abs(moveTargetPos.z - transform.position.z) > 1f))
            return false;
        else
            return true;
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    protected abstract void Attack();
    protected abstract void MoveAniPlay();
    protected abstract void MoveAniStop();  
}


//이하 코드들은 자동 전투 구현 시 사용할 코드들임
//===================================================================
//TODO: 적이 근처에 있는지 탐지하는 코드.
//protected bool IsEnemyNear()
//{
//    colls = Physics.OverlapSphere(transform.position, 10f, whatIsEnemy);
//    if (colls.Length >= 1)
//    {
//        for (int i = 0; i < colls.Length; i++)
//        {
//            if (!enemys.Contains(colls[i].gameObject))
//                enemys.Add(colls[i].gameObject);
//        }
//        return true;
//    }
//    else
//        return false;
//}
//
//TODO: 적을 쓰러트렸다면, "근처의 적" 리스트에서 쓰러트린 적을 뺀다.
//void enemyListControl()
//{
//    for (int i = 0; i < enemys.Count; i++)
//    {
//        if (!enemys[i].activeSelf)
//            enemys.RemoveAt(i);
//    }
//}
