using UnityEngine;
using UnityEngine.UI;

public class CloseButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject _parentPanel;
    public void CloseButtonClick()
    {
        _parentPanel.active = false;
    }
}