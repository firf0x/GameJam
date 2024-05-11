using System;
using UnityEngine;

public class Timer : ITime {
    
    private float timeAccumulator;
    public float _value;
    
    private float result;

    public Timer(TimerConfig config)
    {
        this._value = config.CollDown;
    }

    public bool GetTime()
    {
        result += timeAccumulator + Time.fixedDeltaTime;
        timeAccumulator = Mathf.Floor(result);
        Debug.Log(timeAccumulator + " : " + result);
        if (result >= _value)
        {
            //Debug.Log("Вывод");
            result = 0f;
            timeAccumulator = 0f;
            return true;
        }
        else
        {
            return false;
        }
    }
}