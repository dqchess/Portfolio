using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class MonsterMove : UnitMove
{
    protected NavMeshAgent navMeshAgent;
    protected float monsterMoveTimer = 0;
    protected float startMoveTime;
    public UnityEvent playerHit;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHit.Invoke();
        }
    }
    protected override void Update()
    {
        base.Update();
        
        if (this.HP <= 0)
            GameManager.instance.numOfMonster -= 1;
    }
    protected void FixedUpdate()
    {
        monsterMoveTimer += Time.deltaTime;
        RandomDestSelect();
    }

    protected void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void RandomDestSelect()
    {
        if (monsterMoveTimer > startMoveTime)
        {
            navMeshAgent.SetDestination(new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)));
            monsterMoveTimer = 0f;
        }
    }
    
}
