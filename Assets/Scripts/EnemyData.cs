using System;

namespace Assets.Scripts {
    public enum EnemyTypes {
        t1,
        t2,
        t3
    }


    [Serializable]
    public class EnemyData {
        public EnemyTypes enemyType;
        public float health;
        public float speed;
        public float damage;

        public int minReward;
        public int maxReward;

        public EnemyData(EnemyTypes _enemyType, float _health, float _speed, float _damage, int _minReward, int _maxReward) {
            enemyType = _enemyType;
            health = _health;
            speed = _speed;
            damage = _damage;
            minReward = _minReward;
            maxReward = _maxReward;
        }
    }
}