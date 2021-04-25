﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Seka;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataController : Singleton<PlayerDataController> {
    private int _currentCoins;
    public int currentCoins {
        get { return _currentCoins;}
        set {
            _currentCoins = value;
            actionCurrentCoins?.Invoke(_currentCoins);
        }
    }
    public Action<int> actionCurrentCoins;


    private float _currentHealth;
    public float currentHealth
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            actionCurrentHealth?.Invoke(_currentHealth);
        }
    }
    public Action<float> actionCurrentHealth;

    private int _currentWaveNumber;
    public int currentWaveNumber
    {
        get { return _currentWaveNumber; }
        set
        {
            _currentWaveNumber = value;
            actionCurrentWaveNum?.Invoke(_currentWaveNumber);
        }
    }
    public Action<int> actionCurrentWaveNum;


    public int maxWavesAmount;
    

    void Start() {
        
        currentCoins = SOController.Inst.mainGameSettings.startAmountOfCoins;
        currentHealth = SOController.Inst.mainGameSettings.maxAmountOfHealth;
        maxWavesAmount = SOController.Inst.mainGameSettings.maxAmountOfWaves;
        currentWaveNumber = 0;
    }

    public void DecreaseHealth(float delta) {
        currentHealth -= delta;
        if (currentHealth <= 0) {
            UIController.Inst.ShowStatusWindow("Game over");
            Time.timeScale = 0;
        }
    }

    public void CountWaves() {
        currentWaveNumber++;
    }

    public void CheckForVictory()  {     //  check if all waves are over and no enemies on field
        if (currentWaveNumber == SOController.Inst.mainGameSettings.maxAmountOfWaves && EnemyController.Inst.enemiesList.Count == 0) {
            UIController.Inst.ShowStatusWindow("Victory!!");
            Time.timeScale = 0;
        }
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

    public void RewardForEnemy(int reward) {
        currentCoins += reward;
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
        EnemyController.Inst.Restart();
        Time.timeScale = 1;
    }


}
