using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image[] life;
    private GameObject player;
    private int lifeIndex;
    private int deathCounter;
    public UnityEvent playerDie; 
    private void Awake()
    {
        lifeIndex = 0;
        deathCounter = 0;
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
}
