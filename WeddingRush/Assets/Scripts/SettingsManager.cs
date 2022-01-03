using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private static SettingsManager instance;
    public static SettingsManager Instance =>instance ?? (instance=FindObjectOfType<SettingsManager>());

    [SerializeField] private GameSettings settings;
    public static GameSettings GameSettings => Instance.settings;
}
