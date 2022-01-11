using UnityEngine;
using UnityEngine.UI;

public class NextLevelScreen : MonoBehaviour
{
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject perfect;
    [SerializeField] private Image nextLevel;

    private void Awake()
    {
        GameManager.nextLevel += NextScreen;
        light.SetActive(false);
        perfect.SetActive(false);
        nextLevel.enabled = false;
    }

    private void NextScreen()
    {
        light.SetActive(true);
        perfect.SetActive(true);
        nextLevel.enabled = true;
    }
}
