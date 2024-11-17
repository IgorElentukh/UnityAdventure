using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WalletInterface : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsValueText;
    [SerializeField] private TMP_Text _crystalsValueText;
    [SerializeField] private TMP_Text _energyValueText;

    private WalletManager _walletManager;

    public void Initialize(WalletManager walletManager)
    {
        _walletManager = walletManager;
        _walletManager.Wallet.CurrencyChanged += OnCurrencyChanged;

        _coinsValueText.text = 0.ToString();
        _crystalsValueText.text = 0.ToString();
        _energyValueText.text = 0.ToString();
    }

    private void OnCurrencyChanged(CurrencyType type, int currentValue)
    {
        switch (type)
        {
            case CurrencyType.Coins:
                _coinsValueText.text = currentValue.ToString();
                break;

            case CurrencyType.Crystals:
                _crystalsValueText.text = currentValue.ToString();
                break;

            case CurrencyType.Energy:
                _energyValueText.text = currentValue.ToString();
                break;
        }
    }
}
