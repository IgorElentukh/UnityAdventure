using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager
{
    public Wallet Wallet { get; private set; }

    public void Initialize()
    {
        Wallet = new Wallet();

        Wallet.AddCurrency(CurrencyType.Coins, 1000);
        Wallet.AddCurrency(CurrencyType.Crystals, 200);
        Wallet.AddCurrency(CurrencyType.Energy, 100);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            Wallet.AddTo(CurrencyType.Coins, 10);
        else if(Input.GetKeyDown(KeyCode.A))
            Wallet.AddTo(CurrencyType.Crystals, 10);
        else if(Input.GetKeyDown(KeyCode.E))
            Wallet.AddTo(CurrencyType.Energy, 10);
    }
}
