using System;
using UnityEngine;

public class GateEntrance : MonoBehaviour
{
    /*[SerializeField] private GameObject boyPlayer;
    [SerializeField] private GameObject girlPlayer;

    [SerializeField] private Transform girlLeftLimit;
    [SerializeField] private Transform girlRightLimit;
    
    [SerializeField] private Transform boyLeftLimit;
    [SerializeField] private Transform boyRightLimit;

    //private float girlLeftLimitX => girlLeftLimit.localPosition.x;
    //private float girlRightLimitX => girlRightLimit.localPosition.x;

    [SerializeField] private Vector3 boyPosition;
    [SerializeField] private Vector3 girlPosition;

    [SerializeField] private Vector3 distance;
    [SerializeField] private float distanceX;
    [SerializeField] private float distanceXAtFalse;

    void Update()
    {
        FindDistance();
    }


    private void FindDistance()
    {
        boyPosition = boyPlayer.transform.position;
        girlPosition = girlPlayer.transform.position;
        distance = boyPosition - girlPosition;
        distanceX = distance.x;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PreGate"))
        {
            distanceXAtFalse = distanceX;
            girlPlayer.transform.position = boyPlayer.transform.localPosition;
            GameManager.GirlEnableFalse();
        }
        else if (col.gameObject.CompareTag("PostGate"))
        {
            girlPlayer.transform.position = new Vector3(boyPosition.x - distanceXAtFalse, girlPosition.y, girlPosition.z);
            //girlLeftLimit.transform.position = new Vector3(-boyRightLimit.localPosition.x, girlLeftLimit.localPosition.y, -boyRightLimit.localPosition.z);

            //girlRightLimit.transform.position = new Vector3(-boyLeftLimit.localPosition.x, girlRightLimit.localPosition.y, -boyLeftLimit.localPosition.z);

            GameManager.GirlEnableTrue();
        }
    }
}