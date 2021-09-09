using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private GameObject _diamondUI;
    [SerializeField] private GameObject _coinUI;
    [SerializeField] private GameObject _blockUI;
    [SerializeField] private GameObject _expUIPrgoressBar;
    [SerializeField] private GameObject _expUIText;
    [SerializeField] private GameObject _name;

    public void FirstUpdateUI(PlayerInfo playerInfo)
    {
        UpdateUI(playerInfo);
        _name.GetComponent<Text>().text = playerInfo.Name;
    }

    public void UpdateUI(PlayerInfo playerInfo)
    {
        _diamondUI.GetComponent<Text>().text = playerInfo.AmountOfDiamond.ToString();
        _coinUI.GetComponent<Text>().text = playerInfo.AmountOfCoin.ToString();
        _blockUI.GetComponent<Text>().text = playerInfo.AmountOfBlock.ToString();
        _expUIPrgoressBar.GetComponent<RectTransform>().anchorMax = new Vector2((float)playerInfo.EXP / 1000, 1);
        _expUIText.GetComponent<Text>().text = $"{playerInfo.EXP}/1000\nLvl. {playerInfo.PlayerLevel}";
    }
}
