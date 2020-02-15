﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerPressedATK;
    public int numOfMonster;
    private GameObject[] monsters;
    private List<UnitMove> monsterHPContainer;
    private void Update() => DontDestroyOnLoad(gameObject);
    
    private void Awake()
    {
        instance = this;
        playerPressedATK = false;
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        monsterHPContainer = new List<UnitMove>();
    }
    private void Start()
    {
        
        for(int i = 0; i<monsters.Length; i++)
            monsterHPContainer.Add(monsters[i].GetComponent<UnitMove>());
        
        numOfMonster = monsters.Length;
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        ExitControl();
        MonsterNumControl();
    }
    private void ExitControl()
    {
        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKey(KeyCode.F4))
            Application.Quit();
    }
    private void MonsterNumControl()
    {
        if (numOfMonster < 2)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (!monsters[i].activeSelf)
                {
                    monsterHPContainer[i].HP = 100;
                    monsters[i].SetActive(true);
                    numOfMonster++;
                }
            }
        }
    }
}
