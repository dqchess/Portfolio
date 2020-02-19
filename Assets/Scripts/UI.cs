﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image[] life;
    public TextMeshProUGUI gameOverText;
    private GameObject player;
    private int lifeIndex;
    private int deathCounter;
    private float time;
    private bool gameOverTextShowNowPlaying;
    public float FadeTime = 4f;
    public UnityEvent playerDie; 
    private void Awake()
    {
        lifeIndex = 0;
        deathCounter = 0;
        gameOverTextShowNowPlaying = false;
    }

    private void Start()
    {
        gameOverText.alpha = 0.0f;
    }

    private void FixedUpdate()
    {
        if(deathCounter == life.Length)
            playerDie.Invoke();
    }
    public void lifeDelete()
    {
        if (GameManager.instance.invicibility)
            return;
        if (lifeIndex < life.Length)
        {
            life[lifeIndex].gameObject.SetActive(false);
            lifeIndex++;
            deathCounter++;
        }
    }

    public void GameOverTextShow()
    {
        if (!gameOverTextShowNowPlaying)
            StartCoroutine("GameOverTextFadeIn");
    }

    IEnumerator GameOverTextFadeIn()
    {
        gameOverTextShowNowPlaying = true;
        Color gameOverTextColor = gameOverText.color;
        time = 0f;

        while (gameOverTextColor.a < 1f)
        {
            time += Time.deltaTime / FadeTime;
            gameOverTextColor.a = Mathf.Lerp(0f, 1f, time);
            gameOverText.color = gameOverTextColor;
            yield return null;
        }
    }
}
