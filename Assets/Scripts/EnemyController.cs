using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class EnemyController : Singleton<EnemyController> {
        public List<Enemy> enemiesList = new List<Enemy>();
        public Wave _wave;
        public int indexEnemy;
        [SerializeField] private Enemy _enemyPrefab;

        private void Start() {
            indexEnemy = 0;
            CreateNewWave();
        }

        public void AddEnemy(Enemy enemy) {
            enemiesList.Add(enemy);
            indexEnemy++;
            enemy.index = indexEnemy;
        }

        public void RemoveEnemy(Enemy enemy) {
            for (int i = 0; i < enemiesList.Count; i++) {
                if (enemiesList[i].index == enemy.index) {
                    enemiesList.RemoveAt(i);
                }
            }

            if (enemiesList.Count == 0) {
                PlayerDataController.Inst.CheckForVictory();
            }
        }

        public void CreateNewWave() {
            if (PlayerDataController.Inst.GetCurrentWavesAmount() == SOController.Inst.mainGameSettings.maxAmountOfWaves) return;
            _wave = new Wave();
            _wave.Setup();
            PlayerDataController.Inst.CountWaves();
        }

        public void SpawnEnemies() {
            PathPoint spawnPoint = PathController.Inst.GetPathPointByIndex(0);
            Enemy enemy = PoolManager.GetEnemyFromPull(_enemyPrefab);
            enemy.transform.position = spawnPoint.transform.position + Vector3.up * Random.Range(0.00f, 0.02f);
            AddEnemy(enemy);
            enemy.Setup();
        }

        private void Update() {
            if (_wave == null) {
                CreateNewWave();
            }

            _wave.Update();
            if (_wave.CanSpawn()) {
                SpawnEnemies();
                //Debug.Log("SPAWN");
            }

            if (_wave.IsEnd()) {
                CreateNewWave();
            }
        }

        public void Restart() {
            _wave = null;
            enemiesList.Clear();
        }
    }
}