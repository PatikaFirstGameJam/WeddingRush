using System;
using UnityEngine;

public class DistanceFinder : MonoBehaviour
{
    [SerializeField] private Transform boyPlayer;
    [SerializeField] private Transform girlPlayer;

    [SerializeField] private Vector3 boyPosition;
    [SerializeField] private Vector3 girlPosition;

    private float distance;

    public static event Action<float> allDistance;

    void Update()
    {
        FindDistance();
        DistanceController();
    }

    private void FindDistance()
    {
        boyPosition = boyPlayer.transform.position;
        girlPosition = girlPlayer.transform.position;
        distance = Vector3.Distance(boyPosition, girlPosition);
    }

    private void DistanceController()
    {
        allDistance?.Invoke(distance);
    }
}