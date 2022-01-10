using System;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField]private Cinemachine.CinemachineVirtualCamera cam1;
    [SerializeField]private Cinemachine.CinemachineVirtualCamera cam2;

    private void Awake()
    {
        BoyPlayer.door += Cam1Disabled;
        BoyPlayer.exit += Cam2Disabled;
    }

    private void Cam1Disabled()
    {
        cam1.enabled = false;
    }

    private void Cam2Disabled()
    {
        cam2.enabled = false;
    }
}
