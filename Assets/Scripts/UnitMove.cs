using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnitMove : MonoBehaviour
{
    Vector3 moveTargetPos;
    void Start()
    {
        moveTargetPos = transform.position;
    }
    void Update()
    {  
        if(Input.GetMouseButton(0))
            moveTargetPos = GetMovePos();

        CharMove(moveTargetPos);
    }
    Vector3 GetMovePos()
    {
        Vector3 destination = new Vector3(0,0,0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            destination = hit.point;
            Debug.Log("Raycast Hit...!..."+hit.point.ToString());
        }
        return destination;
    }
    void CharMove(Vector3 moveTargetPos)
    {
        transform.position = Vector3.Lerp(transform.position,moveTargetPos, 0.035f);
    }
}
