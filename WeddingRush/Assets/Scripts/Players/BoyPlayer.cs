using System;
using UnityEngine;

public class BoyPlayer : MonoBehaviour
{
    public static event Action finish;
    public static event Action door;
   // public static event Action exit;
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
        else if (col.gameObject.CompareTag("Finish"))
        {
            door?.Invoke();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            finish?.Invoke();
            //exit?.Invoke();
        }
    }
}