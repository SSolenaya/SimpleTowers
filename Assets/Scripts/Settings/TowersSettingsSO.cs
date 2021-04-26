using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    [CreateAssetMenu(fileName = "Towers settings config", menuName = "Create towers settings config")]
    public class TowersSettingsSO : ScriptableObject {
        public float bulletSpeed = 20f;
        public List<TowerData> listTowerData;
    }
}