using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterMove : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    protected NavMeshAgent navMeshAgent;
    protected List<Transform> userCharacter;
    protected Animator animator;
    Collider[] colls;
    bool isPlayerNear = false;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        userCharacter = new List<Transform>();
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(IsPlayerNear())
        {
            if(Approached(AttackTargetSelected()))
                Attack();
        }
    }
    Vector3 AttackTargetSelected()
    {
        int randomPick = Random.Range(0,colls.Length);
        Vector3 attackTarget = new Vector3(userCharacter[randomPick].position.x,userCharacter[randomPick].position.y,userCharacter[randomPick].position.z);
        FollowAttackTarget(attackTarget);
        //Debug.Log("Slime: Attack target Selected!..." + userCharacter[randomPick].gameObject.name);
        return attackTarget;
    }
    void FollowAttackTarget(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
        transform.LookAt(target);
        PlayMovingAni();
    }

    bool IsPlayerNear()
    {
        colls = Physics.OverlapSphere(transform.position,10f,whatIsPlayer);
        if(colls.Length>=1)
        {
            for(int i = 0; i<colls.Length; i++)
                userCharacter.Add(colls[i].transform);
            
            return true;
        }
        else 
            return false;
    }
    protected virtual bool Approached(Vector3 destination)
    {
        if((Mathf.Abs(destination.x - transform.position.x) > 3f)||(Mathf.Abs(destination.z - transform.position.z) >3f))
            return false;
        else
            return true;     
    }
    protected abstract void Attack();
    protected abstract void PlayMovingAni();
}
