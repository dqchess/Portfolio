﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{

    public GameObject[] monPrefabs;
    private List<GameObject> monsters = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlayerNear())
        {
            Spawn();
        }
    }  
    void Spawn()
    {
        if(monsters.Count<5)
        {
            int selection = Random.Range(0, monPrefabs.Length);
            GameObject selectedPrefab = monPrefabs[selection];
            Vector3 spawnPos = GetRandomPosition();
            GameObject Instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);     
            monsters.Add(Instance);
        }
        else
            return;
    }
    Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = new Vector3(10,10,0);

        float posX = basePosition.x + Random.Range(-size.x/2f, size.x/2f);
        float posY = basePosition.y + Random.Range(-size.y/2f, size.y/2f);
        float posZ = basePosition.z + Random.Range(-size.z/2f, size.z/2f);

        Vector3 spwanPos = new Vector3(posX, posY, posZ);
        return spwanPos;
    }
    bool IsPlayerNear()
    {

        Collider[] colls = Physics.OverlapSphere(transform.position,1f,LayerMask.NameToLayer("player"));
        if(colls.Length>=1)
            return true;
      
        else 
            return false;
    }
}