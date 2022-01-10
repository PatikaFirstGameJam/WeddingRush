using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoveProgressUI : MonoBehaviour
{
    [SerializeField] private Image loveFillImage;
    [SerializeField] private Text loveText;
    [SerializeField] private float updateSpeedSecond = 0.5f;


    private void Awake()
    {
        GameManager.Instance.OnProgressChange += HandleBarChange;
    }

    private void UpdateProgressFill(float loveValue)
    {
        loveFillImage.fillAmount = loveValue;
    }

    private void UpdateLoveText(int loveValue)
    {
        loveText.text = loveValue.ToString();
    }

    private void HandleBarChange(float love)
    {
        StartCoroutine(ChangeToLove(love));
    }

    private IEnumerator ChangeToLove(float pct)
    {
        float preChangePct = loveFillImage.fillAmount;
        float elapsed = 0f;
        while (elapsed < updateSpeedSecond)
        {
            elapsed += 0.1f;
            loveFillImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed/updateSpeedSecond);
            yield return null;
        }

        loveFillImage.fillAmount = pct;
    }

    private void Update()
    {
        UpdateLoveText(GameManager.Instance.GetLoveValue());
        
    }
}