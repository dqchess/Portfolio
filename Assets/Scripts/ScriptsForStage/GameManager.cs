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
    public static GameManager instance;
    public float playTime;
    public float stageTimer;
    public float stageLevel;
    public DirectionalLight light;
    public bool invicibility;
    public int numOfMonster;
    private GameObject[] monsters;
    private GameObject deadCanvas;
    private List<UnitMove> monsterHPContainer;

    private void Awake()
    {
        stageLevel = 0;
        if (instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);
        
        invicibility = false;
        playTime = 0f;
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        deadCanvas = GameObject.FindGameObjectWithTag("deadCanvas");
        monsterHPContainer = new List<UnitMove>();
        stageLevel = 1;
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
    private void FixedUpdate()
    {
        ExitControl();
        MonsterNumControl();
        StageControl();
        playTime += Time.deltaTime;
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
    private void StageControl()
    {
        stageTimer += Time.deltaTime;
        if (stageTimer > 25f)
        {
            stageLevel++;
            stageTimer = 0f;
        }
    }
    public void InvicibilityON()
    {
        invicibility = true;
        Invoke("InvicibilityOff", Constants.GetNumber.invicibilityOffTime);
    }
    public void LoadStageScene()
    {
        SceneManager.LoadScene("Stage");
    }
    public void InvicibilityOff() => invicibility = false;
}
