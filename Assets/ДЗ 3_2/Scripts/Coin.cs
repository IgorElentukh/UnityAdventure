using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Coin : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        CoinCollector coinCollector = other.GetComponent<CoinCollector>();

        if(coinCollector != null)
        {
            coinCollector.AddSum(this);
            Destroy(gameObject);
        }
    }

    public abstract int GetValue();
}
