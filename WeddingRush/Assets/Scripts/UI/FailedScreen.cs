using System;
using UnityEngine;
using UnityEngine.UI;

public class FailedScreen : MonoBehaviour
{
   [SerializeField] private Image failed;
   [SerializeField] private Image panel;
   [SerializeField] private Image tryAgain;

   private void Awake()
   {
      GameManager.failed += FailScreen;
      failed.enabled = false;
      panel.enabled = false;
      tryAgain.enabled = false;
   }
   private void FailScreen()
   {
      Invoke(nameof(FailScreenRoutine),0.5f);
   }

   private void FailScreenRoutine()
   {
      failed.enabled = true;
      panel.enabled = true;
      tryAgain.enabled = true;
   }
}
