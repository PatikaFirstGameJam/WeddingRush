using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private int money = 0;
    [SerializeField] private int love = 50;
    [SerializeField] private GameObject girlPlayer;
    [SerializeField] private bool isGirlEnable = true;

    [SerializeField] private Text moneyText;

    [SerializeField] private Image tapToPlay;
    [SerializeField] public bool isGameStart;

    public event Action<float> OnProgressChange;


    private void Awake()
    {
        tapToPlay.enabled=true;
        Time.timeScale = 0f;
        isGameStart = false;
        StartCoroutine(DecreaseLovePerSecRoutine());
    }
    
    public void IsGameStartEnable()
    {
        isGameStart = true;
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        tapToPlay.enabled=false;
    }
    
    public void IncreaseMoney()
    {
        money += 200;
    }

    public void IncreaseLove()
    {
        love += 10;
        float pct = (float)love / 100;
        Debug.Log(pct);
        OnProgressChange?.Invoke(pct);
        HeartScale.Instance.ChangeAnimationState();
    }

    public void DecreaseLove()
    {
        love -= 20;
        float pct = (float)love / 100;
        OnProgressChange?.Invoke(pct);
        HeartScale.Instance.ChangeAnimationState();
    }

    private IEnumerator DecreaseLovePerSecRoutine()
    {
        while (true)
        {
            love -= 1;
            float pct = (float)love / 100;
            OnProgressChange?.Invoke(pct);
            yield return new WaitForSeconds(1f);
        }
        
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
        //GirlStatus();
        AllMoney();
        if (isGameStart)
        {
            StartGame();
        }
    }

    /*public void GirlStatus()
    {
        if (isGirlEnable)
        {
            girlPlayer.SetActive(true);
        }
        else
        {
            girlPlayer.SetActive(false);
        }
    }*/

    /*public void GirlEnableTrue()
    {
        isGirlEnable = true;
    }

    public void GirlEnableFalse()
    {
        isGirlEnable = false;
    }*/

    public int GetLoveValue()
    {
        return love;
    }

    private void AllMoney()
    {
        PlayerPrefs.SetInt("Money",money);
        moneyText.text=PlayerPrefs.GetInt("Money", 0).ToString();
    }

}