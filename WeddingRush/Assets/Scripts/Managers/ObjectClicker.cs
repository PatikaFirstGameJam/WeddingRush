using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectClicker : MonoBehaviour
{
    public GameObject definedButton;
    public GameObject[] levels;
    private int current_level = 0;

    private void Start()
    {
        definedButton = this.gameObject;
        SwitchObject(current_level);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f) && hit.collider.gameObject == gameObject)
            {
                    if (current_level < levels.Length - 1)
                    {
                        current_level++;
                        SwitchObject(current_level);
                    }
            }
        }
    }

    void SwitchObject(int lvl)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (i == lvl)
                levels[i].SetActive(true);
            else
                levels[i].SetActive(false);
        }
    }
}
