using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardCoin : Coin
{
    [SerializeField] private int _value;

    public override int GetValue()
    {
        return _value;
    }
}
