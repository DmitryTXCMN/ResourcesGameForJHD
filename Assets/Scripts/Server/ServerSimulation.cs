using System.IO;
using System;
using UnityEngine;

public class ServerSimulation : MonoBehaviour
{
    private PlayerInfo currentPlayer;
    [SerializeField] private GameObject _levelManager;

    public ServerSimulation()
    {
        currentPlayer = LoadPlayerInfo();
    }

    public PlayerInfo LoadPlayerInfo()
    {
        PlayerInfo playerInfo = new PlayerInfo();
        using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + @"\Assets\Scripts\Server\PlayerInfo.txt"))
        {
            playerInfo.Name = reader.ReadLine();
            playerInfo.PlayerLevel = Convert.ToInt32(reader.ReadLine());
            playerInfo.EXP = Convert.ToInt32(reader.ReadLine());
            playerInfo.AmountOfDiamond = Convert.ToInt32(reader.ReadLine());
            playerInfo.AmountOfCoin = Convert.ToInt32(reader.ReadLine());
            playerInfo.AmountOfBlock = Convert.ToInt32(reader.ReadLine());
            playerInfo.FactoryLevel = Convert.ToInt32(reader.ReadLine());
        }
        return playerInfo;
    }

    public void UpLoadPlayerInfo(PlayerInfo playerInfo)
    {
        using (StreamWriter reader = new StreamWriter(Directory.GetCurrentDirectory() + @"\Assets\Scripts\Server\PlayerInfo.txt"))
        {
            reader.WriteLine(playerInfo.Name);
            reader.WriteLine(playerInfo.PlayerLevel);
            reader.WriteLine(playerInfo.EXP);
            reader.WriteLine(playerInfo.AmountOfDiamond);
            reader.WriteLine(playerInfo.AmountOfCoin);
            reader.WriteLine(playerInfo.AmountOfBlock);
            reader.WriteLine(playerInfo.FactoryLevel);
        }
    }

    public bool ConvertRequestDTC(int requestedValue, out string problem)
    {
        problem = "";
        if (requestedValue > currentPlayer.AmountOfDiamond)
        {
            problem = "DiamondLack";
            return false;
        }
        currentPlayer.AmountOfCoin += (int)(requestedValue * GetDiamondToCoinRate());
        currentPlayer.AmountOfDiamond -= requestedValue;
        UpLoadPlayerInfo(currentPlayer);
        _levelManager.SendMessage("LoadNewData");
        return true;
    }

    public bool ConvertRequestBTC(int requestedValue, out string problem)
    {
        problem = "";
        if (requestedValue > currentPlayer.AmountOfBlock)
        {
            problem = "BlockLack";
            return false;
        }
        currentPlayer.AmountOfCoin += (int)(requestedValue * GetBlockToCoinRate());
        currentPlayer.AmountOfBlock -= requestedValue;
        UpLoadPlayerInfo(currentPlayer);
        _levelManager.SendMessage("LoadNewData");
        return true;
    }

    public bool DonateRequest(int requestedValue, out string problem)
    {
        problem = "";
        //sended request to Donate System
        //DonateSys.Get(requestedValue, player ***) example
        //...
        //successful payment
        currentPlayer.AmountOfDiamond += requestedValue;
        UpLoadPlayerInfo(currentPlayer);
        _levelManager.SendMessage("LoadNewData");
        return true;
        // else problem = "Not enough money" or "Server error" and ect.
    }

    private double GetBlockToCoinRate()
    {
        using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + @"\Assets\Scripts\Server\BlockToCoinRate.txt"))
        {
            return Convert.ToDouble(reader.ReadLine());
        }
    }

    private double GetDiamondToCoinRate()
    {
        using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + @"\Assets\Scripts\Server\DiamondToCoinRate.txt"))
        {
            return Convert.ToDouble(reader.ReadLine());
        }
    }
}
