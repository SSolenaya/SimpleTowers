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
    }
}