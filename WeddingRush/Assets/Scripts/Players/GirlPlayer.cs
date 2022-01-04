using System;
using UnityEngine;

public class GirlPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Objective"))
        {
            GameManager.Instance.IncreaseMoney();
            Destroy(col.gameObject);
        }
    }
}