﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    #region variables
    public float FadeTime = 2f; // Fade효과 재생시간
    Image fadeImg;
    float start;
    float end;
    float time = 0f;
    bool isPlaying = false;
    #endregion

    void Awake()
    {
        fadeImg = GetComponent<Image>();
    }
    public void OutStartFadeAnim()
    {
        if(isPlaying == true) //중복재생방지
        {
            return;
        }
        start = 0f;
        end = 1f;
        StartCoroutine("fadeoutplay");    //코루틴 실행

    }

    IEnumerator fadeoutplay()
    {
        isPlaying = true;
        Color fadecolor = fadeImg.color;
        time = 0f;
        fadecolor.a = Mathf.Lerp(start, end,  time);
        
        while (fadecolor.a < 0.7f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeImg.color = fadecolor;
            yield return null;
        }
    }
}

