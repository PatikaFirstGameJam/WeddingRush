using System;
using UnityEngine;

public class DistanceFinder : MonoBehaviour
{
    [SerializeField] private Transform boyPlayer;
    [SerializeField] private Transform girlPlayer;

    [SerializeField] private Vector3 boyPosition;
    [SerializeField] private Vector3 girlPosition;

    private Vector3 distance;
    [SerializeField] private float distanceX;

    public static event Action<float> closeDistance;

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
            closeDistance?.Invoke(distanceX);
    }
}