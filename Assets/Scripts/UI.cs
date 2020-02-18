using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image[] life;
    private GameObject player;
    private int lifeIndex;
    private int deathCounter;
    private void Awake()
    {
        lifeIndex = 0;
        deathCounter = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        //모든 라이프를 잃으면 게임 오버.
        if(deathCounter == life.Length)
            player.gameObject.SetActive(false);
    }
    public void lifeDelete()
    {
        //플레이어가 피격 당하면 하트를 하나 줄인다.
        if (GameManager.instance.invicibility)
            return;
        if (lifeIndex < life.Length)
        {
            life[lifeIndex].gameObject.SetActive(false);
            lifeIndex++;
            deathCounter++;
        }
    }
}
