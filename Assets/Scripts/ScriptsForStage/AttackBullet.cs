using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBullet : MonoBehaviour
{
    private Vector3 velocity;
    private Collider[] enemys;
    private Collider attackTarget;
    private float destoryTimer;
    private float smoothTime;
    public LayerMask whatIsMonster;
    private void Start()
    {
        enemys = Physics.OverlapSphere(transform.position, Mathf.Infinity, whatIsMonster);
        attackTarget = FindNearestEnemy();
        velocity = Vector3.zero;
    }
    private void Update()
    {
        smoothTime = SpeedControl();
        transform.position =
            Vector3.SmoothDamp(transform.position, attackTarget.transform.position, ref velocity, smoothTime);
    }

    private void FixedUpdate()
    {
        CantFindEnemyThenDestroy();
    }

    private Collider FindNearestEnemy()
    {
        float nearestDistance = Vector3.Distance(transform.position, enemys[0].transform.position);
        Collider nearestEnemy = new Collider();
        foreach (Collider enemy in enemys)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= nearestDistance)
            {
                nearestDistance = Vector3.Distance(transform.position, enemy.transform.position);
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
    private float SpeedControl()
    {
        float timeForSmoothDamp = Constants.GetNumber.baseBulletSpeed - (GameManager.instance.stageLevel * 0.0005f);
        return timeForSmoothDamp;
    }
    private void CantFindEnemyThenDestroy()
    {
        destoryTimer += Time.deltaTime;
        if (destoryTimer > 1f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("Bullet speed is " + SpeedControl().ToString());
            UnitMove attackedTarget = other.GetComponent<UnitMove>();
            attackedTarget.HP -= Constants.GetNumber.baseATK;
            Destroy(gameObject);
        }
    }
}
