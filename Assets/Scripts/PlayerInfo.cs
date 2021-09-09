using UnityEngine;
public class PlayerInfo
{
    public string Name;
    public int PlayerLevel;
    private int exp;
    public int EXP
    {
        get
        {
            return exp;
        }
        set
        {
            if (value >= 1000)
            {
                PlayerLevel++;
                exp = value - 1000;
            }
            else
                exp = value;
        }
    }
    public int AmountOfDiamond;
    public int AmountOfCoin;
    public int AmountOfBlock;
    public int FactoryLevel;

    public PlayerInfo()
    {
        Name = "";
        PlayerLevel = 0;
        EXP = 0;
        AmountOfDiamond = 0;
        AmountOfCoin = 0;
        AmountOfBlock = 0;
        FactoryLevel = 0;
    }
}
