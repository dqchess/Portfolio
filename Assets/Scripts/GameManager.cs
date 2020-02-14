using System;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerPressedATK;
    private void Start() => Cursor.visible = false;
    private void Update() => DontDestroyOnLoad(gameObject);
    
    private void Awake()
    {
        instance = this;
        playerPressedATK = false;
    }
    private void FixedUpdate()
    {
        ExitControl();
    }
    private static void ExitControl()
    {
        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKey(KeyCode.F4))
            Application.Quit();
    }
}
