using System;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private int money = 0;
    [SerializeField] private int love = 50;
    [SerializeField] private GameObject girlPlayer;
    [SerializeField] private bool isGirlEnable = true;

    public void IncreaseMoney()
    {
        money += 200;
    }

    public void IncreaseLove()
    {
        love += 10;
    }

    public void DecreaseLove()
    {
        love -= 20;
    }

    public void DecreaseRingAmount()
    {
        if (money >= 500)
        {
            IncreaseLove();
            money -= 500;
        }
        else
        {
            DecreaseLove();
        }
    }

    private void Update()
    {
        GirlStatus();
    }

    public void GirlStatus()
    {
        if (isGirlEnable)
        {
            girlPlayer.SetActive(true);
        }
        else
        {
            girlPlayer.SetActive(false);
        }
    }

    public void GirlEnableTrue()
    {
        isGirlEnable = true;
    }

    public void GirlEnableFalse()
    {
        isGirlEnable = false;
    }
}