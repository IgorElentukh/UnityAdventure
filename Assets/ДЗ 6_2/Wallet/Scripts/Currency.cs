using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency
{
    public Currency(CurrencyType currencyType ,int maxValue)
    {
        if (maxValue < 0)
            throw new ArgumentOutOfRangeException(nameof(maxValue));

        Type = currencyType;
        MaxValue = maxValue;
    }

    public CurrencyType Type { get;}
    public int MaxValue { get; }
    public int CurrentValue { get; private set; }

    public void Add(int value)
    {
        if (value < 0 || IsEnoughSpace(value) == false)
            throw new ArgumentOutOfRangeException(nameof(value));

        CurrentValue += value;
    }

    public void Reduce(int value)
    {
        if (value < 0 || CanReduce(value) == false)
            throw new ArgumentOutOfRangeException(nameof(value));

        CurrentValue -= value;
    }

    private bool CanReduce(int value) => value <= CurrentValue;

    private bool IsEnoughSpace(int value) => CurrentValue + value <= MaxValue;

}
