using System;

namespace Assets.Scripts {
    public enum TowersTypes {
        fire,
        ice,
        poison,
        arrows
    }

    [Serializable]
    public class TowerData {
        public TowersTypes towerType;
        public int buildPrice;
        public int range;
        public float shootInterval;
        public float damage;
    }
}