using UnityEngine;
using UnityEngine.UI;

public class LoveProgressUI : MonoBehaviour
{
    [SerializeField] private Image loveFillImage;
    [SerializeField] private Text loveText;

    private void UpdateProgressFill(float loveValue)
    {
        loveFillImage.fillAmount = loveValue;
    }

    private void UpdateLoveText(float loveValue)
    {
        loveText.text = loveValue.ToString();
    }

    private void Update()
    {
        float loveInverseLerpValue = Mathf.InverseLerp(0f, 100f, GameManager.Instance.GetLoveValue());
        UpdateLoveText(GameManager.Instance.GetLoveValue());
        UpdateProgressFill(loveInverseLerpValue);
    }
}