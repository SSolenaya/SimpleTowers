using System.Collections;
using System.Collections.Generic;
using Seka;
using UnityEditor;
using UnityEngine;
using UnityTemplateProjects;

public class SOController : Singleton<SOController> {

    public MainGameSettingsSO mainGameSettings;
    public TowersSettingsSO towersSettings;
    public EnemiesSettingsSO enemiesSettings;
    public WaveSO waveSO;

    
    public TowerData GetTowerDataByType(TowersTypes type)
    {
        TowerData result = null;
        foreach (var tData in towersSettings.listTowerData)
        {
            if (tData.towerType == type)
            {
                result = tData;
            }
        }
        if (result == null) Debug.Log("This type is not in towers list: " + type.ToString());
        return result;
    }

    public EnemyData GetEnemyDataByType(EnemyTypes type)
    {
        EnemyData result = null;
        foreach (var tData in enemiesSettings.listEnemyData)
        {
            if (tData.enemyType == type)
            {
                result = tData;
            }
        }
        if (result == null) Debug.Log("This type is not in enemies list: " + type.ToString());
        return result;
    }
}
