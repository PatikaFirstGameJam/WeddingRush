using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int money = 0;

    public void IncreaseMoney()
    {
        //for now when girl and boy attached with objectives our money increase 400, we can fix later.
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
}
