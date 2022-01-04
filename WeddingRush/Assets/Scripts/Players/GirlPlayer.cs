using System;
using UnityEngine;

public class GirlPlayer : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Rigidbody rigidbody => _rigidbody ?? (_rigidbody = GetComponent<Rigidbody>());
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Objective"))
        {
            GameManager.Instance.IncreaseMoney();
            Destroy(col.gameObject);
        }
    }
}