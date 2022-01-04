using System;
using UnityEngine;

public class GirlPlayer : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Rigidbody rigidbody => _rigidbody ?? (_rigidbody = GetComponent<Rigidbody>());
    private void Start()
    {
        DistanceFinder.closeDistance += RigidbodyEnableFalse;
        DistanceFinder.longDistance += RigidbodyEnableTrue;
    }


    private void RigidbodyEnableFalse()
    {
        rigidbody.detectCollisions = false;
    }

    private void RigidbodyEnableTrue()
    {
        rigidbody.detectCollisions = true;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Objective"))
        {
            GameManager.Instance.IncreaseMoney();
            Destroy(col.gameObject);
        }
    }
}