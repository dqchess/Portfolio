using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject fireWall;

    private void Awake()
    {
        if (gameObject.name.Contains("left") || gameObject.name.Contains("right"))
        {
            for (int i = -50; i < 50; i++)
            {
                Vector3 fireSummonPos =
                    new Vector3(transform.position.x, transform.position.y, transform.position.z + i);
                Instantiate(fireWall, fireSummonPos, Quaternion.identity);
            }
        }
        if (gameObject.name.Contains("up") || gameObject.name.Contains("down"))
        {
            for (int i = -50; i < 50; i++)
            {
                Vector3 fireSummonPos =
                    new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
                Instantiate(fireWall, fireSummonPos, Quaternion.identity);
            }
        }
    }
    public void DisappearWhenGameOver() => gameObject.SetActive(false);
}
