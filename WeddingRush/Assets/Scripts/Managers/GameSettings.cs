using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Game Settings")]
public class GameSettings : ScriptableObject
{
    public float playersSpeed = 10f;
    public float playersSideMovementSensitivity = 0.01f;
    public int platformCount = 100;
}