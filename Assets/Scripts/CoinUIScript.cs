using System;
using UnityEngine;
using UnityEngine.UI;


public class CoinUIScript : MonoBehaviour
{
    [SerializeField] private GameObject _convertPanel;
    [SerializeField] private InputField _diamondConvertInput;
    [SerializeField] private InputField _blockConvertInput;

    [SerializeField] private ServerSimulation _server;

    public void ConvertButtonClick()
    {
        _convertPanel.active = true;
    }

    public void ConvertCoinFromDiamondButtonClick()
    {
        int inputFieldValue = Convert.ToInt32(_diamondConvertInput.text);
        if (inputFieldValue <= 0)
            return;

        if (_server.ConvertRequestDTC(inputFieldValue, out string problem))
            Debug.Log("PaymentSuccess");
        else
            Debug.Log("PaymentFailed");
    }

    public void ConvertCoinFromBlockButtonClick()
    {
        int inputFieldValue = Convert.ToInt32(_blockConvertInput.text);
        if (inputFieldValue <= 0)
            return;

        if (_server.ConvertRequestBTC(inputFieldValue, out string problem))
            Debug.Log("PaymentSuccess");
        else
            Debug.Log("PaymentFailed");

        //updateUI
    }
}
