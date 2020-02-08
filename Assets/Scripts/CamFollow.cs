using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float smoothTime;
    public Transform target;
    private Vector3 lastMovingVelocity;
    private Camera camera;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Awake()
    {
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        targetPosition = new Vector3(target.transform.position.x, 10, target.transform.position.z);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position,targetPosition,ref lastMovingVelocity, smoothTime);
        transform.position = smoothPosition;
    }
}
