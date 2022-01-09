using System;
using UnityEngine;

public class BoyPlayer : MonoBehaviour
{
    public static event Action finish;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Objective"))
        {
            GameManager.Instance.IncreaseMoney();
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("RingGate"))
        {
            GameManager.Instance.DecreaseRingAmount();
        }
        /*else if (col.gameObject.CompareTag("PreGate"))
        {
            GameManager.Instance.GirlEnableFalse();
        }
        else if (col.gameObject.CompareTag("PostGate"))
        {
            GameManager.Instance.GirlEnableTrue();
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            finish?.Invoke();
        }
    }
}