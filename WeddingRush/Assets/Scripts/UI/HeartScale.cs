using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScale : MonoSingleton<HeartScale>
{
    private Animator animator;
    private const string HEART_SCALE = "HeartScaling";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }


    public void ChangeAnimationState()
    {
        animator.enabled = true;
        animator.Play(HEART_SCALE);
        Invoke(nameof(setAnimatorFalse), 1f);
    }

    private void setAnimatorFalse()
    {
        animator.enabled = false;
    }
}