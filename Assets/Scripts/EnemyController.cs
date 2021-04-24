using System.Collections.Generic;
using Seka;
using UnityEngine;

namespace Assets.Scripts {
    public class EnemyController : Singleton<EnemyController> {
        public List<Enemy> enemiesList = new List<Enemy>();
        public Wave _wave;
        private int _waveNum = 0;

        [SerializeField] private Enemy _enemyPrefab;
        

        public void AddEnemy(Enemy enemy) {
            enemiesList.Add(enemy);
            enemy.index = enemiesList.Count;
        }

        public void CreateNewWave() {
            _wave = new Wave();
            _wave.Setup();
            _waveNum += 1;
            PlayerDataController.Inst.currentWaveNumber = _waveNum;
        }

        public void SpawnEnemies() {
            var spawnPoint = PathController.Inst.GetPathPointByIndex(0);
            var enemy = Instantiate(_enemyPrefab);
            enemy.transform.position = spawnPoint.transform.position + Vector3.up*0.1f;
            AddEnemy(enemy);
            enemy.Setup();

        }

        void Update() {
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