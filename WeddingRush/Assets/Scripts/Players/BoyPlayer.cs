
using UnityEngine;

public class BoyPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Objective"))
        {
            //will change with observer
            FindObjectOfType<GameManager>().IncreaseMoney();
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("RingGate"))
        {
            //will change with observer
            FindObjectOfType<GameManager>().DecreaseRingAmount();
        }
    }
}
