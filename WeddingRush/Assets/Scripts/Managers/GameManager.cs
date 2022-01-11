using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private int money;
    [SerializeField] private int love = 0;

    

    [SerializeField] private Image tapToPlay;
    [SerializeField] public bool isGameStart;

    public event Action<float> OnProgressChange;


    private void Awake()
    {
        tapToPlay.enabled=true;
        Time.timeScale = 0f;
        isGameStart = false;
        money = PlayerPrefs.GetInt("Money", 0);
        BoyPlayer.finish += Finish;
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
        PlayerPrefs.SetInt("Money",money);
    }

    public void IncreaseLove()
    {
        if (love<=100)
        {
            love += 5;
            float pct = (float)love / 100;
            Debug.Log(pct);
            OnProgressChange?.Invoke(pct);
        }
        HeartScale.Instance.ChangeAnimationState();
        
    }

    public void DecreaseLove()
    {
        if (love>=0)
        {
            love -= 10;
            float pct = (float)love / 100;
            OnProgressChange?.Invoke(pct);
            HeartScale.Instance.ChangeAnimationState();
        }
        
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

    public void DecreaseFurnitureAmount()
    {
        if (money >= 200)
        {
            IncreaseLove();
            money -= 200;
            PlayerPrefs.SetInt("Money",money);
        }
        else
        {
            DecreaseLove();
        }
    }
    public void DecreaseRingAmount()
    {
        if (money >= 500)
        {
            IncreaseLove();
            money -= 500;
            PlayerPrefs.SetInt("Money",money);
        }
        else
        {
            DecreaseLove();
        }
    }

    private void Update()
    {
        if (isGameStart)
        {
            StartGame();
        }
    }

    public int GetLoveValue()
    {
        return love;
    }

    public int GetMoney()
    {
        return PlayerPrefs.GetInt("Money", 0);
    }

    public void Finish()
    {
        if (money<200)
        {
            Debug.Log("Failed");
        }
    }

}