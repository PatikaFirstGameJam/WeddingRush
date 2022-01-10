using System;
using UnityEngine;

public class WallDestroyer : MonoBehaviour
{
    private void Awake()
    {
        BoyPlayer.finish += DisabledDoor;
    }

    private void DisabledDoor()
    {
        gameObject.SetActive(false);
    }
}
