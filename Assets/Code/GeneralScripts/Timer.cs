using System;
using UnityEngine;

public class Timer : ITime {
    
    private float timeAccumulator;
    public float _value;

    public Timer(TimerConfig config)
    {
        this._value = config.CollDown;
    }

    public bool GetTime()
    {
        float result = timeAccumulator + Time.fixedDeltaTime;
        timeAccumulator = result - Mathf.Floor(result);
        if (result >= _value)
        {
            //Debug.Log(result);
            result = 0f;
            return true;
        }
        else
        {
            return false;
        }
    }
}