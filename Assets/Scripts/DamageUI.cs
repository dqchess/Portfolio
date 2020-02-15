using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    private TextMesh text;

    private void Awake()
    {
        text = GetComponent<TextMesh>();
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.playerGotAttacked)
        {
            ShowDamagedUI();
        }
    }
    private void ShowDamagedUI()
    {
        text.text = "-"+GameManager.instance.howMuchDamageGet.ToString();
        text.color = Color.red;
        GameManager.instance.playerGotAttacked = false;
        Invoke("closeUI",1f);
    }

    private void closeUI()
    {
        text.color = Color.clear;
    }
    
}
