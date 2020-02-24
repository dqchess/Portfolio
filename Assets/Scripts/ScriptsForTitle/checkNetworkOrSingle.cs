using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkNetworkOrSingle : MonoBehaviour
{
    public bool isNetworkplay;
    private static checkNetworkOrSingle check;
    public static checkNetworkOrSingle _check
    {
        get
        {
            if(check == null)
            {
                check = new checkNetworkOrSingle();
            }
            return check;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);   
    }

    public void NetworkPlayClicked()=> isNetworkplay = true;
    public void SinglePlayClicked()=> isNetworkplay = false;
}
