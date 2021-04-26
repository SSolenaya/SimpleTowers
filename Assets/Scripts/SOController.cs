using UnityEngine;

namespace Assets.Scripts {
    public class SOController : Singleton<SOController> {
        public MainGameSettingsSO mainGameSettings;
        public TowersSettingsSO towersSettings;
        public EnemiesSettingsSO enemiesSettings;
        public WaveSettingsSO waveSO;


        public TowerData GetTowerDataByType(TowersTypes type) {
            TowerData result = null;
            foreach (TowerData tData in towersSettings.listTowerData) {
                if (tData.towerType == type) {
                    result = tData;
                }
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