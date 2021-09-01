using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeed : MonoBehaviour
{
    public Animator Animator;
    //Value from the slider, and it converts to speed level
    public float Value = 3.0f;

    void Start()
    {
		Animator = GetComponent<Animator>();
        Animator.speed = Value;
    }
}