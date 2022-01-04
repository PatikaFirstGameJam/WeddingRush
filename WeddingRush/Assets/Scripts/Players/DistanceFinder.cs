using System;
using UnityEditor;
using UnityEngine;

public class DistanceFinder : MonoBehaviour
{
    [SerializeField] private Transform boyPlayer;
    [SerializeField] private Transform girlPlayer;

    [SerializeField] private Vector3 boyPosition;
    [SerializeField] private Vector3 girlPosition;

    private Vector3 distance;
    [SerializeField] private float distanceX;

    public static event Action closeDistance;
    public static event Action longDistance;

    void Update()
    {
        FindDistance();
        DistanceController();
    }

    private void FindDistance()
    {
        boyPosition = boyPlayer.transform.position;
        girlPosition = girlPlayer.transform.position;
        distance = boyPosition - girlPosition;
        distanceX = distance.x;
    }

    private void DistanceController()
    {
        if (distanceX >= -1.5 && distanceX <= 1.5)
        {
            closeDistance?.Invoke();
        }
        else
        {
            longDistance?.Invoke();
        }
    }
}