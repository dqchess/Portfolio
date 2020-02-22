using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    #region variables
    public GameObject fireWall;
    private List<GameObject> fires;
    private bool wallMoved;
    #endregion

    private void Awake()
    {
        fires = new List<GameObject>();
        FireWallSummon();
        wallMoved = false;
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.stageLevel % 5 == 0)
        {
            if (!wallMoved)
            {
                for (int i = 0; i < fires.Count; i++)
                    Destroy(fires[i]);
                fires.Clear();
                WallMove();
            }
        }
        else
            wallMoved = false;
    }

    private void WallMove()
    {
        #region each wall move by 2.5
        if (gameObject.name.Contains("left"))
        {
            transform.position = new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z);
            Constants.GetNumber.leftLimit += 2.5f;
        }
        if (gameObject.name.Contains("right"))
        {
            transform.position = new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z);
            Constants.GetNumber.rightLimit -= 2.5f;
        }
        if (gameObject.name.Contains("up"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2.5f);
            Constants.GetNumber.upLimit -= 2.5f;
        }
        if (gameObject.name.Contains("down"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2.5f);
            Constants.GetNumber.downLimit += 2.5f;
        }
        #endregion
        FireWallSummon();
        wallMoved = true;
    }

    private void FireWallSummon()
    {
        #region summon 100 fires
        if (gameObject.name.Contains("left") || gameObject.name.Contains("right"))
        {
            for (int i = -50; i < 50; i++)
            {
                Vector3 fireSummonPos =
                    new Vector3(transform.position.x, transform.position.y, transform.position.z + i);
                GameObject fireInstance = Instantiate(fireWall, fireSummonPos, Quaternion.identity);
                fires.Add(fireInstance);
            }
        }
        if (gameObject.name.Contains("up") || gameObject.name.Contains("down"))
        {
            for (int i = -50; i < 50; i++)
            {
                Vector3 fireSummonPos =
                    new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
                GameObject fireInstance = Instantiate(fireWall, fireSummonPos, Quaternion.identity);
                fires.Add(fireInstance);
            }
        }
        #endregion
    }
    public void DisappearWhenGameOver() => gameObject.SetActive(false);
}
