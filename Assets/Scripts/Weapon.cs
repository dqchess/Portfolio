using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponDamge;

    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.playerPressedATK) 
            return;
        
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("칼이 닿았습니다!");
            GameObject attackedEnemy = other.transform.gameObject;
            DamageControl(attackedEnemy);
        }
    }
    private void DamageControl(GameObject target)
    {
        UnitMove damagedTarget = target.GetComponent<UnitMove>();
        damagedTarget.HP -= this.weaponDamge;
        GameManager.instance.playerPressedATK = false;
    }
}
