using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public void DisappearWhenGameOver() => gameObject.SetActive(false);
}
