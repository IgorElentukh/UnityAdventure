using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private WalletInterface _walletInterface;

    private WalletManager _walletManager;

    private void Awake()
    {
        _walletManager = new WalletManager();
        _walletManager.Initialize();

        _walletInterface = Instantiate(_walletInterface);
        _walletInterface.Initialize(_walletManager);
    }

    private void Update()
    {
        _walletManager.Update();
    }
}
