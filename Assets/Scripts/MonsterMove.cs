using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    Collider[] colls;
    bool isPlayerNear = false;
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(IsPlayerNear())
            Debug.Log("OverlapSphere Working, Detected "+ colls.Length.ToString() +" objects");
    }

    bool IsPlayerNear()
    {
        colls = Physics.OverlapSphere(transform.position,Mathf.Infinity,whatIsPlayer);
        if(colls.Length>=1)
            return true;
        else 
            return false;
    }
}
