using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private Button YesButton;
    private Button NoButton;

    private void Awake()
    {
        textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        YesButton = transform.Find("YesButton").GetComponent<Button>();
        NoButton = transform.Find("NoButton").GetComponent<Button>();

        ShowQuestion("Are you sure?", () => {
            Debug.Log("Yes");
        }, () => {
            Debug.Log("No");
        });
    }


    public void ShowQuestion(string questionText, Action yesAction, Action noAction)
    {
        textMeshPro.text = questionText;
        YesButton.onClick.AddListener(() => {
            Hide();
            yesAction();
        });
        NoButton.onClick.AddListener(() => {
            Hide();
            noAction();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}