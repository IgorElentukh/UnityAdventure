using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _sum;

    public void AddSum(Coin coin)
    {
        _sum += coin.GetValue();
        Debug.Log(_sum);
    }
}
