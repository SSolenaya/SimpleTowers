using System.Collections.Generic;
using Seka;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityTemplateProjects;

public class UIController : Singleton<UIController> {
    public Camera mainCamera;
    public CanvasScaler canvasScaler;
    [SerializeField] private BuildingModal _prefabBuildingModalWin; //  prefab of modal window for menu of building towers
    private BuildingModal _buildingModalWin;

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
        wavesValueText.text = passedWavesNumber + "/" + SOController.Inst.waveSO.amountOfAllWaves;
    }

    public void SetNewHealthText(float currentHealth) {
        int hp = Mathf.RoundToInt(currentHealth);
        healthValueText.text = hp + "/" + SOController.Inst.mainGameSettings.maxAmountOfHealth;
    }

    public void SetNewCoinsText(int currentCoins) {
        coinsValueText.text = currentCoins.ToString();
    }

    private void OnDisable() {
        PlayerDataController.Inst.actionCurrentCoins -= SetNewCoinsText;
    }


    public void ShowWindow(List<TowersTypes> towerTypes, Slot slot) { //SALT
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

    public void ShowWindow(Tower tower) { //SALT
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
}