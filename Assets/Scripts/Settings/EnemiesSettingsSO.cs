using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    [CreateAssetMenu(fileName = "Enemies settings config", menuName = "Create enemies settings config")]
    public class EnemiesSettingsSO : ScriptableObject {
        public List<EnemyData> listEnemyData;
    }
}