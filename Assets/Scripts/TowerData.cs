using System;
using Assets.Scripts.Settings;

namespace Assets.Scripts {
    [Serializable]
    public class TowerData {
        
        public int buildPrice;
        public int range;
        public float shootInterval;
        public float damage;
        public float bulletSpeed;
        public TowersTypes towerType;

        public TowerData(int _buildPrice, int _range, float _shootInterval, float _damage, float _bulletSpeed, TowersTypes type) {
            buildPrice = _buildPrice;
            range = _range;
            shootInterval = _shootInterval;
            damage = _damage;
            bulletSpeed = _bulletSpeed;
            towerType = type;
        }
    }
}