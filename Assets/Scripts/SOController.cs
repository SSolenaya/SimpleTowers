using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts {
    public class SOController : Singleton<SOController> {
        public MainGameSettingsSO mainGameSettings;
        public ArrowTowerSO arrowTowerSettings;
        public PoisonTowerSO poisonTowerSettings;
        public IceTowerSO iceTowerSettings;
        public FireTowerSO fireTowerSettings;

        public EnemiesSettingsSO enemiesSettings;
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
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            if (result == null) Debug.Log("This type is not in towers list: " + type);
            return result;
        }

        public EnemyData GetEnemyDataByType(EnemyTypes type) {
            EnemyData result = null;
            foreach (EnemyData tData in enemiesSettings.listEnemyData) {
                if (tData.enemyType == type) {
                    result = tData;
                }
            }

            if (result == null) Debug.Log("This type is not in enemies list: " + type);
            return result;
        }
    }
}