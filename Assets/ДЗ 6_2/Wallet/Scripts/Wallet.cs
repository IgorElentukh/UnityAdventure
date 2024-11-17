using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private Dictionary<CurrencyType, Currency> _currencies = new Dictionary<CurrencyType, Currency>();
    public event Action<CurrencyType, int> CurrencyChanged;

    public void AddCurrency(CurrencyType type, int maxValue)
    {
        if (IsCurrencyExist(type))
            throw new InvalidOperationException($"Currency {type} already exists");

        _currencies[type] = new Currency(type, maxValue);
    }

    public void AddTo(CurrencyType type, int value)
    {
        if(IsCurrencyExist(type) == false)
            throw new InvalidOperationException($"Currency {type} doesn't exist");

        _currencies[type].Add(value);

        CurrencyChanged?.Invoke(type, _currencies[type].CurrentValue);
    }

    public void ReduceFrom(CurrencyType type, int value)
    {
        if (IsCurrencyExist(type) == false)
            throw new InvalidOperationException($"Currency {type} doesn't exist");

        _currencies[type].Reduce(value);

        CurrencyChanged?.Invoke(type, _currencies[type].CurrentValue);
    }

    public int GetCurrentValue(CurrencyType type)
    {
        if(IsCurrencyExist(type) == false)
            throw new InvalidOperationException($"Currency {type} doesn't exist");

        return _currencies[type].CurrentValue;
    }

    private bool IsCurrencyExist(CurrencyType type) => _currencies.ContainsKey(type);
}
