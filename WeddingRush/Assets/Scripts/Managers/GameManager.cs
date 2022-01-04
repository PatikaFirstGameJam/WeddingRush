using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int money = 0;
    [SerializeField] private GameObject girlPlayer;
    [SerializeField] private static bool isGirlEnable = true;

    public void IncreaseMoney()
    {
        //for now when girl and boy attached with objectives our money increase 400, we can fix later. or we can design our levels with this information. :D 
        money += 200;
    }

    public void DecreaseRingAmount()
    {
        if (money >= 500)
        {
            money -= 500;
        }
        else
        {
            Debug.Log("Love Decrease -50");
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

    public static void GirlEnableTrue()
    {
        isGirlEnable = true;
    }

    public static void GirlEnableFalse()
    {
        isGirlEnable = false;
    }
}