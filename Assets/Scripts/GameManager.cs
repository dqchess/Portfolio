using System;
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
            monsters[i].transform.position = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
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
        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKey(KeyCode.F4))
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
                    monsterHPContainer[i].HP = 100;
                    monsters[i].SetActive(true);
                    numOfMonster++;
                }
            }
        }
    }
    public void InvicibilityON()
    {
        invicibility = true;
        Invoke("InvicibilityOFF",1.5f);
    }
    private void Update() => DontDestroyOnLoad(gameObject);
    public void InvicibilityOFF() => invicibility = false;

}
