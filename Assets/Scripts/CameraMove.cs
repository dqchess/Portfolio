using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Vector3 screenMoveTargetPos;

    void Awake()
    {
        screenMoveTargetPos = transform.position;
    }
    void Update () 
    {
        if(Input.GetMouseButton(0))
            screenMoveTargetPos = GetClickedPos();
        
        transform.position = Vector3.Lerp(transform.position,screenMoveTargetPos, 0.025f);       
    }
    Vector3 GetClickedPos()
    {
        Vector3 clickedPos = new Vector3(Input.mousePosition.x, 10, Input.mousePosition.y);
        Camera.main.ScreenToWorldPoint(clickedPos);
        Debug.Log("move to position : " + clickedPos.ToString());

        return clickedPos;
    }
}
