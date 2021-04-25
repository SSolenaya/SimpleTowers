using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave settings config", menuName = "Create wave settings config")]
public class WaveSO : ScriptableObject {

    public float duration;
    public float pauseBeforeNextWave;
    public float timeBetweenUnits;

}
