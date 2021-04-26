using UnityEngine;

namespace Assets.Scripts {
    [CreateAssetMenu(fileName = "Main settings config", menuName = "Create main settings config")]
    public class MainGameSettingsSO : ScriptableObject {
        public float saleTowerFactor = 0.5f;
        public int maxAmountOfWaves = 1;
        public int startAmountOfCoins = 300;
        public int maxAmountOfHealth = 100;
    }
}