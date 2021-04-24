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

    void Start() {
        SetNewWavesText(0);
        SetNewHealthText(SOController.Inst.mainGameSettings.maxAmountOfHealth);
        SetNewCoinsText(SOController.Inst.mainGameSettings.startAmountOfCoins);
    }

    public void SetNewWavesText(int passedWavesNumber) {
        wavesValueText.text = passedWavesNumber + "/" + SOController.Inst.waveSO.amountOfAllWaves;
    }

    public void SetNewHealthText(int currentHealth) {
        healthValueText.text = currentHealth + "/" + SOController.Inst.mainGameSettings.maxAmountOfHealth;
    }

    public void SetNewCoinsText(int currentCoins) {
        coinsValueText.text = currentCoins.ToString();
    }


}
