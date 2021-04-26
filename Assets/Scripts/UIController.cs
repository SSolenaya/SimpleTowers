using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class UIController : Singleton<UIController> {
        public Camera mainCamera;
        public CanvasScaler canvasScaler;
        [SerializeField] private BuildingModal _prefabBuildingModalWin; //  prefab of modal window for menu of building towers
        [SerializeField] private GameStatusModal _prefabGameStatusModalWin; //  prefab of modal window for game status
        private BuildingModal _buildingModalWin;
        private GameStatusModal _gameStatusModalWin;

        public Transform parentForUI;

        public TMP_Text wavesValueText;
        public TMP_Text healthValueText;
        public TMP_Text coinsValueText;


        private void OnEnable() {
            PlayerDataController.Inst.actionCurrentCoins += SetNewCoinsText;
            PlayerDataController.Inst.actionCurrentHealth += SetNewHealthText;
            PlayerDataController.Inst.actionCurrentWaveNum += SetNewWavesText;
        }

        private void Start() {
            SetNewWavesText(0);
            SetNewHealthText(SOController.Inst.mainGameSettings.maxAmountOfHealth);
            SetNewCoinsText(SOController.Inst.mainGameSettings.startAmountOfCoins);
        }

        public void SetNewWavesText(int passedWavesNumber) {
            wavesValueText.text = passedWavesNumber + "/" + SOController.Inst.mainGameSettings.maxAmountOfWaves;
        }

        public void SetNewHealthText(float currentHealth) {
            int hp = Mathf.RoundToInt(currentHealth);
            healthValueText.text = hp + "/" + SOController.Inst.mainGameSettings.maxAmountOfHealth;
        }

        public void SetNewCoinsText(int currentCoins) {
            coinsValueText.text = currentCoins.ToString();
        }

        private void OnDisable() {
            if (PlayerDataController.Inst != null) {
                PlayerDataController.Inst.actionCurrentCoins -= SetNewCoinsText;
            }
        }


        public void ShowWindow(List<TowersTypes> towerTypes, Slot slot) { // show modal win for building tower over slot
            if (_buildingModalWin != null) {
                return;
            }

            _buildingModalWin = Instantiate(_prefabBuildingModalWin, parentForUI);
            Vector3 viewPos = Camera.main.WorldToViewportPoint(slot.transform.position);
            viewPos.x = Mathf.Clamp(viewPos.x, 0.27f, 0.7f);
            viewPos.y = Mathf.Clamp(viewPos.y, 0.27f, 1f);
            _buildingModalWin.buttonsPanelRT.anchorMin = new Vector2(viewPos.x, viewPos.y);
            _buildingModalWin.buttonsPanelRT.anchorMax = new Vector2(viewPos.x, viewPos.y);

            _buildingModalWin.Setup(towerTypes, slot);
        }

        public void ShowWindow(Tower tower) { // show modal win for selling current tower
            if (_buildingModalWin != null) {
                return;
            }

            _buildingModalWin = Instantiate(_prefabBuildingModalWin, parentForUI);
            Vector3 viewPos = Camera.main.WorldToViewportPoint(tower.transform.position);
            viewPos.x = Mathf.Clamp(viewPos.x, 0.27f, 0.7f);
            viewPos.y = Mathf.Clamp(viewPos.y, 0.27f, 0.7f);
            _buildingModalWin.buttonsPanelRT.anchorMin = new Vector2(viewPos.x, viewPos.y);
            _buildingModalWin.buttonsPanelRT.anchorMax = new Vector2(viewPos.x, viewPos.y);
            _buildingModalWin.Setup(tower);
        }

        public void ShowStatusWindow(string status) {
            if (_gameStatusModalWin != null) {
                return;
            }

            _gameStatusModalWin = Instantiate(_prefabGameStatusModalWin, parentForUI);
            _gameStatusModalWin.SetText(status);
        }
    }
}