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
            text.text = "Got HIT!";
            text.color = Color.red;
        }
    }
}
