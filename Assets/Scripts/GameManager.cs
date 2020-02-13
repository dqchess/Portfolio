using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
        ExitControl();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);
    }

    void ExitControl()
    {
        if(Input.GetKey(KeyCode.Escape))
            Application.Quit();
        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.F4))
            Application.Quit();
        if(Input.GetKey(KeyCode.RightAlt) && Input.GetKey(KeyCode.F4))
            Application.Quit();
    }
}
