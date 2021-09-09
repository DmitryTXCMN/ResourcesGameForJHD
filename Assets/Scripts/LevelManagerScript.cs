using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] private ServerSimulation _server;
    private BlockFactoryScript factory;
    private PlayerInfo currentPlayer;
    private float timer;
    [SerializeField] private UIUpdater _uiUpdater;

    void Start()
    {
        factory = new BlockFactoryScript();
        timer = 5;
        currentPlayer = _server.LoadPlayerInfo();
        _uiUpdater.FirstUpdateUI(currentPlayer);
    }

    public void LoadNewData()
    {
        currentPlayer = _server.LoadPlayerInfo();
    }

    public void UpdateUI()
    {
        _uiUpdater.UpdateUI(currentPlayer);
    }

    void Update()
    {

        timer -= Time.deltaTime;
        if (timer<0)
        {
            currentPlayer.AmountOfBlock += factory.GetBlocks(currentPlayer.FactoryLevel);
            Debug.Log(currentPlayer.EXP);
            currentPlayer.EXP = currentPlayer.EXP + 20;
            Debug.Log(currentPlayer.EXP+" after");
            timer = 5;

            _server.UpLoadPlayerInfo(currentPlayer);
            UpdateUI();
        }
    }
}
