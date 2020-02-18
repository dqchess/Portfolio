﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerPressedATK;
    public bool invicibility;
    public int numOfMonster;
    private GameObject[] monsters;
    private List<UnitMove> monsterHPContainer;
    
    private void Awake()
    {
        instance = this;
        playerPressedATK = false;
        invicibility = false;
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        monsterHPContainer = new List<UnitMove>();
    }
    private void Start()
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            monsterHPContainer.Add(monsters[i].GetComponent<UnitMove>());
            monsters[i].transform.position = 
                new Vector3(Random.Range(Constants.GetNumber.leftLimit, Constants.GetNumber.rightLimit),
                0, Random.Range(Constants.GetNumber.downLimit, Constants.GetNumber.upLimit));
        }

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
        //윈도우
        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKey(KeyCode.F4))
            Application.Quit();
        //맥
        if((Input.GetKey(KeyCode.LeftApple) || Input.GetKey(KeyCode.RightApple)) && Input.GetKey(KeyCode.Q))
            Application.Quit();
    }
    private void MonsterNumControl()
    {
        if (numOfMonster < monsters.Length/2)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (!monsters[i].activeSelf)
                {
                    monsterHPContainer[i].HP = Constants.GetNumber.maxHP;
                    monsters[i].SetActive(true);
                    numOfMonster++;
                }
            }
        }
    }
    public void InvicibilityON()
    {
        invicibility = true;
        Invoke("InvicibilityOFF", Constants.GetNumber.invicibilityOffTime);
    }
    private void Update() => DontDestroyOnLoad(gameObject);
    public void InvicibilityOFF() => invicibility = false;

}
