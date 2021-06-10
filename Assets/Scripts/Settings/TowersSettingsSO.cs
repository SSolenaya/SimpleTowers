using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public enum TowersTypes
    {
        fire,
        ice,
        poison,
        arrows
    }


    public abstract class TowersSO : ScriptableObject {
        [Range(15, 25)] public float bulletSpeed;
        [Range(100,1000)] public int buildPrice;
        [Range(4, 20)] public int range;
        [Range(0.1f, 1)] public float shootInterval;
        [Range(1, 20)] public float damage;
        public TowersTypes type;

        public TowerData GetTowerData() {
            var resultData = new TowerData(buildPrice, range, shootInterval, damage, bulletSpeed, type);
            return resultData;
        }
    }

    
}