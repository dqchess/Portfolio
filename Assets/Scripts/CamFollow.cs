using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float smoothTime;
    public GameObject[] targets;
    private Vector3 lastMovingVelocity;
    private Camera camera;
    private Vector3 targetPosition;
    int who;
    // Start is called before the first frame update
    void Awake()
    {
        who = 0;
        camera = GetComponentInChildren<Camera>();
        targets = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(targets[who].activeSelf)
            TakeShot(targets[who]);
        else if(!targets[who].activeSelf && who<targets.Length-1)
            who++;
    }

    void TakeShot(GameObject focus)
    {
        targetPosition = new Vector3(focus.transform.position.x, 10,focus.transform.position.z);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position,targetPosition,ref lastMovingVelocity, smoothTime);
        transform.position = smoothPosition;
    }
}
