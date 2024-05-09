using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : IMovable, IGetValue
{
    public event Action<float> eventMove;

    private float _value;

    public Move(PlayerConfig settings)
    {
        this._value = settings.Speed;
    }

    public void Walk()
    {
        float result =+ _value;
        eventMove?.Invoke(result);
    }

    public void GetValue(out float outValue)
    {
        outValue = this._value;
    }
}
