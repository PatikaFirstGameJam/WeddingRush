using System;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    private void Awake()
    {
        ShowMoney();
    }

    void Update()
    {
        ShowMoney();
    }

    private void ShowMoney()
    {
        moneyText.text=PlayerPrefs.GetInt("Money", 0).ToString();
    }
}
