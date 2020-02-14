using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);
    }
    private void ExitControl()
    {
        if(Input.GetKey(KeyCode.Escape))
            Application.Quit();
        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.F4))
            Application.Quit();
        if(Input.GetKey(KeyCode.RightAlt) && Input.GetKey(KeyCode.F4))
            Application.Quit();
    }
}
