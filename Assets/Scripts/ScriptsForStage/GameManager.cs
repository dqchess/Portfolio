using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using Cursor = UnityEngine.Cursor;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region variables
    public static GameManager instance;
    public float playTime;
    public float stageTimer;
    public float stageLevel;
    public DirectionalLight light;
    public bool invicibility;
    public bool bossMonsterCreated;
    public int numOfMonster;
    private GameObject[] monsters;
    private GameObject deadCanvas;
    private List<UnitMove> monsterHPContainer;
    #endregion

    #region when stage loaded, Initialize and activate monsters
    private void Awake()
    {
        stageLevel = 0;
        if (instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);
        
        invicibility = false;
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        deadCanvas = GameObject.FindGameObjectWithTag("deadCanvas");
        monsterHPContainer = new List<UnitMove>();
        InitializeGame();
        Cursor.visible = false;
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
    }

    private void InitializeGame()
    {
        playTime = 0f;
        stageLevel = 1;
        bossMonsterCreated = false;
        Constants.GetNumber.leftLimit = -25f;
        Constants.GetNumber.rightLimit = 25f;
        Constants.GetNumber.upLimit = 25f;
        Constants.GetNumber.downLimit = -25f;
    }
    #endregion

    #region in stage, control monsters and stage level
    private void MonsterNumControl()
    {//몬스터의 수가 절반 이하로 떨어지면 원래 수가 되도록 부활시킨다.
        if (numOfMonster < monsters.Length / 2)
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

    private void EvoToBossMonster()
    {//필드의 몬스터 중 한마리를 보스 몬스터로 만든다.
        GameObject EvoMonster = monsters[Random.Range(0, monsters.Length)];
        if (EvoMonster.activeSelf)
        {
            EvoMonster.transform.localScale *= 3;
            UnitMove statusOfBossMonster = EvoMonster.GetComponent<UnitMove>();
            statusOfBossMonster.HP = 100000;
            bossMonsterCreated = true;
        }
    }
    private void StageControl()
    {
        stageTimer += Time.deltaTime;
        if (stageTimer > 10f)
        {
            stageLevel++;
            stageTimer = 0f;
        }
    }
    #endregion

    #region when player hit, activate invicibility
    public void InvicibilityON()
    {
        invicibility = true;
        Invoke("InvicibilityOff", Constants.GetNumber.invicibilityOffTime);
    }

    public void InvicibilityOff() => invicibility = false;
    #endregion

    private void FixedUpdate()
    {
        ExitControl();
        MonsterNumControl();
        StageControl();
        playTime += Time.deltaTime;

        if ((stageLevel % 5 == 0) && !bossMonsterCreated)
            EvoToBossMonster();

        else if(stageLevel % 5 != 0)
            bossMonsterCreated = false;
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

    public void LoadStageScene()
    {
        SceneManager.LoadScene("Stage");
    }
}
