using System;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    private Vector3 firstPos;
    private int platformCount => SettingsManager.GameSettings.platformCount;

    private void Awake()
    {
        firstPos.x = 0;
        firstPos.y = -0.85f;
        firstPos.z = 4.04f;
        platformPrefab.transform.localPosition = firstPos;
        GeneratePlatform();
    }


    private void GeneratePlatform()
    {
        var pos = firstPos;
        var add = 12.75f;
        for (int i = 0; i < platformCount; i++)
        {
            Instantiate(platformPrefab,new Vector3(-4f,0.25f,pos.z),platformPrefab.transform.rotation);
            pos.z += add;
        }
    }
}
