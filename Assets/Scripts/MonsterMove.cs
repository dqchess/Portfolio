using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class MonsterMove : UnitMove
{
    protected float monsterMoveTimer = 0;
    protected float startMoveTime;
    public UnityEvent playerHit;
    private void OnCollisionEnter(Collision other)
    {
        //플레이어와 몬스터가 충돌했는지 체크
        if (other.gameObject.CompareTag("Player"))
        {
            playerHit.Invoke();
        }
    }
    protected override void Update()
    {
        //몬스터의 체력이 0 이하로 떨어진다면, 전체 몬스터 수를 하나 줄인다.
        base.Update();
        
        if (this.HP <= Constants.GetNumber.dieHP)
            GameManager.instance.numOfMonster -= 1;
    }
    protected void FixedUpdate()
    {
        monsterMoveTimer += Time.deltaTime;
        RandomDestSelect();
    }

    private void RandomDestSelect()
    {
        //몬스터들이 범위 안에서 무작위한 방향으로 이동한다.
        if (monsterMoveTimer > startMoveTime)
        {
            navMeshAgent.SetDestination(new Vector3(
                Random.Range(Constants.GetNumber.leftLimit, Constants.GetNumber.rightLimit),
                0, 
                Random.Range(Constants.GetNumber.downLimit, Constants.GetNumber.upLimit)));
            monsterMoveTimer = 0f;
        }
    }

}
