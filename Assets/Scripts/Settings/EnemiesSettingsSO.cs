using Assets.Editor;
using Assets.Scripts;
using Assets.Scripts.Settings;
using UnityEngine;

public abstract class EnemySO : ScriptableObject
{
    [Range(10, 50)] public float health;
    [Range(0.1f, 0.8f)] public float speed;
    [Range(1, 15)] public float damage;
    [Range(10, 100)] public int minReward;
    [Range(10, 100)] public int maxReward;
    [ShowOnly] public EnemyTypes type;

    #region ScriptableObject

    void OnValidate() {
        if (maxReward <= minReward) maxReward = minReward + 5;
    }

    #endregion

    public EnemyData GetEnemyData()
    {
        var resultData = new EnemyData(type, health, speed, damage, minReward, maxReward);
        return resultData;
    }
}