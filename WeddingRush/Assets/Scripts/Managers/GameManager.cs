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

    public bool isFailed=false;

    public event Action<float> OnProgressChange;
    public static event Action failed;
    public static event Action nextLevel;

    private int coefficient=1;


    private void Awake()
    {
        tapToPlay.enabled=true;
        Time.timeScale = 0f;
        isGameStart = false;
        money = PlayerPrefs.GetInt("Money", 0);
        BoyPlayer.finish += FinishController;
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
        money += 5*coefficient;
        PlayerPrefs.SetInt("Money",money);
    }

    public void IncreaseLove()
    {
        if (love<=100)
        {
            love += 10;
            float pct = (float)love / 100;
            Debug.Log(pct);
            OnProgressChange?.Invoke(pct);
        }
        HeartScale.Instance.ChangeAnimationState();
        
    }

    public void DecreaseLove()
    {
        if (love>0)
        {
            love -= 10;
            float pct = (float)love / 100;
            OnProgressChange?.Invoke(pct);
        }
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

    public void DecreaseFurnitureAmount()
    {
        if (money >= 100)
        {
            IncreaseLove();
            money -= 100;
            PlayerPrefs.SetInt("Money",money);
        }
        else
        {
            DecreaseLove();
        }
    }
    public void DecreaseRingAmount()
    {
        if (money >= 50)
        {
            IncreaseLove();
            money -= 50;
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

        coefficientChanger();
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
        if (isFailed)
        {
            failed?.Invoke();
        }
        else if (!isFailed && PlayerPrefs.GetInt("Money", 0)<100)
        {
            nextLevel?.Invoke();
        }
    }
    public void FinishController()
    {
        if (PlayerPrefs.GetInt("Money", 0)<100)
        {
            isFailed = true;
            Finish();
        }
        else
        {
            isFailed = false;
            Finish();
        }
    }

    public void coefficientChanger()
    {
        if (love>0 && love<=10)
        {
            coefficient = 1;
        }
        else if (love >10 && love<=30)
        {
            coefficient = 2;
        }
        else if (love >30 && love<=50)
        {
            coefficient = 3;
        }
        else if (love >50 && love<=80)
        {
            coefficient = 4;
        }
        else if (love >80 && love<=1000)
        {
            coefficient = 5;
        }
    }

}