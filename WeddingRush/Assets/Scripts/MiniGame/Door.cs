using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void Awake()
    {
        BoyPlayer.door += OpenTheDoor;
        BoyPlayer.exit += DestroyDoor;
    }

    private void OpenTheDoor()
    {
        StartCoroutine(nameof(OpenTheDoorRoutine));
    }

    private void DestroyDoor()
    {
        gameObject.SetActive(false);
    }
    private IEnumerator OpenTheDoorRoutine()
    {
        
        float elapsed = 0.015f;
        while (transform.rotation.y > -45 )
        {
            var currentRotation = gameObject.transform.rotation;
            var changedRotation = currentRotation;
            changedRotation.y -= 0.3f;
            currentRotation.y = Mathf.Lerp(currentRotation.y, changedRotation.y, elapsed);
            transform.rotation = currentRotation;
            yield return null;
        }
        
        
    }
}
