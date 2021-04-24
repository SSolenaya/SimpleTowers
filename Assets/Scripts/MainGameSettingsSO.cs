using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Main settings config", menuName = "Create main settings config")]
public class MainGameSettingsSO : ScriptableObject {

    public int maxAmountOfWaves = 1;
    public int startAmountOfCoins = 300;
    public int maxAmountOfHealth = 100;



}
