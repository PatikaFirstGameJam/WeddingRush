using System;
using UnityEngine;

public class DistanceFinder : MonoBehaviour
{
    [SerializeField] private Transform boyPlayer;
    [SerializeField] private Transform girlPlayer;

    private Vector3 boyPosition;
    private Vector3 girlPosition;

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
        if (distanceX <= 2)
        {
            closeDistance?.Invoke();
        }
        else
        {
            longDistance?.Invoke();
        }
    }
}