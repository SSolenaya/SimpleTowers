using System.Collections;
using System.Collections.Generic;
using Seka;
using TMPro;
using UnityEngine;

public class UIController : Singleton<UIController> {

    public Transform parentForUI;

    public TMP_Text wavesValueText;
    public TMP_Text healthValueText;
    public TMP_Text coinsValueText;

    void OnEnable() {
        PlayerDataController.Inst.actionCurrentCoins += SetNewCoinsText;
        PlayerDataController.Inst.actionCurrentHealth += SetNewHealthText;
        PlayerDataController.Inst.actionCurrentWaveNum += SetNewWavesText;
    }

    void Start() {
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

    void OnDisable() {
        PlayerDataController.Inst.actionCurrentCoins -= SetNewCoinsText;
    }


}
