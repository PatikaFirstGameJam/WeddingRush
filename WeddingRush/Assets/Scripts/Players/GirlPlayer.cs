using UnityEngine;

public class GirlPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Objective"))
        {
            //will change with observer
            FindObjectOfType<GameManager>().IncreaseMoney();
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("PreGate"))
        {
            this.gameObject.SetActive(false);
        }
        else if (col.gameObject.CompareTag("PostGate"))
        {
            this.gameObject.SetActive(true);
        }
    }
}