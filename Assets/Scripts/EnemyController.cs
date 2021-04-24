using System.Collections.Generic;
using Seka;

namespace Assets.Scripts {
    public class EnemyController: Singleton<EnemyController> {
        public List<Enemy> enemiesList = new List<Enemy>();
        

        public void AddEnemy(Enemy enemy) {
            enemiesList.Add(enemy);
            enemy.index = enemiesList.Count;
        }

        public void SpawnEnemies() {

        }
    }
}