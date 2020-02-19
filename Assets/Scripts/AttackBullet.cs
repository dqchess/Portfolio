using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBullet : MonoBehaviour
{
    private Vector3 velocity;
    private Collider[] enemys;
    private Collider attackTarget;
    private float smoothTime = 1f;
    public LayerMask whatIsMonster;
    private void Start()
    {
        enemys = Physics.OverlapSphere(transform.position, Mathf.Infinity, whatIsMonster);
        attackTarget = FindNearestEnemy();
        velocity = Vector3.zero;
    }
    private void Update()
    {
        transform.position =
            Vector3.SmoothDamp(transform.position, attackTarget.transform.position, ref velocity, smoothTime);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Monster"))
            gameObject.SetActive(false);
    }
}
