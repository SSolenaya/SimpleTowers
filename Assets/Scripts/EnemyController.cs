using System.Collections.Generic;
using Seka;
using UnityEngine;

namespace Assets.Scripts {
    public class EnemyController : Singleton<EnemyController> {
        public List<Enemy> enemiesList = new List<Enemy>();
        public Wave _wave;

        [SerializeField] private Enemy _enemyPrefab;


        public void AddEnemy(Enemy enemy) {
            enemiesList.Add(enemy);
            enemy.index = enemiesList.Count;
        }

        public void CreateNewWave() {
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

       
    }
}