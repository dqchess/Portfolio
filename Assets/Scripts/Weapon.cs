using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponDamge;

    void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.playerPressedATK)
        {
            if (other.gameObject.tag == "Monster")
            {
                Debug.Log("칼이 닿았습니다!");
                GameObject attackedEnemy = other.transform.gameObject;
                DamageControl(attackedEnemy);
            }
        }
    }
    void DamageControl(GameObject target)
    {
        UnitMove damagedTarget = target.GetComponent<UnitMove>();
        damagedTarget.HP -= this.weaponDamge;
        GameManager.instance.playerPressedATK = false;
    }
}
