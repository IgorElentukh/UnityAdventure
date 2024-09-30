using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoin : Coin
{
    [SerializeField] private int _minCoinValue;
    [SerializeField] private int _maxCoinValue;

    public override int GetValue() 
        => Random.Range(_minCoinValue, _maxCoinValue);
}
