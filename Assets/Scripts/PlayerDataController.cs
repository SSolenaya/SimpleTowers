using System.Collections;
using System.Collections.Generic;
using Seka;
using UnityEngine;

public class PlayerDataController : Singleton<PlayerDataController> {
    public int currentCoins;
    public float currentHealth;
    public int maxWavesAmount;
    public int currentWaveNumber;

    void OnEnable() {
        currentCoins = SOController.Inst.mainGameSettings.startAmountOfCoins;
        currentHealth = SOController.Inst.mainGameSettings.maxAmountOfHealth;
        maxWavesAmount = SOController.Inst.mainGameSettings.maxAmountOfWaves;
        currentWaveNumber = 0;
    }

    public void AddFinance(int coins) {
        currentCoins += coins;
    }

    public void SubtractFinance(int coins)
    {
        if (coins > currentCoins) {
            Debug.Log("Not enough money");
            return;
        }
        currentCoins -= coins;
    }


}
