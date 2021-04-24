using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class Castle : MonoBehaviour
{
    void OnTriggerEnter(Collider enemyTarget)
    {
        
        var enemy = enemyTarget.GetComponent<Enemy>();
        if (enemy == null) return;
        PlayerDataController.Inst.DecreaseHealth(enemy.enemyData.damage);
    }

}
