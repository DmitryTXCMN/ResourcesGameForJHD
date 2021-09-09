using UnityEngine;

public class DiamondUIScript : MonoBehaviour
{
    [SerializeField] private GameObject _donatePanel;

    [SerializeField] private ServerSimulation _server;


    public void DonateButtonClick()
    {
        _donatePanel.active = true;
    }

    public void BuyDiamondButtonClick(int value)
    {
        if (_server.DonateRequest(value, out string problem))
            Debug.Log("PaymentSuccess");
        else
            Debug.Log("PaymentFailed");

        //updateUI
    }
}
