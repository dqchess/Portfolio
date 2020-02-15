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
        if(deathCounter == life.Length)
            player.gameObject.SetActive(false);
    }
    public void lifeDelete()
    {
        Debug.Log("UI.lifeDelete() function activated...!");
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
