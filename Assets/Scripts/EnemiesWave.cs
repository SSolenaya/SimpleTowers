using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    private float _timeWave;        //  full wave time
    private float _timeWait;        //  time between waves
    private float _timeInterval;    //  time between units in one wave

    public float _currentTime;     //  current wave time
    public float _currentTimeInterval; //  current unit time

    private bool _isSpawnTime;  //  flag for ability to spawn
    private bool _isEnd;        //  flag for wave end



    public void Setup()
    {
        _timeWave = SOController.Inst.waveSO.duration;
        _timeWait = SOController.Inst.waveSO.pauseBeforeNextWave;
        _timeInterval = SOController.Inst.waveSO.timeBetweenUnits;
        _currentTime = 0;
        _currentTimeInterval = _timeInterval;
    }


    public bool IsEnd()
    {
        return _isEnd;
    }

    public bool CanSpawn()
    {
        if (_isSpawnTime && _currentTimeInterval > _timeInterval)
        {
            Spawn();
            return true;
        }
        return false;
    }

    public void Spawn()
    {
        _currentTimeInterval = 0;
    }

    public void Update()
    {
        _currentTimeInterval += Time.deltaTime;

        if (_currentTimeInterval > _timeInterval)
        {
            _currentTimeInterval = _timeInterval + 0.1f;
        }

        _currentTime += Time.deltaTime;

        _isSpawnTime = _currentTime < _timeWave;
        _isEnd = _currentTime > _timeWave + _timeWait;
    }
}
