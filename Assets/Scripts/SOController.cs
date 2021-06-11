using System;
using Assets.Scripts.Settings;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts {
    public class SOController : Singleton<SOController> {
        public MainGameSettingsSO mainGameSettings;
        public ArrowTowerSO arrowTowerSettings;
        public PoisonTowerSO poisonTowerSettings;
        public IceTowerSO iceTowerSettings;
        public FireTowerSO fireTowerSettings;
        public T1_EnemySO enemy1Settings;
        public T2_EnemySO enemy2Settings;
        public T3_EnemySO enemy3Settings;
        public WaveSettingsSO waveSO;

        public TowerData GetTowerDataByType(TowersTypes type) {
            TowerData result = null;
            switch (type) {
                case TowersTypes.fire:
                    result = fireTowerSettings.GetTowerData();
                    break;
                case TowersTypes.ice:
                    result = iceTowerSettings.GetTowerData();
                    break;
                case TowersTypes.poison:
                    result = poisonTowerSettings.GetTowerData();
                    break;
                case TowersTypes.arrows:
                    result = arrowTowerSettings.GetTowerData();
                    break;
                default:
                    Debug.Log("This type is not in towers list: " + type);
                    break;
            }

            if (result == null) Debug.Log("This type is not in towers list: " + type);
            return result;
        }

        public EnemyData GetEnemyDataByType(EnemyTypes type) {
            EnemyData result = null;
            switch (type)
            {
                case EnemyTypes.t1:
                    result = enemy1Settings.GetEnemyData();
                    break;
                case EnemyTypes.t2:
                    result = enemy2Settings.GetEnemyData();
                    break;
                case EnemyTypes.t3:
                    result = enemy3Settings.GetEnemyData();
                    break;
                default:
                    Debug.Log("This type is not in enemies list: " + type);
                    break;
            }

            if (result == null) Debug.Log("This type is not in enemies list: " + type);
            return result;
        }
    }
}