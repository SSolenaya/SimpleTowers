using Assets.Scripts;
using Seka;
using UnityEngine;

public class Castle : Singleton<Castle> {
    private void OnTriggerEnter(Collider enemyTarget) {
        Enemy enemy = enemyTarget.GetComponent<Enemy>();
        if (enemy != null) {
            PlayerDataController.Inst.DecreaseHealth(enemy.enemyData.damage);
        }
       
    }
}