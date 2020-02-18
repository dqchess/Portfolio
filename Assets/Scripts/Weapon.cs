using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponDamge;
    private void OnTriggerEnter(Collider other)
    {
        //무기를 휘둘렀을 떄, 몬스터가 맞는다면 데미지를 준다.
        if (!GameManager.instance.playerPressedATK) 
            return;
        
        if (other.gameObject.CompareTag("Monster"))
        {
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
//